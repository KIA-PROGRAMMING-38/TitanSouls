using AnimId;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{
    // ù ��° ������Ʈ �����ӿ��� ȣ��
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // ù ��° �����Ӱ� ������ �������� ������ �� ������Ʈ �����ӿ��� ȣ��
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger(PlayerAnimId.s_Roll);
        }
    }

    // ������ ������Ʈ �����ӿ� ȣ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
