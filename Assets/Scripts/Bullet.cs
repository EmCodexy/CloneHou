using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public int damageValue = 1;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Try to find the EnemyHealth script on whatever we hit
        BossHealth enemy = collision.GetComponent<BossHealth>();

        // 2. If we found it, tell it to take damage
        if (enemy != null)
        {
            enemy.TakeDamage(damageValue);
            Destroy(gameObject); // Destroy bullet on hit
        }

       
    }
}

