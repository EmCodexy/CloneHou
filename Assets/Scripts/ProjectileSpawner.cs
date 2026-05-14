using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Projectile Attributes")]
    public GameObject Projectile;
    public float ProjectileLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")] // Fixed typo
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float FiringRate;

    private GameObject spawnedProject;
    private float timer = 0f;

    // Add a flag so the spawner knows if it's supposed to be shooting
    private bool isFiring = false;

    void Update()
    {
        // Handle rotation (Consider multiplying by Time.deltaTime here if you want frame-rate independent spinning)
        if (spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        }

        // Only count up the timer and fire IF the boss has told us to
        if (isFiring)
        {
            timer += Time.deltaTime;
            if (timer >= FiringRate)
            {
                FireProjectile();
                timer = 0; // Reset timer
            }
        }
    }

    // Public method so BossMove can trigger it
    public void StartFiring()
    {
        isFiring = true;
        timer = FiringRate; // Optional: Set timer to FiringRate so it shoots instantly when stopping
    }

    // Public method so BossMove can turn it off
    public void StopFiring()
    {
        isFiring = false;
        timer = 0f; // Reset the timer for the next wave
    }

    // Renamed from StartFiring to avoid confusion with the public toggle method
    private void FireProjectile()
    {
        spawnedProject = Instantiate(Projectile, transform.position, Quaternion.identity);

        // Grab the script and assign the values
        Projectiles projScript = spawnedProject.GetComponent<Projectiles>();
        if (projScript != null)
        {
            projScript.Speed = speed;
            projScript.ProjectileLife = ProjectileLife;
        }

        spawnedProject.transform.rotation = transform.rotation;
    }
}
