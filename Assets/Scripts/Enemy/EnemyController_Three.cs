using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController_Three : EnemyController_High
    {
       
      
        protected override IEnumerator Fire()
        {
            while (true)
            {
                PoolManager.Release(projectile_two, muzzles[1].position, Quaternion.Euler(0, 0, -25));// Muzzle Left
                PoolManager.Release(projectile, muzzles[1].position, Quaternion.Euler(0, 0, 0));        // Muzzle Middle
                PoolManager.Release(projectile_two, muzzles[1].position, Quaternion.Euler(0, 0, 25)); // Muzzle Right
                yield return new WaitForSeconds(status.FireInterval);
            }
        }


    }
}