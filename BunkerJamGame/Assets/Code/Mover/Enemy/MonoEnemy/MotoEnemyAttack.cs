using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class MotoEnemyAttack : IEnemyState
    {
        EnemyBase m_Enemy;

        float AttackTime = 1.0f;
        float m_attacktime = 0;
        public MotoEnemyAttack(EnemyBase enemy)
        {
            m_Enemy = enemy;
        }

        public void Enter()
        {
            Debug.Log("MotoEnemyAttack");
            m_attacktime = AttackTime;
        }

        public void Execute(float dt)
        {
            
            //Attack
            m_attacktime -= Time.deltaTime;
            if(m_attacktime<=0.0f)
            {
                //this.m_Enemy.m_EnemyFSM.EndState(this);
                this.m_Enemy.m_EnemyFSM.SetState(new MotoEnemyNormal(m_Enemy));
            }
        }

        public void Exit()
        {
            ;
        }

        public string StateName()
        {
            return "MotoEnemyAttack";
        }
    }
}

