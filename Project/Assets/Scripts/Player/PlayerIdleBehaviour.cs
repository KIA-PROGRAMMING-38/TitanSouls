using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{

    private PlayerController controller;
    private WeaponController _weapon;


    // ù ��° ������Ʈ �����ӿ��� ȣ��
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<PlayerController>();
        // base.OnStateEnter(animator, stateInfo, layerIndex);
        _weapon = controller.weapon.GetComponent<WeaponController>();
    }

    // ù ��° �����Ӱ� ������ �������� ������ �� ������Ʈ �����ӿ��� ȣ��
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

    // ������ ������Ʈ �����ӿ� ȣ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
