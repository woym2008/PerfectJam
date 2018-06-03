using UnityEngine;
using System.Collections;

namespace JamGame
{
    
    public class SceneEnemyPoint : MonoBehaviour, ISceneObj
    {
        public enum SceneEnemyPointType
        {
            FrontCreate,
            BackCreate,
        }
        public EnemyType m_Enemytype;

        public SceneEnemyPointType CreateType;

        bool m_bEnabeCreate = false;



        public bool CreateEnemy()
        {
            EnemyBase pEnemy = MoverManager.getInstance.CreateEnemy(m_Enemytype);

            if(pEnemy != null)
            {
                pEnemy.transform.position = this.transform.position;

                return true;
            }


            return false;
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
            switch(CreateType)
            {
                case SceneEnemyPointType.BackCreate:
                    if (collision.gameObject.tag == "EnemyBackCreateArea")
                    {
                        if (CreateEnemy())
                        {
                            m_bEnabeCreate = false;
                        }

                    }
                    break;

                case SceneEnemyPointType.FrontCreate:
                    if (collision.gameObject.tag == "EnemyCreateArea")
                    {
                        if (CreateEnemy())
                        {
                            m_bEnabeCreate = false;
                        }

                    }
                    break;
            }

		}

        public void SceneInit()
        {
            m_bEnabeCreate = false;
        }
	}
}

