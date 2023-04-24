using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rigidBody;

    private PlayerController _playerController;
    private float force = 35.0f; // �÷��̾��� ������ �� ����

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ������ ����� ����Ǵ� ��ŭ ������ �̵�
        _rigidBody = animator.GetComponent<Rigidbody2D>();
        _playerController = animator.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        _rigidBody.AddForce(_playerController.lookDirection * force); // �÷��̾��� ������ ������    

        _rigidBody.AddForce(_playerController.lookDirection * force);     

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
