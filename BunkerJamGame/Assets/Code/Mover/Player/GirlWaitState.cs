using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class GirlWaitState : IPlayerState
    {
        Player m_Player;
        public GirlWaitState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Normal");
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                m_Player.m_GirlFSM.SetState(new GirlBearAttackState(m_Player));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                m_Player.m_GirlFSM.SetState(new GirlTearAttackState(m_Player,Tear.TeatState.Front));
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                m_Player.m_GirlFSM.SetState(new GirlTearAttackState(m_Player, Tear.TeatState.UpFront));
            }

        }

        public string StateName()
        {
            return "GirlWaitState";
        }
    }
}
