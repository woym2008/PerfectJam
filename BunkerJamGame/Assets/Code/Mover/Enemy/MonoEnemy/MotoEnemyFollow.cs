using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class MotoEnemyFollow : IEnemyState
    {
        EnemyBase m_Enemy;

        float m_FollowDis;

        Vector3 m_FollowDir;

        bool m_bNeedFollow;

        Vector3 m_FollowSpeed;

        public MotoEnemyFollow(EnemyBase enemy, float dis)
        {
            m_Enemy = enemy;

            m_FollowDis = dis;

            m_bNeedFollow = true;
        }

        public void Enter()
        {
            Debug.Log("MotoEnemyFollow");
            Player pplayer = MoverManager.getInstance.m_Player;
            if (pplayer != null)
            {
                Vector3 dir = (pplayer.transform.position - m_Enemy.transform.position).normalized;

                m_FollowDir = new Vector3(dir.x, 0, 0);

                m_FollowSpeed = Random.Range(0.8f, 1.0f) * m_Enemy.GetSpeed() * m_FollowDir;
            }
        }

        public void Execute(float dt)
        {
            m_Enemy.Move(m_FollowSpeed);

            //判断是否追击结束
            m_FollowDis -= Time.deltaTime * m_Enemy.GetSpeed();
            if (m_FollowDis <= 0 ||!m_bNeedFollow)
            {
                m_Enemy.m_EnemyFSM.SetState(new MotoEnemyNormal(m_Enemy));
                //m_Enemy.m_EnemyFSM.EndState(this);
                return;
            }

            //判断是否追上了转入攻击
            Player pplayer = MoverManager.getInstance.m_Player;
            if (pplayer != null)
            {
                float length = (pplayer.transform.position - m_Enemy.transform.position).magnitude;
                if(length < m_Enemy.AttackDis())
                {
                    //m_Enemy.m_EnemyFSM.SetState(new MotoEnemyNormal(m_Enemy));
                    m_Enemy.m_EnemyFSM.SetState(new MotoEnemyAttack(m_Enemy));
                    return;
                }
            }
        }

        public void Exit()
        {
            ;
        }

        public string StateName()
        {
            return "MotoEnemyFollow";
        }
    }
}
