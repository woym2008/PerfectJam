using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerJumpState : IPlayerState
    {
        Player m_Player;

        public PlayerJumpState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_JumpSpeed = m_Player.JumpStartSpeed;
            m_Player.m_Man.ShowAnimation("Anim_MuscleMan_Jump");
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Jump");

            //跳跃会取消掉攻击
            m_Player.m_GirlFSM.SetState(new GirlWaitState(m_Player));

            SFXPlayerManager.getInstance.CreateSFX("addspeed");
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_Player.Jump();

            m_Player.Move(Vector3.zero);

            if(m_Player.m_JumpSpeed <= 0.0f)
            {
                m_Player.m_FSM.SetState(new PlayerDownState(m_Player));
            }

            if(Input.GetKeyDown(KeyCode.K))
            {
                m_Player.m_GirlFSM.SetState(new GirlReadyFishAttackState(m_Player));
            }
        }

        public string StateName()
        {
            return "JumpState";
        }
    }
}
