using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamGame
{
    public class Boss_1_Body : EnemyBase
    {
        public Boss_1 m_boss;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


		public override void Hurt(int dmg)
		{
            m_boss.Hurt(dmg);
		}
	}
}

