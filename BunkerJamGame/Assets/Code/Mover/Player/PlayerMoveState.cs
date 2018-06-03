using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerMoveState : IPlayerState
    {
        Player m_Player;

        public PlayerMoveState(Player pPlayer)
        {
            m_Player = pPlayer;
            m_Player.m_Man.ShowAnimation("Anim_MuscleMan_Rush");
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Rush");
        }

        public void Enter()
        {
            m_Player.m_Speed = m_Player.MaxSpeed;
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.D))
            {
                m_Player.m_Speed = m_Player.MaxSpeed;
                m_Player.m_FSM.SetState(new PlayerStandState(m_Player));
            }

            m_Player.Move(Vector3.zero);

            if(Input.GetKey(KeyCode.F))
            {
                m_Player.m_FSM.SetState(new PlayerReadyJumpState(m_Player));
            }
        }

        public string StateName()
        {
            return "MoveState";
        }
    }
}

