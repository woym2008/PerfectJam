using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JamGame
{
    public enum EnemyType
    {
        MotoMan,
        MotoMan_Far,
    }

    public class MoverManager : MonoBehaviour
    {
        static MoverManager m_Instance = null;
        // Use this for initialization
        static public MoverManager getInstance
        {
            get
            {
                return m_Instance;
            }
        }

		private void Awake()
		{
            m_Instance = this;
		}

		public Player m_Player;
        Stack<EnemyBase> m_EnemyBases;
        Dictionary<string, Stack<EnemyBase>> m_EnemyPool;

        List<EnemyBase> m_LiveEnemy;

        public Boss_1 m_Boss;

		public void Start()
		{
            //m_EnemyBases = new Stack<EnemyBase>();

            m_EnemyPool = new Dictionary<string, Stack<EnemyBase>>();

            m_LiveEnemy = new List<EnemyBase>();
		}


		string m_PlayerPath = "Mover/Player";
        public Player CreatePlayer()
        {
            GameObject prefab = Resources.Load(m_PlayerPath) as GameObject;
            GameObject playerobj = Instantiate(prefab);

            Player pPlayer = playerobj.GetComponent<Player>();

            return pPlayer;
        }

        public Boss_1 CreateBoss()
        {
            if(m_Boss != null)
            {
                m_Boss.gameObject.SetActive(true);

                return m_Boss;
            }

            return null;
        }

        public EnemyBase CreateEnemy(EnemyType enemytype)
        {
            int maxenemy = SceneFragmentManager.getInstance.GetMaxEnemy();
            if(m_LiveEnemy.Count >= maxenemy)
            {
                return null;
            }

            string enemypath = "";
            switch(enemytype)
            {
                case EnemyType.MotoMan:
                    enemypath = MotoEnemy.SResPath;
                    break;
                case EnemyType.MotoMan_Far:
                    enemypath = MotoEnemy.SResPath+"_back";
                    break;
            }
            if(m_EnemyPool.ContainsKey(enemypath))
            {
                if(m_EnemyPool[enemypath].Count > 0)
                {
                    EnemyBase pPopEnemy = m_EnemyPool[enemypath].Pop();
                    m_LiveEnemy.Add(pPopEnemy);
                    pPopEnemy.gameObject.SetActive(true);
                    return pPopEnemy;
                }
            }

            //  Debug.LogError(enemypath);
            GameObject prefab = Resources.Load(enemypath) as GameObject;
            GameObject playerobj = Instantiate(prefab);

            EnemyBase pEnemy = playerobj.GetComponent<EnemyBase>();
            m_LiveEnemy.Add(pEnemy);

            return pEnemy;
        }

        public void RemoveEnemy(EnemyBase enemy)
        {
            enemy.gameObject.SetActive(false);

            enemy.OnRemoveEnemy();

            m_LiveEnemy.Remove(enemy);

            SceneLevel level = SceneFragmentManager.getInstance.GetCurLevel();
            if(level != null)
            {
                level.KillOneEnemy();
            }

            if (m_EnemyPool.ContainsKey(enemy.getResPath()))
            {
                m_EnemyPool[enemy.getResPath()].Push(enemy);

                return;
            }

            Stack<EnemyBase> enemyst = new Stack<EnemyBase>();
            m_EnemyPool.Add(enemy.getResPath(),enemyst);
            enemyst.Push(enemy);

        }
    }
}

