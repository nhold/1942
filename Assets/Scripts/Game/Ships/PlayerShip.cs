using UnityEngine;
using System.Collections;
using System;

public class PlayerShip : Projectile
{
    [SerializeField] private GameObject hitExplosion = null;
    [SerializeField] private GameObject explosion = null;

    private void Start()
    {
        if (PlayerPrefs.GetInt("isMouseInputMovement") == 1)
        {
            SetMovementStrategy(new SmoothMouseInputMoveStrategy(transform));
            GetComponent<MouseWeaponController>().enabled = true;
        }
        else
        {
            SetMovementStrategy(new KeyboardInputMoveStrategy(Vector2.up, transform));
            GetComponent<KeyboardWeaponController>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (hitExplosion)
        {
            var direction = other.transform.position - transform.position;
            direction /= 2;
            GameObject.Instantiate(hitExplosion, transform.position + direction, Quaternion.identity);
            life.RemoveLife();
            if (life.Count == 0)
            {

                GameObject.Destroy(gameObject);
            }
        }

        if (explosion)
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
