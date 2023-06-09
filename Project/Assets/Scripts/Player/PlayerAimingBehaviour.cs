using AnimId;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingBehaviour : StateMachineBehaviour
{
    private PlayerController _controller;
    private Vector3 _leftVec = new Vector3(-1, 0, 0);
    private Vector3 _rightVec = new Vector3(1, 0, 0);
    private Vector3 _upVec = new Vector3(0, 1, 0);
    private Vector3 _downVec = new Vector3(0, -1, 0);
    private float _chargingTime;
    private float _currentPower;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _controller = animator.GetComponent<PlayerController>();
        _chargingTime = 0f;
        _currentPower = 0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyUp(KeyCode.C) && _controller.isGetArrow)
        {
            Arrow arrow = _controller.Arrow;

            if (_controller.lookDirection == _leftVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 270);
            }

            if (_controller.lookDirection == _rightVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
            }

            if (_controller.lookDirection == _upVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (_controller.lookDirection == _downVec)
            {
                arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            arrow.ShootArrow(_controller.lookDirection, _currentPower); 
            animator.SetTrigger(PlayerAnimId.s_Shoot);
            _controller.isGetArrow = false;

            return;
        }

        _currentPower = Mathf.Lerp(0f, _controller.MaxPower, _chargingTime / _controller.ChargingDuration);
        _chargingTime += Time.deltaTime;
    }
}
