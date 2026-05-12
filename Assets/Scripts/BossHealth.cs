using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;

    // This is the function the bullet was looking for!
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Boss HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add explosion effects here later!
        Destroy(gameObject);
    }
}
