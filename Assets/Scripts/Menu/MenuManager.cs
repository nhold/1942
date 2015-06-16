using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour 
{
    [SerializeField] private Animator OptionsPanel;
    [SerializeField] private Animator CreditsPanel;

    [SerializeField] private Toggle keyBoardToggle;
    [SerializeField] private Toggle mouseToggle;

    private bool isMouseInput = false;

    void Awake()
    {
        bool value = PlayerPrefs.GetInt("isMouseInputMovement") == 1;
        mouseToggle.isOn = value;
        keyBoardToggle.isOn = !value;
    }

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
            PlayerPrefs.SetInt("isMouseInputMovement", Convert.ToInt32(isMouseInput));
        }
    }

    public void SetMouseInput()
    {
        isMouseInput = !isMouseInput;
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
