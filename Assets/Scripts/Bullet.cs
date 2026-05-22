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
       
        BossHealth enemy = collision.GetComponent<BossHealth>();


        if (enemy != null)
        {
            enemy.TakeDamage(damageValue);
            Destroy(gameObject);

        }
    }
}

