using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	void OnAnimationEnd()
    {
        GameObject.Destroy(gameObject);
    }
}
