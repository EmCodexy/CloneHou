using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{

    public GameObject pause;
    public static bool IsPaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                pauseGame();
            }
        }

       if(Input.GetKey(KeyCode.Alpha1) && IsPaused)
        {
            SceneManager.LoadScene("Start");
            Debug.Log("see you around!");
            
        }
    }

    public void pauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

    
}
