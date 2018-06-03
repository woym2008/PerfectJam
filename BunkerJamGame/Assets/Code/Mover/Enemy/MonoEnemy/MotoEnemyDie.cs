using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class MotoEnemyDie : IEnemyState
    {
        EnemyBase m_Enemy;

        float DieTime = 0.5f;
        float m_CurDieTime = 0;

        public MotoEnemyDie(EnemyBase enemy)
        {
            m_Enemy = enemy;
        }

        public void Enter()
        {
            m_CurDieTime = DieTime;
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_CurDieTime -= dt;
            if(m_CurDieTime < 0)
            {
                m_Enemy.Die();
            }
        }

        public string StateName()
        {
            return "MotoEnemyDie";
        }
    }
}
