using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingBehaviour : StateMachineBehaviour
{
    Weapon weapon;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        weapon = animator.GetComponent<Weapon>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Aiming", false);
            // isGetArrow = true;
            // weapon.Shoot();
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
