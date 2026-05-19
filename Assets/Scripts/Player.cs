using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int startHp;
    int HP;
    public float DamageCooldown;
    float DamageTimer;

    void Start()
    {
        HP = startHp;
    }

    void Update()
    {
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

        if(HP <= 0 )
        {
            SceneManager.LoadScene("Gameover");
        }
    }
}