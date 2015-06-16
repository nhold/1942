using UnityEngine;
using System.Collections.Generic;

public class Scenery : MonoBehaviour 
{
    [SerializeField] private float speed;
	[SerializeField] private List<Sprite> sprites;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites.GetRandomObject();
    }

    void Update()
    {
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }
}
