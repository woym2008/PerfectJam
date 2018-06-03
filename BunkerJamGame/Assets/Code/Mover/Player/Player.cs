using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace JamGame
{
    public class Player : MonoBehaviour, IMoveObject
    {
        public PlayerFSMMgr m_FSM;
        public PlayerFSMMgr m_GirlFSM;
        //------------------------------------------
        public float MaxSpeed = 1;
        public float m_Speed = 0;

        public float JumpStartSpeed = 1;
        public float m_JumpSpeed = 0;
        public float jumpReduce = 0.4f;
        public float DownStartSpeed = -1;
        public float m_DownSpeed = 0;
        public float downAdd = 0.2f;

        //------------------------------------------
        public MuscleMan    m_Man;
        public LittleGirl   m_Girl;
        //------------------------------------------
        bool ReadyDie = false;
        float DieTime = 2.0f;
        //------------------------------------------

        // Use this for initialization
        void Start()
        {
            ReadyDie = false;

            m_FSM = new PlayerFSMMgr();
            m_FSM.SetState(new PlayerStandState(this));

            m_GirlFSM = new PlayerFSMMgr();
            m_GirlFSM.SetState(new GirlWaitState(this));

            m_Man.m_Player = this;
        }

        // Update is called once per frame
        void Update()
        {
            m_FSM.Update(Time.deltaTime);

            m_GirlFSM.Update(Time.deltaTime);

            if(ReadyDie)
            {
                DieTime -= Time.deltaTime;
                if(DieTime < 0.0f)
                {
                    SceneManager.LoadScene("DieScene");
                }
            }
        }

        public void Move(Vector3 dir)
        {
            //left
            float offset = m_Speed * Time.deltaTime;
            float newx = this.transform.position.x + offset;
            this.transform.position = new Vector3(
                newx,
                this.transform.position.y,
                this.transform.position.z
            );
        }

        public void Jump()
        {
            float offset = m_JumpSpeed * Time.deltaTime;
            float newy = this.transform.position.y + offset;
            this.transform.position = new Vector3(
                this.transform.position.x,
                newy,
                this.transform.position.z
            );
            if(m_JumpSpeed > 0)
            {
                m_JumpSpeed -= jumpReduce * Time.deltaTime;
            }
            else
            {
                m_JumpSpeed = 0;
            }
        }


        public void DownLand()
        {
            float offset = -m_DownSpeed * Time.deltaTime;
            float newy = this.transform.position.y + offset;
            this.transform.position = new Vector3(
                this.transform.position.x,
                newy,
                this.transform.position.z
            );
            if (m_DownSpeed > 0)
            {
                m_DownSpeed -= downAdd * Time.deltaTime;
            }
            else
            {
                m_DownSpeed = 0;
            }
        }



		private void OnTriggerEnter2D(Collider2D collision)
		{
            if(collision.gameObject.tag == "ScenePlatform")
            {
                if(m_FSM.GetState.StateName() == "DownState")
                {
                    m_FSM.SetState(new PlayerStandState(this));

                    m_GirlFSM.SetState(new GirlWaitState(this));
                }
            }

            if (collision.gameObject.tag == "SceneOutside")
            {
                m_Speed = -m_Speed*0.1f;
            }

            if (collision.gameObject.tag == "EnemyChain")
            {
                Hurt();
            }
		}

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "ScenePlatform")
            {
                if (m_FSM.GetState.StateName() != "JumpState")
                {
                    m_FSM.SetState(new PlayerDownState(this));
                }
            }
        }

        public void ReadyJumpOver()
        {
            if(m_FSM.GetState.StateName() == "PlayerReadyJumpState")
            {
                m_FSM.SetState(new PlayerJumpState(this));
            }

        }

        public void Hurt()
        {
            this.m_FSM.SetState(new PlayerDieState(this));
        }

        public void Die()
        {
            ReadyDie = true;
            DieTime = 2.0f;
        }
	}
}

