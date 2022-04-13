using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController_Four:EnemyController_Three
    {
        

        protected override IEnumerator Fire()
        {
            PoolManager.Release(projectile_two, muzzles[1].position, Quaternion.Euler(0, 0, -15));// Muzzle Left
            PoolManager.Release(projectile, muzzles[0].position, Quaternion.identity);        // Muzzle Middle
            PoolManager.Release(projectile_two, muzzles[2].position, Quaternion.Euler(0, 0, 15)); // Muzzle Right
            yield return new WaitForSeconds(status.FireInterval);
        }
    }
}
