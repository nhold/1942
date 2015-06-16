using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] protected Vector2 relativeSpawnPosition;

    private IWeapon weapon;

    public IWeapon Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    private void Start()
    {
        weapon = new SingleFireWeapon(reloadTime, projectilePrefab);
    }

    private void Update()
    {
        weapon.ReloadUpdate();
    }
}
