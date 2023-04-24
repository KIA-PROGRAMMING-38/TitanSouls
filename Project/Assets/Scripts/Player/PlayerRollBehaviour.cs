using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rigidBody;
    private PlayerController playerController;
    private float force = 35.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 구르기 모션이 진행되는 만큼 앞으로 이동
        _rigidBody = animator.GetComponent<Rigidbody2D>();
        playerController = animator.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidBody.AddForce(playerController.lookDirection * force);     
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
