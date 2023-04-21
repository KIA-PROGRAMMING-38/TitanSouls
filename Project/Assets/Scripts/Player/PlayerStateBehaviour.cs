using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBehaviour : StateMachineBehaviour
{
    protected PlayerController controller;
    protected Rigidbody2D rigid;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<PlayerController>();
        rigid = animator.GetComponent<Rigidbody2D>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}


