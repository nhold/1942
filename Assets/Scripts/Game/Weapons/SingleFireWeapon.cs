using UnityEngine;
using System;

[Serializable]
public class SingleFireWeapon : IWeapon 
{
    [SerializeField] private float reloadTime;
    [SerializeField] private Projectile projectilePrefab;

    private float reloadTimer;
    private bool canShoot;

    public SingleFireWeapon(float reloadTime, Projectile projectilePrefab)
    {
        this.reloadTime = reloadTime;
        this.projectilePrefab = projectilePrefab;
        reloadTimer = reloadTime;
        canShoot = true;
    }

    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
        set
        {
            reloadTime = value;
        }
    }

    public Projectile ProjectilePrefab
    {
        get
        {
            return projectilePrefab;
        }
        set
        {
            projectilePrefab = value;
        }
    }

    public void Shoot(IMoveStrategy moveStrategy, Vector2 spawnPosition)
    {
        if (canShoot)
        {
            Projectile newGameObject = GameObject.Instantiate(projectilePrefab, spawnPosition, Quaternion.identity) as Projectile;

            moveStrategy.ControlledTransform = newGameObject.transform;
            newGameObject.SetMovementStrategy(moveStrategy);
            
            reloadTimer = 0;
            canShoot = false;
        }
    }

    public void ReloadUpdate()
    {
        if(reloadTimer >= reloadTime)
        {
            canShoot = true;
            return;
        }

        reloadTimer += Time.deltaTime;
    }
}
