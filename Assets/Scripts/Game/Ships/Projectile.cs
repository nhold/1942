using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Life))]
[RequireComponent(typeof(Moveable))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour 
{
    [SerializeField] private Moveable moveable;
    [SerializeField] protected Life life;

    public Life Life
    {
        get
        {
            return life;
        }

        private set
        {
            life = value;
        }
    }

    public void SetMovementStrategy(IMoveStrategy moveStrategy)
    {
        if(moveable)
            moveable.MoveStrategy = moveStrategy;
    }

    private void Awake()
    {
        if(!life)
        {
            life = GetComponent<Life>();
        }

        if (!moveable)
        {
            moveable = GetComponent<Moveable>();
        }
    }

    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Destroy(gameObject);
    }
}
