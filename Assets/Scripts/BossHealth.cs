using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private string NextlevelAfter;

    public int health;
    private float LoadingDelay = 1f;
    private float timeElapsed;

 
    public void TakeDamage(int damage)
    {
       
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
        
       
        Destroy(gameObject);
            SceneManager.LoadScene(NextlevelAfter);

    }
}
