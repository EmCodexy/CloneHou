using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    public float BulletSpeed;
    public float Despawn = 3f;
    public int Damage = 1;


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {

            Instantiate(bullet, transform.position, transform.rotation);

            transform.Translate(Vector2.up * Time.deltaTime * BulletSpeed);

          
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(Damage);
    //        Destroy(gameObject);
    //    }
    //}
}

