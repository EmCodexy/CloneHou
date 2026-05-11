using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public float Despawn = 3f;
    public int Damage = 1;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * BulletSpeed);
    }

    private void Start()
    {
        Destroy(gameObject, Despawn);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    EnemySpawnHealth spawner = collision.GetComponent<EnemySpawnHealth>();
    //    if (spawner != null)
    //    {
    //        spawner.TakeDamage(Damage);
    //        Destroy(gameObject);
    //        return;
    //    }

    //    EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
    //    if (enemyHealth != null)
    //    {
    //        enemyHealth.TakeDamage(Damage);
    //        Destroy(gameObject);
    //        return;
    //    }
    //}
}
