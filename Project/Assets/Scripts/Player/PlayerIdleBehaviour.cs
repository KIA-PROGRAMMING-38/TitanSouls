using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{
    private bool isGetArrow = true; // 화살을 가지고 있는지 아닌지를 저장

    // 첫 번째 업데이트 프레임에서 호출
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // 첫 번째 프레임과 마지막 프레임을 제외한 각 업데이트 프레임에서 호출
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Roll");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Aiming", true);
        }
    }

    // 마지막 업데이트 프레임에 호출
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
