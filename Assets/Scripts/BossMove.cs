using UnityEngine;

public class BossMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;
    public float totalMoveDistance = 10f; 
    public int totalStops = 3;           
    public float stopDuration = 2f;

    [Header("Wall Detection")]
    public LayerMask wallLayer;           
    public float raycastDistance = 1f;    

    [Header("State")]
    private float startX;
    private bool isMoving = true;
    private float stopTimer;
    private int direction = 1;

    private float nextStopX;            
    private float stepDistance;          
    private int currentStopCount = 0;    

    private ProjectileSpawner spawner;

    void Start()
    {
        startX = transform.position.x;
        spawner = GetComponentInChildren<ProjectileSpawner>();

        
        CalculateStep();
    }

    void CalculateStep()
    {
      
        stepDistance = totalMoveDistance / totalStops;

       
        nextStopX = transform.position.x + (stepDistance * direction);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

            
            Vector2 rayDirection = Vector2.right * direction;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, raycastDistance, wallLayer);
            bool hitWall = hit.collider != null;

           
            bool reachedTarget = (direction > 0 && transform.position.x >= nextStopX) ||
                                 (direction < 0 && transform.position.x <= nextStopX);

           
            Debug.DrawRay(transform.position, rayDirection * raycastDistance, hitWall ? Color.green : Color.red);

            if (hitWall || reachedTarget)
            {
                isMoving = false;
                stopTimer = stopDuration;

                if (hitWall)
                {

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

             
                if (currentStopCount >= totalStops)
                {
                    direction *= -1;
                    currentStopCount = 0;
                }

                CalculateStep(); 
                isMoving = true;
            }
        }
    }
}