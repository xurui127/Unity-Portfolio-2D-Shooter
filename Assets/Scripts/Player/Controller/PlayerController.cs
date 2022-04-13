using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Character
{
    public class PlayerController : CharacterController
    {
        //[SerializeField] private GameObject projectile;
        //[SerializeField] private Transform[] muzzles;
        [SerializeField] private Rigidbody2D rigid;

        private  bool pause =false;
        private Vector2 dirction = new Vector2();
        private PlayerStatus status; 
        public Vector2 Dirction { get => dirction; set => dirction = value; }
        private void Start()
        {
            status = GetComponent<PlayerStatus>();
        }

        private void Update()
        {
            OnMove();
            transform.position = CameraToPosition.instance.PlayerMovePositon(transform.position);

        }
        public override void OnMove()
        {
            Vector2 pos = new Vector2();
            pos += (dirction.normalized * status.Speed) * Time.fixedDeltaTime;
            rigid.velocity = pos;
        }
        public void OffMove()
        {
           rigid.velocity = Vector2.zero;
           //StopCoroutine(MovePositionLimit());
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
                PoolManager.Release(projectile, muzzles[1].position, Quaternion.identity);
                PoolManager.Release(projectile, muzzles[2].position, Quaternion.identity);
                yield return new WaitForSeconds(status.FireInterval);
            }
        }
        private IEnumerator MovePositionLimit()
        {
            while (true)
            {
                transform.position = CameraToPosition.instance.PlayerMovePositon(transform.position);
            }
            yield return null;
        }
    }
}
