using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class GirlBearAttackState : IPlayerState
    {
        Player m_Player;

        float AttackCoolDown = 1.0f;
        float m_Curcool = 0.0f;
        public GirlBearAttackState(Player pPlayer)
        {
            m_Player = pPlayer;

            m_Curcool = AttackCoolDown;
        }

        public void Enter()
        {
            if(m_Player.m_FSM.GetState.StateName() == "MoveState" )
            {
                m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_Throw");
            }
            else
            {
                m_Player.m_Girl.ShowAnimation("Anim_LittleGirl_RushThrow");
            }

            IGirlSkill skill = m_Player.m_Girl.m_SkillEmit.ThrowSkil("Bear");
            BoomBear bb = (BoomBear)skill;
            bb.XSpeed = m_Player.m_Speed;
            bb.transform.position = m_Player.m_Girl.transform.position;
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_Curcool -= dt;
            if(m_Curcool <= 0.0f)
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

