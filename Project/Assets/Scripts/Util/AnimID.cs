using UnityEngine;

namespace AnimId
{
    public static class PlayerAnimId
    {
        public static readonly int s_Look_X = Animator.StringToHash("Look X");
        public static readonly int s_Look_Y = Animator.StringToHash("Look Y");
        public static readonly int s_RetrieveReady = Animator.StringToHash("RetrieveReady");
        public static readonly int s_Retrieve = Animator.StringToHash("Retrieve");
        public static readonly int s_Roll = Animator.StringToHash("Roll");
        public static readonly int s_ShootReady = Animator.StringToHash("ShootReady");
        public static readonly int s_Speed = Animator.StringToHash("Speed");
        public static readonly int s_Shoot = Animator.StringToHash("Shoot");
    }
}