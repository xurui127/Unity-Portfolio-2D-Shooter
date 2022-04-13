using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController_High : EnemyController
    {
        private enum FireMode { Mode_One, Mode_Two };

        FireMode fireMode;
        [SerializeField]private int projectileCounter;
       
        [SerializeField] protected GameObject projectile_two;
        [SerializeField] protected  int projectileNums;
        protected override IEnumerator Fire()
        {
            while (true)
            {

                ShootType();

                yield return new WaitForSeconds(status.FireInterval);
            }
        }

        protected virtual void ShootType()
        {
          
            switch (fireMode)
            {

                case FireMode.Mode_One:
                    projectileCounter++;
                    ModeSwitch(FireMode.Mode_Two, projectileNums);
                    PoolManager.Release(projectile, muzzles[1].position, Quaternion.identity);
                    break;
                case FireMode.Mode_Two:
                    projectileCounter++;

             
            PoolManager.Release(projectile_two, muzzles[1].position, Quaternion.Euler(0, 0, -15));// Muzzle Left
            PoolManager.Release(projectile_two, muzzles[0].position, Quaternion.identity);        // Muzzle Middle
            PoolManager.Release(projectile_two, muzzles[1].position, Quaternion.Euler(0, 0, 15)); // Muzzle Right
                    ModeSwitch(FireMode.Mode_One, projectileNums);
                    break;
            default:
                    break;
        }
    }

        private void ModeSwitch(FireMode _fireMode, int _projectileNum)
        {
            if (projectileCounter >= _projectileNum)
            {
                projectileCounter = 0;
                fireMode = _fireMode;
            }
        }
    }
}
