using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;

    [Header("Firing Settings")]
    public float fireRate = 0.15f;
    private float nextFire;

    [Header("Bullet Layout")]
    public int bulletCount = 4;        
    public float spreadAmount = 0.2f; 
    public bool useFanShape = false;  

    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
      
        float width = (bulletCount - 1) * spreadAmount;
        float startX = -width / 2f;

        for (int i = 0; i < bulletCount; i++)
        {
            
            Vector3 offset = new Vector3(startX + (i * spreadAmount), 0, 0);
            Vector3 spawnPos = transform.position + transform.right * offset.x;

            // Optional: Add a tiny rotation to each bullet for a "Fan" effect
            Quaternion bulletRotation = transform.rotation;
            if (useFanShape)
            {
                float angle = (i - (bulletCount - 1) / 2f) * 5f; // 5 degree spread
                bulletRotation *= Quaternion.Euler(0, 0, angle);
            }

            Instantiate(bulletPrefab, spawnPos, bulletRotation);
        }
    }

}
