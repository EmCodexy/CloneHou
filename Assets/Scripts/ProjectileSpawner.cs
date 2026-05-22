using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }
    
    [Header("Projectile Attributes")]
    public GameObject Projectile;
    public float ProjectileLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float FiringRate;

    private GameObject spawnedProject;
    private float timer = 0f;

   
    private bool isFiring = false;

    void Update()
    {
     
        if (spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        }

        if (isFiring)
        {
            timer += Time.deltaTime;
            if (timer >= FiringRate)
            {
                FireProjectile();
                timer = 0; 
            }
        }
        
    }


    public void StartFiring()
    {
        
        isFiring = true;
        timer = FiringRate; 

       
    }

    public void StopFiring()
    {
        isFiring = false;
        timer = 0f; 
    }


    private void FireProjectile()
    {
        spawnedProject = Instantiate(Projectile, transform.position, Quaternion.identity);

     
        Projectiles projScript = spawnedProject.GetComponent<Projectiles>();
        if (projScript != null)
        {
            projScript.Speed = speed;
            projScript.ProjectileLife = ProjectileLife;

        }

        spawnedProject.transform.rotation = transform.rotation;
    }
}
