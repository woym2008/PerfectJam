using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class PlayerFSMMgr
    {
        IPlayerState m_state;

        public IPlayerState GetState
        {
            get{
                return m_state;
            }
        }
        public void SetState(IPlayerState state)
        {
            if(m_state != null)
            {
                m_state.Exit();
            }

            m_state = state;

            m_state.Enter();
        }

        public void Update(float dt)
        {
            if(m_state !=null)
            {
                m_state.Execute(dt);
            }
        }
    }
}

