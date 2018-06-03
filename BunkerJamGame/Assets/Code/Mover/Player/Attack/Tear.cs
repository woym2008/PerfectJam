using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class Tear : MonoBehaviour,IGirlSkill
    {
        public void RemoveSelf()
        {
            ;
        }

        public enum TeatState
        {
            Front,
            UpFront,
        }

        public float m_Speed = 1.0f;

        public float m_ySpeed = 0.45f;

        TeatState m_State;

        public Animator m_Anim;

        public void SetTeatState(TeatState state){
            m_State = state;

            if(state == TeatState.UpFront)
            {
                this.transform.localEulerAngles = new Vector3(0, 0, 40);
            }
        }

        private void Start()
        {
            m_Anim = this.gameObject.GetComponent<Animator>();

            m_Anim.Play("Anim_Tear_Throw");

            SFXPlayerManager.getInstance.CreateSFX("shoot");
        }

		private void Update()
		{
            switch(m_State)
            {
                case TeatState.Front:
                    {
                        this.transform.position = new Vector3(
                            this.transform.position.x + m_Speed * Time.deltaTime,
                            this.transform.position.y,
                            this.transform.position.z
                        );
                    }
                    break;

                case TeatState.UpFront:
                    this.transform.position = new Vector3(
                        this.transform.position.x + m_Speed* Time.deltaTime,
                        this.transform.position.y + m_ySpeed* Time.deltaTime,
                            this.transform.position.z
                        );
                    break;
            }
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
            if(collision.gameObject.tag == "Enemy")
            {
                this.gameObject.SetActive(false);

                EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
                if(enemy != null)
                {
                    enemy.Hurt(1);
                }
            }
		}
	}
}
