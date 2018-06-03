using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class MotoEnemyNormal : IEnemyState
    {
        EnemyBase m_Enemy;

        float MaxWaitTime = 2.0f;

        float m_WaitTime = 0.0f;

        float m_Speed;

        public MotoEnemyNormal(EnemyBase enemy)
        {
            m_Enemy = enemy;
        }

        public void Enter()
        {
            Debug.Log("MotoEnemyNormal");
            m_WaitTime = Random.Range(0.5f, 1.0f) * MaxWaitTime;

            m_Speed = Random.Range(-1.0f, 1.0f) * m_Enemy.GetSpeed();
        }

        public void Exit()
        {
            ;
        }

        public void Execute(float dt)
        {
            m_WaitTime -= Time.deltaTime;

            m_Enemy.Move(new Vector3(m_Speed,0,0));

            if(m_WaitTime <= 0)
            {
                Player pplayer = MoverManager.getInstance.m_Player;
                if (pplayer != null)
                {
                    float length = (pplayer.transform.position - m_Enemy.transform.position).magnitude;

                    float followdis = Random.Range(0, 1.0f) * length;

                    m_Enemy.m_EnemyFSM.SetState(new MotoEnemyFollow(m_Enemy, followdis));
                }
            }

        }

        public string StateName()
        {
            return "MotoEnemyNormal";
        }
    }
}

