using TMPro;
using UnityEngine;


public class ScoreUI : MonoBehaviour
{
    public static float Score;
    public TextMeshProUGUI Points;

    private void Start()
    {
        Score = 0;
    }
    private void FixedUpdate()
    {
        Points.text = Score.ToString();
    }

    public static void AddScore()
    {
        Score++;
        Debug.Log("you've " + Score + " points! ");
    }

    public static void SubtrackScore()
    {
        Score -= 1 * Time.deltaTime;
    }
}
