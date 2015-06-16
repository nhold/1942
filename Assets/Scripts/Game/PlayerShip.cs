using UnityEngine;
using System.Collections;
using System;

public class PlayerShip : Ship
{
    [SerializeField] private Score score;
    [SerializeField] private uint currentLives = 3;

    [SerializeField] private GameObject hitExplosion = null;
    [SerializeField] private GameObject explosion = null;

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

    private void Start()
    {
        SetMovementStrategy(new KeyboardInputMoveStrategy(Vector2.zero, transform));
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
