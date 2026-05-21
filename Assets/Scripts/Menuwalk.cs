using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuwalk : MonoBehaviour
{
    [SerializeField]
    private string StageTransition;


    private void Start()
    {
        Time.timeScale  = 1;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(StageTransition);
        }
        
    }
}
