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

    void Start()
    {
        startX = transform.position.x;
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

                // Tell the child to shoot
                GetComponentInChildren<Projectiles>().StartFiring();
            }
        }
        else
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                isMoving = true;
                GetComponentInChildren<Projectiles>().StopFiring();
            }
        }
    }
}

