using UnityEngine;
using UnityEngine.SceneManagement;

public class Choicemenu : MonoBehaviour
{

    private void Start()
    {
        Yes();
        no();
        quit();
    }
    void Yes()
    {
        SceneManager.LoadScene("StageTransition");
    }

    void no()
    {
        SceneManager.LoadScene("Start");
    }

    void quit()
    {
        Application.Quit();
    }
}
