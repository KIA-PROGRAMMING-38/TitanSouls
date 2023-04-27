using AnimId;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRetrieveArrowBehaviour : StateMachineBehaviour
{
    private PlayerController _controller;
    private float _pullingPower = 5.0f;
    private Vector3 _leftVec = new Vector3(-1, 0, 0);
    private Vector3 _rightVec = new Vector3(1, 0, 0);
    private Vector3 _upVec = new Vector3(0, 1, 0);
    private Vector3 _downVec = new Vector3(0, -1, 0);
    private Vector3 _arrowDirection;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _controller = animator.GetComponent<PlayerController>(); 
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.C) && _controller.isGetArrow == false)
        {
            Arrow arrow = _controller.Arrow;
            arrow.IsRejection = false;

            if (_controller.lookDirection == _leftVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
            }

            if (_controller.lookDirection == _rightVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 270);
            }

            if (_controller.lookDirection == _downVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (_controller.lookDirection == _upVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            // 플레이어의 위치 - 화살의 위치
            _arrowDirection = _controller.gameObject.transform.position - arrow.transform.position;
            arrow.GetBackArrow(_arrowDirection, _pullingPower);
            animator.SetTrigger(PlayerAnimId.s_Retrieve);
            _controller.isGetArrow = true;

            return;
        }      
    }
}
