using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float ProjectileLife;
    public float Rotation;
    public float Speed;

    private Vector2 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }


    private void Update()
    {
        if(timer > ProjectileLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * Speed * transform.right.x;
        float y = timer * Speed * transform.right.y;
        return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    }
    
}
