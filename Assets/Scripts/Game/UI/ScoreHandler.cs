using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreHandler : MonoBehaviour 
{
    [SerializeField]
    private Text HighScore;
    public static Score score;
    private Text textComponent;

    void Awake()
    {
        score = new Score();
        score.OnScoreChanged += OnScoreChanged;
        textComponent = GetComponent<Text>();
    }

    void OnScoreChanged(uint newScore)
    {
        textComponent.text = "Score" + "\n" + newScore.ToString();
        
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);

        if (score.CurrentScore > oldHighscore)
        {
            PlayerPrefs.SetInt("highscore", (int)score.CurrentScore);
            HighScore.text = "High Score" + "\n" + score.CurrentScore.ToString();
        }
        else
        {

            HighScore.text = "High Score" + "\n" + oldHighscore.ToString();
        }
 
    }

}
