using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerDownState : IPlayerState
    {
        Player m_Player;
        public PlayerDownState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_DownSpeed = m_Player.DownStartSpeed;

            m_Player.m_Man.ShowAnimation("Anim_MuscleMan_Down");
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Jump");
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_Player.DownLand();

            m_Player.Move(Vector3.zero);

            if (Input.GetKeyDown(KeyCode.K))
            {
                m_Player.m_GirlFSM.SetState(new GirlReadyFishAttackState(m_Player));
            }
        }

        public string StateName()
        {
            return "DownState";
        }
    }
}
