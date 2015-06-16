using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float speed = 80.0f;

    private Vector2 vector = Vector2.up;

    public Vector2 Vector
    {
        set
        {
            vector = value;
            vector.Normalize();
        }

        get
        {
            return vector;   
        }
    }

    void Update()
    {
        transform.Translate(vector * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Destroy(gameObject);
    }
}
