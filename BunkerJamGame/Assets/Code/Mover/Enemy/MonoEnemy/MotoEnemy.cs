using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamGame
{
    public class MotoEnemy :  EnemyBase{

        float attackdis = 0.1f;

        public string ResPath = "Mover/MotoMan";
        static public string SResPath = "Mover/MotoMan";

        public float m_Speed = 1.0f;

		private void Awake()
		{
            m_EnemyFSM = new EnemyFSM();
		}
		// Use this for initialization
		void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            this.m_EnemyFSM.Update(Time.deltaTime);
        }

		public override void Die()
		{
            //this.m_EnemyFSM.Clear();
            EffectManager.getInstance.CreateEffect(this.transform.position);

            SFXPlayerManager.getInstance.CreateSFX("crush");

            MoverManager.getInstance.RemoveEnemy(this);
		}

		public override void Hurt(int dmg)
		{
            Die();
		}

		private void OnEnable()
		{
            this.m_EnemyFSM.SetState(new MotoEnemyNormal(this));
		}

		public override void OnRemoveEnemy()
		{
            this.m_EnemyFSM.Clear();
		}

		public override float GetSpeed()
        {
            return m_Speed;
        }

		public override float AttackDis()
		{
            return attackdis;
		}

        public override string getResPath()
        {
            return ResPath;
        }


	}
}

