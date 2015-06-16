using UnityEngine;
using System.Collections;

public class MouseWeaponController : WeaponController 
{
	
	void Update () 
    {
        
	    if(Input.GetMouseButtonDown(0))
        {
            Weapon.Shoot(new StraightMoveStrategy(Vector2.up, null), (Vector2)transform.position + relativeSpawnPosition);
        }
        
        Weapon.ReloadUpdate();
	}
}
