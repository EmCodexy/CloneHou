using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene("SampleScene");
        }
     else if(Input.GetKey(KeyCode.Space))
        {
            Application.Quit();
            Debug.Log("bye bye!");
        }
    }
}
