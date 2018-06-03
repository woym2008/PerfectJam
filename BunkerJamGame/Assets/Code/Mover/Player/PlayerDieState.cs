using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerDieState : IPlayerState
    {
        Player m_Player;

        public PlayerDieState(Player pPlayer)
        {
            m_Player = pPlayer;
        }

        public void Enter()
        {
            GameObject pObj = EffectManager.getInstance.CreateEffect(m_Player.transform.position);
            if(pObj != null)
            {
                pObj.transform.parent = m_Player.transform;
            }

            m_Player.Die();

            m_Player.m_Speed = 0;
        }

        public void Execute(float dt)
        {

        }

        public void Exit()
        {
            ;
        }

        public string StateName()
        {
            return "DieState";
        }
    }
}

