using UnityEngine;
using System.Collections;

public class EnemyShip : Projectile
{
    [SerializeField] private GameObject explosion = null;
    [SerializeField] private uint scoreValue = 20;

    void Start()
    {
        int i = Random.Range(0, 4);
        if(i == 1)
            SetMovementStrategy(new ZigZagMoveStrategy(Vector2.down, transform, 1.0f, 5.0f));
        else
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

        if(other.gameObject.GetComponent<Projectile>() != null)
            ScoreHandler.score.AddToScore(scoreValue);

        GameObject.Destroy(gameObject);
    }

}
