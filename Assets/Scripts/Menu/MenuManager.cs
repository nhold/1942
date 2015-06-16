using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour 
{
    [SerializeField] private Animator OptionsPanel;
    [SerializeField] private Animator CreditsPanel;

	public void StartGame()
    {
        Application.LoadLevel("Game");
    }

    public void OpenOptions()
    {
        OptionsPanel.SetBool("BringIn", true);
    }

    public void CloseOptions(bool doSave)
    {
        OptionsPanel.SetBool("BringIn", false);
        if(doSave)
        {

        }
    }

    public void OpenCredits()
    {
        CreditsPanel.SetBool("BringIn", true);
    }

    public void CloseCredits()
    {
        CreditsPanel.SetBool("BringIn", true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
