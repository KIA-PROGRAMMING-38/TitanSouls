using AnimId;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSnowballBehaviour : StateMachineBehaviour
{
    private Yeti _boss;
    private float nextFireTime = 0.3f; // ´ÙÀ½ ´«µ¢ÀÌ ¹ß»ç ½Ã°£
    private int currentSnowCount = 0; // ÇöÀç ´«µ¢ÀÌ ¹ß»ç È½¼ö

    public float fireRate = 0.2f; // ´«µ¢ÀÌ ¹ß»ç °£°Ý
    public int maxSnowCount = 4; // ÃÖ´ë ´«µ¢ÀÌ ¹ß»ç È½¼ö
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boss = animator.GetComponent<Yeti>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentSnowCount < maxSnowCount && Time.time >= nextFireTime)
        {
            _boss.ShootSnow();
            nextFireTime = Time.time + fireRate;
            ++currentSnowCount;
        }

        if (currentSnowCount == maxSnowCount)
        {
            animator.SetTrigger(PlayerAnimId.s_IsRoll);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ¹ß»ç È½¼ö ÃÊ±âÈ­
        currentSnowCount = 0;
    }
}
