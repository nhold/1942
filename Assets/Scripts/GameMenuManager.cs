using UnityEngine;
using System.Collections;

public class GameMenuManager : MonoBehaviour 
{
	public void RetryGame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("Game");
    }

    public void CancelGame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("Menu");
    }
}
