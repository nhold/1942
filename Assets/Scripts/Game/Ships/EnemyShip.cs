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
            SetMovementStrategy(new ZigZagMoveStrategy(Vector2.down, transform, 1.0f, 1.5f));
        else
            SetMovementStrategy(new StraightMoveStrategy(Vector2.down, transform));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);

        if(other.gameObject.tag != "Player")
            ScoreHandler.score.AddToScore(scoreValue);

        GameObject.Destroy(gameObject);
    }

}
