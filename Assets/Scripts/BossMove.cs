using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 5f;
    public float stopDuration = 2f;

    private float startX;
    private bool isMoving = true;
    private float stopTimer;
    private int direction = 1;

    // Cache the spawner reference here to save performance
    private ProjectileSpawner spawner;

    void Start()
    {
        startX = transform.position.x;
        // Grab the component once at the start
        spawner = GetComponentInChildren<ProjectileSpawner>();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - startX) >= moveRange)
            {
                isMoving = false;
                stopTimer = stopDuration;
                direction *= -1; // Reverse direction for next time

                // Tell the child to START shooting
                if (spawner != null) spawner.StartFiring();
            }
        }
        else
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                isMoving = true;

                // Tell the child to STOP shooting
                if (spawner != null) spawner.StopFiring();
            }
        }
    }
}

