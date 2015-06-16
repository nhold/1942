using UnityEngine;
using System.Collections;

public class KeyboardWeaponController : WeaponController 
{
    [SerializeField] private KeyCode shootKeyCode = KeyCode.Space;
	
	void Update () 
    {
	    if(Input.GetKeyDown(shootKeyCode))
        {
            Weapon.Shoot(new StraightMoveStrategy(Vector2.up, null), (Vector2)transform.position + relativeSpawnPosition);
        }

        Weapon.ReloadUpdate();
	}
}
