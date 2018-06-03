using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class MonsterFish : MonoBehaviour, IGirlSkill
    {
        public enum MonsterFishState
        {
            Throw,
            Broken,
            GrowAndJump,
            End
        }
        public void RemoveSelf()
        {
            Destroy(this.gameObject);
        }

        public float m_Passtime = 3.0f;
        float m_curtime = 0;
        public float m_DownSpeed = -1.0f;

        public Vector3 m_StartVec;
        public Vector3 m_ControlVec1;
        public Vector3 m_ControlVec2;
        public Vector3 m_EndVec;
        public Transform PointControl1;
        public Transform PointControl2;
        public Transform PointEnd;

        MonsterFishState m_State;

        Animator m_Anim = null;

		private void Start()
		{
            m_Anim = this.gameObject.GetComponent<Animator>();

            m_Anim.Play("Anim_Skill_Fish");

            m_State = MonsterFishState.Throw;

            m_curtime = m_Passtime;

            m_StartVec = this.transform.position;
		}

		private void Update()
		{

            switch(m_State)
            {
                case MonsterFishState.Throw:
                    this.transform.position = new Vector3(
                        this.transform.position.x,
                        this.transform.position.y + m_DownSpeed * Time.deltaTime,
                        this.transform.position.z
                    );
                    break;
                case MonsterFishState.GrowAndJump:
                    m_curtime -= Time.deltaTime;
                    if (m_curtime <= 0)
                    {
                        m_curtime = 0;

                        this.gameObject.SetActive(false);
                    }

                    Vector3 pos = CalculateCubicBezierPoint(m_Passtime - m_curtime, m_StartVec, m_ControlVec1, m_ControlVec2, m_EndVec);
                    this.transform.position = pos;
                    break;
            }
		}

		Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)  
        {  
            float u = 1 - t;  
            float tt = t * t;  
            float uu = u * u;  
            float uuu = uu * u;  
            float ttt = tt * t;  
              
            Vector3 p = uuu * p0;   
            p += 3 * uu * t * p1;   
            p += 3 * u * tt * p2;   
            p += ttt * p3;   
              
            return p;  
        } 

        public void ThrowOver()
        {
            m_Anim.Play("Anim_Skill_Fish_Broke");

            m_State = MonsterFishState.Broken;

            m_ControlVec1 = PointControl1.position;
            m_ControlVec2 = PointControl2.position;
            m_EndVec = PointEnd.position;
        }

        public void BrokeOver()
        {
            m_Anim.Play("Anim_Skill_Fish_Fly");

            m_State = MonsterFishState.GrowAndJump;
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
            if (m_State == MonsterFishState.Throw && collision.gameObject.tag == "ScenePlatform")
            {
                ThrowOver();

                int count = SceneFragmentManager.getInstance.m_Levels[SceneFragmentManager.getInstance.CurLevel].m_curReadyFragments.Count;
                if (count > 0)
                {
                    this.transform.parent = SceneFragmentManager.getInstance.m_Levels[SceneFragmentManager.getInstance.CurLevel].m_curReadyFragments[count - 1].transform;
                } 
            }

            if (m_State == MonsterFishState.GrowAndJump && collision.gameObject.tag == "Enemy")
            {
                EnemyBase pEnemy = collision.gameObject.GetComponent<EnemyBase>();
                if (pEnemy != null)
                {
                    pEnemy.Hurt(5);
                }

            }
		}
	}
}
