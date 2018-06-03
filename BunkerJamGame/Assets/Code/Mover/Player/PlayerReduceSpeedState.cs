using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerReduceMoveState : IPlayerState
    {
        Player m_Player;

        public PlayerReduceMoveState(Player pPlayer)
        {
            m_Player = pPlayer;
            m_Player.m_Man.ShowAnimation("Anim_MuscleMan_Move");
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Normal");
        }

        public void Enter()
        {
            m_Player.m_Speed = -m_Player.MaxSpeed;
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                m_Player.m_Speed = m_Player.MaxSpeed;
                m_Player.m_FSM.SetState(new PlayerStandState(m_Player));
            }

            m_Player.Move(Vector3.zero);

            if (Input.GetKey(KeyCode.F))
            {
                m_Player.m_FSM.SetState(new PlayerJumpState(m_Player));
            }
        }

        public string StateName()
        {
            return "ReduceMoveState";
        }

    }
}

