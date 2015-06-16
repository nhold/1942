using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PauseTextHandler : MonoBehaviour 
{
    private Text textComponent;

    void Awake()
    {
        textComponent = GetComponent<Text>();
    }
	// Update is called once per frame
	void Update () 
    {
	    if(Time.timeScale == 0)
        {
            textComponent.text = "Paused";
        }
        else
        {
            textComponent.text = "";
        }
	}
}
