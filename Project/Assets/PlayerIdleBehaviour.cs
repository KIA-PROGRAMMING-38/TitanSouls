using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : PlayerStateBehaviour
{
    private Vector2 _zeroVec = Vector2.zero;
    private bool isFireArrow = false;

    // 첫 번째 업데이트 프레임에서 호출
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // 첫 번째 프레임과 마지막 프레임을 제외한 각 업데이트 프레임에서 호출
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
           
        //if (controller.motionVec != _zeroVec)
        //{
        //    animator.SetFloat("Look X", controller.motionVec.x);
        //    animator.SetFloat("Look Y", controller.motionVec.y);
        //}

        //if (controller.motionVec != _zeroVec)
        //{
        //    animator.SetBool("Aiming", _playerInput.isAiming);
        //}
    }

    // 마지막 업데이트 프레임에 호출
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
