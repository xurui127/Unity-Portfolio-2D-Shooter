using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyController : CharacterController
    {

        [SerializeField] protected EnemyStatus status;
        [SerializeField] CameraToPosition cameraToPosition;
        [SerializeField] private EnemyManager enemyManager;
        protected const float distance = 0.5f;
        protected const float paddingX = 0.5f;
        protected const float paddingY = 0.5f;



        protected void OnEnable()
        {
           transform.position = CameraToPosition.instance.RandomSpawnPostion(0, 0);
            OnMove();
            OnFire();
        }

        protected void OnDisable()
        {
            OffFire();
            OffMove();
        }
        protected void Start()
        {

        }
        protected IEnumerator Move()
        {

            Vector3 targetPostion = CameraToPosition.instance.GetRandomHalfPosition(paddingX, paddingY);

            while (gameObject.activeSelf)
            {

                if (Vector3.Distance(transform.position, targetPostion) > distance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPostion, status.Speed * Time.deltaTime);
                }
                else
                {
                    targetPostion = CameraToPosition.instance.GetRandomHalfPosition(paddingX, paddingY);

                }

                //  yield return new WaitForSeconds(status.MoveInterval);
                yield return null;
            }
        }

        public override void OnMove()
        {
            StartCoroutine(nameof(Move));
        }
        public void OffMove()
        {
            StopCoroutine(nameof(Move));
        }
        public override void OnFire()
        {
            StartCoroutine(nameof(Fire));
        }
        public override void OffFire()
        {
            StopCoroutine(nameof(Fire));
        }

        protected override IEnumerator Fire()
        {
            while (true)
            {
                PoolManager.Release(projectile, muzzles[0].position, Quaternion.identity);

                yield return new WaitForSeconds(status.FireInterval);
            }
        }

    }
}