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

        if (stateInfo.normalizedTime >= 1.0f) // ������ �ִϸ��̼��� ������ ����ȴٸ�
        {
            _boss.rollCount++; // ������ Ƚ�� ����

            if (_boss.rollCount >= _boss.maxRollCount)
            {
                animator.SetTrigger(PlayerAnimId.s_IsIdle);
                _boss.ResetRollCount();
            }

            else
            {
                animator.Play(stateInfo.fullPathHash, -1, 0); // �ִϸ��̼��� �ٽ� ó������ ��� 
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boss.isRolling = false;
    }
}


