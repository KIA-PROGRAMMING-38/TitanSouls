using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : PlayerStateBehaviour
{
    private Vector2 _zeroVec = Vector2.zero;
    private bool isFireArrow = false;

    // ù ��° ������Ʈ �����ӿ��� ȣ��
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // ù ��° �����Ӱ� ������ �������� ������ �� ������Ʈ �����ӿ��� ȣ��
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

    // ������ ������Ʈ �����ӿ� ȣ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
