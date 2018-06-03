using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JamGame
{
    public class EnemyFSM
    {
        //List<IEnemyState> m_EnemyStates;
        IEnemyState m_CurState;

        public EnemyFSM()
        {
            //m_EnemyStates = new List<IEnemyState>();


        }

        public void SetState(IEnemyState state)
        {
            //if(m_EnemyStates.Count > 0)
            {
                //m_EnemyStates[m_EnemyStates.Count - 1].Exit();
            }

            if(m_CurState != null)
            {
                m_CurState.Exit();
            }

            state.Enter();

            //m_EnemyStates.Add(state);
            m_CurState = state;
        }
        /*
        public void EndState(IEnemyState state)
        {
            if (m_EnemyStates.Count > 0)
            {
                if(m_EnemyStates[m_EnemyStates.Count - 1] == state)
                {
                    m_EnemyStates[m_EnemyStates.Count - 1].Exit();

                    m_EnemyStates.Remove(state);

                    if(m_EnemyStates.Count > 0)
                    {
                        m_EnemyStates[m_EnemyStates.Count - 1].Enter();
                    }
                }
            }
        }*/

        public void Update(float dt)
        {
            //if (m_EnemyStates.Count > 0)
            {
                //m_EnemyStates[m_EnemyStates.Count - 1].Execute(dt);
            }

            if(m_CurState != null)
            {
                m_CurState.Execute(dt);
            }
        }

        public IEnemyState GetState()
        {
            //if (m_EnemyStates.Count > 0)
            {
                //return m_EnemyStates[m_EnemyStates.Count - 1];
            }

            //return null;

            return m_CurState;
        }

        public void Clear()
        {
            //m_EnemyStates.Clear();
            m_CurState = null;
        }
    }
}

