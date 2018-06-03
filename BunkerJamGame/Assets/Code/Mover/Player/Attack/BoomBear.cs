using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class BoomBear : MonoBehaviour, IGirlSkill
    {
        public enum BearState
        {
            Throw,
            Wait,
            Boom,
        }
        public void RemoveSelf()
        {
            Destroy(this.gameObject);
        }

        public float ThrowSpeed = -1.0f;
        public float XSpeed = 0.0f;

        public float BoomTime = 1.0f;

        public float RotSpeed = 360;

        BearState m_State;

        Animator m_Anim;

        private void Start()
        {
            m_Anim = this.gameObject.GetComponent<Animator>();

            m_Anim.Play("Anim_Bear_Throw");

            m_State = BearState.Throw;
        }

		private void Update()
		{
            switch(m_State)
            {
                case BearState.Throw:
                    this.transform.position = new Vector3(
                        this.transform.position.x,
                        this.transform.position.y + ThrowSpeed * Time.deltaTime,
                        this.transform.position.z
                    );

                    this.transform.localEulerAngles = new Vector3(
                        this.transform.localEulerAngles.x,
                        this.transform.localEulerAngles.y,
                        this.transform.localEulerAngles.z + RotSpeed*Time.deltaTime
                    );
                    break;
                case BearState.Wait:
                    break;
                case BearState.Boom:
                    BoomTime -= Time.deltaTime;
                    if(BoomTime <= 0)
                    {
                        this.gameObject.SetActive(false);
                    }
                    break;

            }
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
            if(collision.gameObject.tag == "ScenePlatform")
            {
                this.m_State = BearState.Wait;

                int count = SceneFragmentManager.getInstance.m_Levels[SceneFragmentManager.getInstance.CurLevel].m_curReadyFragments.Count;
                if (count > 0)
                {
                    this.transform.parent = SceneFragmentManager.getInstance.m_Levels[SceneFragmentManager.getInstance.CurLevel].m_curReadyFragments[count - 1].transform;
                } 
            }


            if(collision.gameObject.tag == "Enemy")
            {
                this.m_State = BearState.Boom;
                m_Anim.Play("Anim_Bear_Boom");

                EnemyBase pEnemy = collision.gameObject.GetComponent<EnemyBase>();
                pEnemy.Hurt(2);
            }
		}
	}
}
