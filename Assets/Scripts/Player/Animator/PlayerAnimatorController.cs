using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerController playerController;
    


    protected void Animate()
    {
        anim.SetFloat("ver", playerController.Dirction.x);
        anim.SetFloat("hor", playerController.Dirction.y);
    }
    private void FixedUpdate()
    {
        Animate();
    }
}
