using System;
using UnityEngine;

public interface IWeapon
{
    float ReloadTime
    {
        get;
        set;
    }

    Projectile ProjectilePrefab
    {
        get;
        set;
    }

    void Shoot(IMoveStrategy strategy, Vector2 spawnPosition);

    void ReloadUpdate();
}

