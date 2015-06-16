using UnityEngine;
using System.Collections;

public class EnemyShip : Projectile
{
    [SerializeField]
    private GameObject explosion = null;
    [SerializeField]
    private float shootTimerCount = 1.5f;
    [SerializeField]
    private uint scoreValue = 20;

    void Start()
    {
        SetMovementStrategy(new StraightMoveStrategy(Vector2.down, transform));
    }

    void OnBecameInvisible()
    {
        if (transform.position.y < 0)
            GameObject.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
        ScoreHandler.currentScore += scoreValue;

        GameObject.Destroy(gameObject);
    }

}
