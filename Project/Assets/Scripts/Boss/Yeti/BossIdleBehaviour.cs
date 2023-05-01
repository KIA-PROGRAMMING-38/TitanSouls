using AnimId;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleBehaviour : StateMachineBehaviour
{
    private float elapsedtime;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsedtime += Time.deltaTime;

        if (elapsedtime >= 3.0f)
        {
            animator.SetTrigger(PlayerAnimId.s_IsSnowball);
            elapsedtime = 0;
        }
    }
}
