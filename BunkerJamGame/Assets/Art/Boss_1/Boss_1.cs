using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamGame{
    public class Boss_1 : EnemyBase
    {

        Animator boss_control;
        int isCouch = 0;
        public float CouchOppSpeed = 0.8f;
        //
        public GameObject[] FXs;
        public float Fx_next_interval = 0.2f;
        public float Rnd_radius_scale = 0.65f;
        int indexCounter = 0;
        float LastActiveTimer = 0;
        //
        public PolygonCollider2D body;
        public PolygonCollider2D body_couch;
        public BoxCollider2D lazer;
        // Use this for initialization

        public Transform StartPoint;

        bool m_bReadyEnter = true;

        public float MaxWaitTime = 7.0f;
        public float MinWaitTime = 5f;
        float m_WaitTime = 0.0f;

        public int HP = 30;
        void Start()
        {
            boss_control = GetComponent<Animator>();

            m_bReadyEnter = true;
        }

        // Update is called once per frame
        void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.C))
            {
                Couch();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Launch_Lazer();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Die();
            }
            */
            //
            if (isCouch == 1)
            {
                transform.Translate(Vector2.left * Time.deltaTime * CouchOppSpeed);
            }
            else if (isCouch == 2)
            {
                transform.Translate(Vector2.right * Time.deltaTime * CouchOppSpeed);
            }
            if (isCouch == 3)
            {
                transform.Translate(Vector2.left * Time.deltaTime * 0.5f);
                if (Time.time - LastActiveTimer >= Fx_next_interval)
                {
                    if (indexCounter < FXs.Length)
                    {
                        FXs[indexCounter].SetActive(true);
                        FXs[indexCounter].transform.localPosition = Random.insideUnitCircle * Rnd_radius_scale;
                        indexCounter++;
                        LastActiveTimer = Time.time;
                    }
                }
            }

            if(m_bReadyEnter)
            {
                this.transform.position = new Vector3(
                    this.transform.position.x + -0.5f * Time.deltaTime,
                    this.transform.position.y,
                    this.transform.position.z
                );

                if((this.transform.position - StartPoint.position).magnitude < 0.2)
                {
                    m_bReadyEnter = false;
                }
            }
            else
            {
                m_WaitTime -= Time.deltaTime;
                if(m_WaitTime <= 0)
                {
                    int attackway = Random.Range(0, 2);
                    if(attackway == 0)
                    {
                        Couch();
                    }
                    else if(attackway == 1)
                    {
                        Launch_Lazer();
                    }

                    m_WaitTime = Random.Range(MinWaitTime, MaxWaitTime);
                }
            }
        }
        //
        public void Couch()
        {
            boss_control.SetTrigger("couch");
            isCouch = 1;
        }

        public void Launch_Lazer()
        {
            SFXPlayerManager.getInstance.CreateSFX("lazzer");
            boss_control.SetTrigger("lazer");
        }

        public void Stand()
        {
            if (isCouch == 1) isCouch = 2;
        }

        public void Walk()
        {
            if (isCouch == 2) isCouch = 0;
        }

        public override void Die()
        {
            isCouch = 3;
            boss_control.SetTrigger("die");
        }

        public void FinishDie()
        {

        }

        override public void Hurt(int dmg)
        {
            if(isCouch == 3)
            {
                return;
            }

            SFXPlayerManager.getInstance.CreateSFX("crush");

            EffectManager.getInstance.CreateEffect(this.transform.position);

            HP -= dmg;
            if(HP <= 0)
            {
                Die();

                SceneFragmentManager.getInstance.GetCurLevel().KillOneBoss();
            }
        }
	}
}

