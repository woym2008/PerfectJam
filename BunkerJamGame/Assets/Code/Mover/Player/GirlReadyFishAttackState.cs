using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class GirlReadyFishAttackState : IPlayerState
    {
        Player m_Player;

        float ReadyTime = 0.4f;
        float m_ReadyTime = 0.0f;
        public GirlReadyFishAttackState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_ReadyJumpThrow");

            m_ReadyTime = ReadyTime;
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_ReadyTime -= dt;
            if(m_ReadyTime < 0)
            {
                m_Player.m_GirlFSM.SetState(new GirlFishAttackState(m_Player));
            }
        }

        public string StateName()
        {
            return "GirlReadyFishAttacksState";
        }
    }
}
