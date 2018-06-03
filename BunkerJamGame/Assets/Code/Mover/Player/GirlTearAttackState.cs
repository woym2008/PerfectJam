using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class GirlTearAttackState : IPlayerState
    {
        Player m_Player;

        float AttackCoolDown = 0.5f;
        float m_Curcool = 0.0f;

        Tear.TeatState m_State;

        public GirlTearAttackState(Player pPlayer, Tear.TeatState st)
        {
            m_Player = pPlayer;

            m_Curcool = AttackCoolDown;

            m_State = st;
        }

        public void Enter()
        {
            IGirlSkill skill = m_Player.m_Girl.m_SkillEmit.ThrowSkil("Tear");
            Tear te = (Tear)skill;
            te.SetTeatState(m_State);
            te.transform.position = m_Player.m_Girl.transform.position;

            m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Tear");
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_Curcool -= dt;
            if (m_Curcool <= 0.0f)
            {
                m_Player.m_GirlFSM.SetState(new GirlWaitState(m_Player));
            }
        }

        public string StateName()
        {
            return "GirlBearAttackState";
        }
    }
}
