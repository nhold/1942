using UnityEngine;
using System.Collections;

public class SmartAIWeaponController : WeaponController
{
    private GameObject playerObject;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        int choice = Random.Range(0, 12);

        if (choice == 1)
        {
            if (playerObject)
            {
                Weapon.Shoot(new StraightMoveStrategy(playerObject.transform.position-transform.position, null), (Vector2)transform.position + relativeSpawnPosition);
            }
        }

        Weapon.ReloadUpdate();
    }
}
