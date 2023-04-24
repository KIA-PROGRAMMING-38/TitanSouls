using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{
    private bool isGetArrow = true; // ȭ���� ������ �ִ��� �ƴ����� ����

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
            animator.SetTrigger("Roll");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Aiming", true);
        }
    }

    // ������ ������Ʈ �����ӿ� ȣ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
