using UnityEngine;

public class ShieldProtect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object entering the shield has the Enemy Bullet tag
        if (collision.CompareTag("EB"))
        {
            // Directly destroy the bullet GameObject right here!
            Destroy(collision.gameObject);

            // Optional: You can trigger a small shield impact effect or sound here later
            Debug.Log("Shield absorbed an enemy bullet!");
        }
    }
}
