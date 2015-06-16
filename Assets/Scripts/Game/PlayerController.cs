using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private uint currentLives = 3;

    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float shootTimer = 0.5f;

    [SerializeField]
    private GameObject projectile = null;
    [SerializeField]
    private Vector2 relativeProjectileSpawnPosition;

    [SerializeField]
    private GameObject hitExplosion = null;
    [SerializeField]
    private GameObject explosion = null;

    [SerializeField]
    private KeyCode moveLeftKeyCode = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode moveRightKeyCode = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode moveForwardKeyCode = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode moveBackwardKeyCode = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode shootKeyCode = KeyCode.Space;
    [SerializeField]
    private KeyCode pauseKeyCode = KeyCode.P;

    public event Action<uint> OnLivesChanged;

    public uint Lives
    {
        get
        {
            return currentLives;
        }

        private set
        {
            currentLives = value;

            if (OnLivesChanged != null)
                OnLivesChanged(currentLives);
        }
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;   
        if (Input.GetKey(moveLeftKeyCode))
        {
            MoveLeft();
        }

        if (Input.GetKey(moveRightKeyCode))
        {
            MoveRight();
        }

        if (Input.GetKey(moveForwardKeyCode))
        {
            MoveForward();
        }

        if (Input.GetKey(moveBackwardKeyCode))
        {
            MoveBackward();
        }

        if (Input.GetKeyDown(shootKeyCode))
        {
            Shoot();
        }

        if(Input.GetKeyDown(pauseKeyCode))
        {
            Time.timeScale = (int)Time.timeScale ^ 1;
        }
    }

    void Shoot()
    {
        if (projectile && shootTimer <= 0)
        {
            Instantiate(projectile, transform.position + (Vector3)relativeProjectileSpawnPosition, Quaternion.identity);
            shootTimer = 0.5f;
        }
    }

    void MoveLeft()
    {
        var movementAmount = -speed * Time.deltaTime;

        if(transform.position.x + movementAmount > -290)
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void MoveRight()
    {
        var movementAmount = speed * Time.deltaTime;

        if (transform.position.x + movementAmount < 290)
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void MoveForward()
    {
        var movementAmount = speed * Time.deltaTime;

        if (transform.position.y + movementAmount < 218)
            transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    void MoveBackward()
    {
        var movementAmount = -speed * Time.deltaTime;

        if (transform.position.y + movementAmount > -220)
            transform.Translate(0.0f, movementAmount, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        if (hitExplosion)
        {
            var direction = other.transform.position - transform.position;
            direction /= 2;
            GameObject.Instantiate(hitExplosion, transform.position + direction, Quaternion.identity);
        }

        if (Lives <= 0)
        {
            transform.position = new Vector3(100.0f, 100.0f, 100.0f);
            PlayerPrefs.Save();
            Lives = 0;
            Time.timeScale = 0;
        }
        else
        {
            Lives--;
        }

        if (explosion)
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);

    }


}
