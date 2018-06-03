using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerReadyJumpState : IPlayerState
    {
        Player m_Player;

        public PlayerReadyJumpState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_JumpSpeed = m_Player.JumpStartSpeed;
            m_Player.m_Man.ShowAnimation("Anim_MuscleMan_ReadyJump");
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Jump");

            //跳跃会取消掉攻击
            //m_Player.m_GirlFSM.SetState(new GirlWaitState(m_Player));
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
        }

        public string StateName()
        {
            return "PlayerReadyJumpState";
        }
    }
}

