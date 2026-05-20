using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite EmptyHeart;
    public Sprite FullHeart;
    public Image[] health;


    public int startHp;
    int HP;
    public float DamageCooldown;
    float DamageTimer;

    //private Shield shield;
    void Start()
    {
        HP = startHp;

        //shield = GetComponentInChildren<Shield>();
    }

    void Update()
    {
        for (int i = 0; i < health.Length; i++)
        {
            if(i < HP)
            {
                health[i].enabled = true;
            }
            else
            {
                health[i].enabled = false;
            }
        }

        if (DamageTimer > 0)
            DamageTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check DamageTimer instead of Cooldown
        if (collision.CompareTag("EB") && DamageTimer <= 0)
        {
            HP -= 1;
            Debug.Log("HP: " + HP);
            DamageTimer = DamageCooldown;

            // Optional: Destroy the enemy bullet on hit
            Destroy(collision.gameObject);
        }
     
       

        //if(HP <= 0 )
        //{
        //    SceneManager.LoadScene("Gameover");
        //}
    }
}