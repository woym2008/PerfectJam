using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class MuscleMan : MonoBehaviour
    {
        Animator m_Anim;

        public Player m_Player;

        private void Awake()
        {
            m_Anim = this.gameObject.GetComponent<Animator>();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowAnimation(string animname)
        {
            m_Anim.Play(animname);
        }

        public void ReadyJumpOver()
        {
            if(m_Player.m_FSM.GetState.StateName() == "PlayerReadyJumpState")
            {
                m_Player.m_FSM.SetState(new PlayerJumpState(m_Player));
            }
        }
    }
}

