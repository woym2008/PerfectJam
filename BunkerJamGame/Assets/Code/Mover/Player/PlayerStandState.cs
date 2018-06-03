using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerStandState : IPlayerState
    {
        Player m_Player;
        public PlayerStandState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_Man.ShowAnimation("Anim_MuscleMan_Move");
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Normal");

            m_Player.m_Speed = 0;
        }

        public void Execute(float dt)
        {
            if(Input.GetKey(KeyCode.D))
            {
                m_Player.m_FSM.SetState(new PlayerMoveState(m_Player));
            }
            else if(Input.GetKey(KeyCode.A))
            {
                m_Player.m_FSM.SetState(new PlayerReduceMoveState(m_Player));
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                m_Player.m_FSM.SetState(new PlayerReadyJumpState(m_Player));
            }
        }

        public void Exit()
        {
            ;
        }

        public string StateName()
        {
            return "StandState";
        }
    }
}

