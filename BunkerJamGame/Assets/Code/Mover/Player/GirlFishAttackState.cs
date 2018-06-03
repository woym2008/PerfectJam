using UnityEngine;
using System.Collections;


namespace JamGame
{
    public class GirlFishAttackState : IPlayerState
    {
        Player m_Player;
        public GirlFishAttackState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_JumpThrow");

            IGirlSkill skill = m_Player.m_Girl.m_SkillEmit.ThrowSkil("Fish");
            MonsterFish bb = (MonsterFish)skill;
            bb.transform.position = m_Player.m_Girl.transform.position;
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            if (m_Player.m_JumpSpeed <= 0.0f)
            {
                m_Player.m_GirlFSM.SetState(new GirlWaitState(m_Player));
            }
        }

        public string StateName()
        {
            return "GirlFishAttacksState";
        }
    }
}
