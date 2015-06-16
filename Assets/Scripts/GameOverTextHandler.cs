using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameOverTextHandler : MonoBehaviour
{
    private Text textComponent;
    private string gameOverText = "Game Over!";
    private bool isStarted = false;
    private int i = 0;
    private float timer = 0.1f;

    void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    void StartGameOver()
    {
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            if (!isStarted)
                StartGameOver();
            else
            {
                if (textComponent.text != gameOverText)
                {
                    timer -= Time.unscaledDeltaTime;
                    if (timer <= 0)
                    {
                        textComponent.text += gameOverText[i];
                        i++;
                        timer = 0.1f;
                    }
                }
                else
                {
                    timer -= Time.unscaledDeltaTime;
                    if (timer <= 0)
                    {
                        foreach(Transform child in transform)
                        {
                            child.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
