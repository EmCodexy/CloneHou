using TMPro;
using UnityEngine;


public class ScoreUI : MonoBehaviour
{
    
    public static float Score;
    public TextMeshProUGUI Points;

    private void Start()
    {
        Score = 50;
    }
    private void FixedUpdate()
    {
        Points.text = Mathf.FloorToInt(Score).ToString();
    }

    public static void AddScore()
    {
        Score++;
        Debug.Log("you've " + Score + " points! ");
    }

    public static void SubtrackScore(float drainSpeed)
    {
        Score -= drainSpeed * Time.deltaTime;

        if (Score < 0)
        {
            Score = 0;
        }
    }
}
