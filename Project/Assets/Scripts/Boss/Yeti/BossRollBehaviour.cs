using AnimId;
using UnityEngine;

public class BossRollBehaviour : StateMachineBehaviour
{
    private Yeti _boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boss = animator.GetComponent<Yeti>();
        _boss.isRolling = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boss.MoveTowardsPlayer();

        if (stateInfo.normalizedTime >= 1.0f) // 구르기 애니메이션이 끝까지 진행된다면
        {
            _boss.rollCount++; // 구르기 횟수 증가

            if (_boss.rollCount >= _boss.maxRollCount)
            {
                animator.SetTrigger(PlayerAnimId.s_IsIdle);
                _boss.ResetRollCount();
            }

            else
            {
                animator.Play(stateInfo.fullPathHash, -1, 0); // 애니메이션을 다시 처음부터 재생 
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boss.isRolling = false;
    }
}


