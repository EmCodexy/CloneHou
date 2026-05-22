using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
 
    public GameObject shield;
    public float PointsSpend = 15f;
    // Update is called once per frame
    void Start()
    {
        if (shield != null)
        {
            shield.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            shield.SetActive(!shield.activeSelf);
           
            //transform.position = new Vector2(11,11);
            //ScoreUI.
        }
        //else
        //{
        //    shield.SetActive(false);
        //    //transform.position = new Vector2(0, 0);

        //}


        if (shield.activeSelf)
        {
            
            ScoreUI.SubtrackScore(PointsSpend);

     
            if (ScoreUI.Score <= 0)
            {
                shield.SetActive(false);
                Debug.Log("Shield deactivated: Out of score!");
            }
        }
    }




}
