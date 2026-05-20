using UnityEngine;

public class BossMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;
    public float totalMoveDistance = 10f; // Total width of the boss's path
    public int totalStops = 3;            // How many times it stops per direction
    public float stopDuration = 2f;

    [Header("Wall Detection")]
    public LayerMask wallLayer;           // Assign your Wall layer here in the Inspector
    public float raycastDistance = 1f;    // How far ahead the boss looks for a wall

    [Header("State")]
    private float startX;
    private bool isMoving = true;
    private float stopTimer;
    private int direction = 1;

    private float nextStopX;              // The specific X coordinate for the next stop
    private float stepDistance;           // Distance between each stop
    private int currentStopCount = 0;     // Tracking stops in the current direction

    private ProjectileSpawner spawner;

    void Start()
    {
        startX = transform.position.x;
        spawner = GetComponentInChildren<ProjectileSpawner>();

        // Calculate how far to move between each stop
        CalculateStep();
    }

    void CalculateStep()
    {
        // Divide the total range by number of stops
        stepDistance = totalMoveDistance / totalStops;

        // Set the next X target based on current position and direction
        nextStopX = transform.position.x + (stepDistance * direction);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

            // Cast a ray in the direction of movement
            Vector2 rayDirection = Vector2.right * direction;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, raycastDistance, wallLayer);
            bool hitWall = hit.collider != null;

            // Check if we reached or passed our next stop point
            bool reachedTarget = (direction > 0 && transform.position.x >= nextStopX) ||
                                 (direction < 0 && transform.position.x <= nextStopX);

            // Draws a line in the Scene window to help you see the raycast distance
            Debug.DrawRay(transform.position, rayDirection * raycastDistance, hitWall ? Color.green : Color.red);

            if (hitWall || reachedTarget)
            {
                isMoving = false;
                stopTimer = stopDuration;

                if (hitWall)
                {
                    // If we hit a wall, force the stop count to max.
                    // This ensures the boss turns around immediately when the timer finishes.
                    currentStopCount = totalStops;
                }
                else
                {
                    currentStopCount++;
                }

                if (spawner != null) spawner.StartFiring();
            }
        }
        else
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                if (spawner != null) spawner.StopFiring();

                // If we finished all stops or hit a wall, flip!
                if (currentStopCount >= totalStops)
                {
                    direction *= -1;
                    currentStopCount = 0;
                }

                CalculateStep(); // Find the next point to stop at
                isMoving = true;
            }
        }
    }
}