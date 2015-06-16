using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private GameObject projectile = null;
    [SerializeField]
    private Vector2 relativeProjectileSpawnPosition;

    [SerializeField]
    private GameObject explosion = null;
    [SerializeField]
    private float shootTimerCount = 1.5f;
    [SerializeField]
    private uint scoreValue = 20;

    private bool canShoot = true;
    private float shootTimer = 0.0f;
    private GameObject playerObject = null;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        shootTimer += Time.deltaTime;

        
            Shoot();
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

    void Shoot()
    {
        if (projectile && shootTimer > shootTimerCount)
        {
            int choice = Random.Range(0, 12);
            if (choice == 1)
            {
                if (playerObject)
                {
                    GameObject newGameObject = Instantiate(projectile, transform.position + (Vector3)relativeProjectileSpawnPosition, Quaternion.identity) as GameObject;
                    Projectile newProjectile = newGameObject.GetComponent<Projectile>();
                    newProjectile.Vector = newGameObject.transform.position - playerObject.transform.position;
                }
            }
            else if(choice > 5)
            {
                //Instantiate(projectile, transform.position + (Vector3)relativeProjectileSpawnPosition, Quaternion.identity);
            }
            shootTimer = 0.0f;
        }
    }
}
