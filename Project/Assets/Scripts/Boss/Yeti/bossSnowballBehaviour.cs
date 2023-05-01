using AnimId;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSnowballBehaviour : StateMachineBehaviour
{
    private Yeti _boss;
    private float nextFireTime = 0.3f; // ���� ������ �߻� �ð�
    private int currentSnowCount = 0; // ���� ������ �߻� Ƚ��

    public float fireRate = 0.2f; // ������ �߻� ����
    public int maxSnowCount = 4; // �ִ� ������ �߻� Ƚ��
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
        // �߻� Ƚ�� �ʱ�ȭ
        currentSnowCount = 0;
    }
}
