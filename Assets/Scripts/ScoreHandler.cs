using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreHandler : MonoBehaviour 
{
    [SerializeField]
    private Text HighScore;
    public static uint currentScore = 0;
    private Text textComponent;

    void Awake()
    {
        currentScore = 0;
        textComponent = GetComponent<Text>();
    }

    void Update()
    {
        textComponent.text = "Score" + "\n" + currentScore.ToString();
        
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);

        if (currentScore > oldHighscore)
        {
            PlayerPrefs.SetInt("highscore", (int)currentScore);
            HighScore.text = "High Score" + "\n" + currentScore.ToString();
        }
        else
        {

            HighScore.text = "High Score" + "\n" + oldHighscore.ToString();
        }
 
    }

}
