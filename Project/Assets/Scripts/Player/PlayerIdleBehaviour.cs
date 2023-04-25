using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{

    private PlayerController controller;
    private WeaponController _weapon;


    // 첫 번째 업데이트 프레임에서 호출
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<PlayerController>();
        // base.OnStateEnter(animator, stateInfo, layerIndex);
        _weapon = controller.weapon.GetComponent<WeaponController>();
    }

    // 첫 번째 프레임과 마지막 프레임을 제외한 각 업데이트 프레임에서 호출
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Roll");
        }

        if (Input.GetKey(KeyCode.C) && _weapon.isGetArrow == true)
        {
            animator.SetBool("Aiming", true);
        }

        if (Input.GetKey(KeyCode.C) && _weapon.isGetArrow == false)
        {
            animator.SetBool("Retrieve", true);
        }
    }

    // 마지막 업데이트 프레임에 호출
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
