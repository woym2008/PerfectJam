using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class GirlAirWaitState : IPlayerState
    {
        Player m_Player;

        public GirlAirWaitState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            //m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Normal");
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            //if (Input.GetKeyDown(KeyCode.K))
            //{
            //    m_Player.m_GirlFSM.SetState(new GirlBearAttackState(m_Player));
            //}
        }

        public string StateName()
        {
            return "GirlWaitState";
        }
    }
}
