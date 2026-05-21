using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    [SerializeField]
    private float LoadingDelay = 10f;

    [SerializeField]
    private string ScneneName;

    private float timeElapsed;


    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > LoadingDelay)
        {
            SceneManager.LoadScene(ScneneName);
        }
    }

   
}
