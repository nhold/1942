using UnityEngine;
using System.Collections;

public class PauseOnInput : MonoBehaviour 
{
	[SerializeField] KeyCode pauseKeyCode;

    private void Update()
    {
        if(Input.GetKeyUp(pauseKeyCode))
        {
            Time.timeScale *= -1;
        }
    }
}
