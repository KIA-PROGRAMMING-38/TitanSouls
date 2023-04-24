using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRetrieveArrowBehaviour : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Retrieve", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
