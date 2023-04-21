using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkBehaviour : PlayerStateBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controller.motionVec != Vector2.zero)
        {
            controller.lookDirection.Set(controller.motionVec.x, controller.motionVec.y);
            controller.lookDirection.Normalize();
        }

        Vector2 position = rigid.position;
        position = position + controller.motionVec * controller.speed * Time.fixedDeltaTime;
        rigid.MovePosition(position);

        animator.SetFloat("Look X", controller.motionVec.x);
        animator.SetFloat("Look Y", controller.motionVec.y);
        animator.SetFloat("Speed", controller.motionVec.magnitude);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
