using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private string NextlevelAfter;

    public int health;
    private float LoadingDelay = 1f;
    private float timeElapsed;

    // This is the function the bullet was looking for!
    public void TakeDamage(int damage)
    {
        //if(gameObject.CompareTag("PB"))
        {
            health -= damage;
            Debug.Log("Boss HP: " + health);
            ScoreUI.AddScore();
        }
    
        if (health <= 0)
        {
            Die();
        }
    }

   void Die()
    {
        
        // Add explosion effects here later!
        Destroy(gameObject);
            SceneManager.LoadScene(NextlevelAfter);

    }
}
