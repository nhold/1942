using UnityEngine;
using System.Collections;

public class DestroyOnAnimationEnd : MonoBehaviour 
{
	void OnAnimationEnd()
    {
        GameObject.Destroy(gameObject);
    }
}
