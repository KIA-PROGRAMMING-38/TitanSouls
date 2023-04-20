using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour
{
    private PlayerInput _playerInput;
    private Vector2 _zeroVec = Vector2.zero;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerInput = animator.GetComponent<PlayerInput>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_playerInput.InputVec != _zeroVec )
        {
            animator.SetFloat("Horizontal", _playerInput.InputVec.x);
            animator.SetFloat("Vertical", _playerInput.InputVec.y);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
