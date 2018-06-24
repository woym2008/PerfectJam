using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace JamGame
{
    public class SceneFragmentManager : MonoBehaviour
    {
        static SceneFragmentManager m_Instance;
        public static SceneFragmentManager getInstance
        {
            get
            {
                return m_Instance;
            }
        }
        
        public enum SceneObjCreateState
        {
            CanCreate,
            NoCreate,
        }
        //public List<SceneFragment> m_sceneFragments;

        public int CurLevel = 0;
        public List<SceneLevel> m_Levels;

        public int showfragmentnum = 3;
        List<SceneFragment> m_curFragments;

        public float speed = 1.0f;

        public Transform DestoryPoint;

        public float m_fragmentwidth;

        SceneObjCreateState m_CreateState = SceneObjCreateState.CanCreate;

		private void Awake()
		{
            m_Instance = this;
		}

		// Use this for initialization
		void Start()
        {
            CurLevel = 0;

            CreateFirst();
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = m_curFragments.Count - 1; i >= 0; --i)
            {
                Vector3 locpos = m_curFragments[i].transform.position;
                float newx = locpos.x - Time.deltaTime * speed;
                m_curFragments[i].gameObject.transform.position =
                    new Vector3(
                                         newx,
                                         m_curFragments[i].gameObject.transform.position.y,
                                         m_curFragments[i].gameObject.transform.position.z
                    );
                if(newx <= DestoryPoint.position.x)
                {
                    m_curFragments[i].gameObject.SetActive(false);
                    m_curFragments.Remove(m_curFragments[i]);
                }
            }
                
            if(m_curFragments.Count < showfragmentnum)
            {
                CreateFragment();
            }

            if(CurLevel < m_Levels.Count)
            {
                if(m_Levels[CurLevel].IsComplete())
                {
                    CurLevel++;
                }
            }
            else
            {
                Invoke("GameOverOver", 7.0f);

            }
        }

        public void GameOverOver()
        {
            SceneManager.LoadScene("WinScene");
        }

        void CreateFirst()
        {
            m_curFragments = new List<SceneFragment>();

            int index = Random.Range(0, m_Levels[CurLevel].m_curReadyFragments.Count);

            m_Levels[CurLevel].m_curReadyFragments[index].gameObject.transform.position = this.transform.position;

            m_Levels[CurLevel].m_curReadyFragments[index].gameObject.SetActive(true);
            m_curFragments.Add(m_Levels[CurLevel].m_curReadyFragments[index]);

            //SpriteRenderer m_Render = m_Levels[CurLevel].m_curReadyFragments[index].GetComponent<SpriteRenderer>();
            //float w = m_Render.material.mainTexture.width;
            //m_fragmentwidth = w;
            while (m_curFragments.Count < showfragmentnum)
            {
                CreateFragment();
            }
        }

        void CreateFragment()
        {
            int uselevel = CurLevel;
            if(CurLevel >= m_Levels.Count)
            {
                uselevel = m_Levels.Count - 1;
            }
            List<SceneFragment> usefulfragment = new List<SceneFragment>();
            for (int i = 0; i < m_Levels[uselevel].m_curReadyFragments.Count; ++i)
            {
                if(!m_Levels[uselevel].m_curReadyFragments[i].gameObject.activeSelf)
                {
                    usefulfragment.Add(m_Levels[uselevel].m_curReadyFragments[i]);
                }
            }

            int index = Random.Range(0, usefulfragment.Count);

            usefulfragment[index].gameObject.transform.position = 
                m_curFragments[m_curFragments.Count-1].transform.position + 
                new Vector3( m_fragmentwidth,m_curFragments[m_curFragments.Count-1].transform.position.y,m_curFragments[m_curFragments.Count-1].transform.position.z);
            
            usefulfragment[index].gameObject.SetActive(true);
            m_curFragments.Add(usefulfragment[index]);

            if(GetCurLevel() != null)
            {
                GetCurLevel().CrossOneFragMent();
            }
        }

        void AddLevel()
        {
            CurLevel++;
            if(CurLevel >= m_Levels.Count)
            {
                GameOver();
            }
        }

        void GameOver()
        {
            SceneManager.LoadScene("winscene");
        }

        public int GetMaxEnemy()
        {
            if(CurLevel<m_Levels.Count)
            {
                return m_Levels[CurLevel].GetMaxEnemy();
            }
            return 0;
        }

        public SceneLevel GetCurLevel()
        {
            if(m_Levels.Count > CurLevel)
            {
                return m_Levels[CurLevel];
            }

            return null;
        }

        public SceneFragment GetLastFragment()
        {
            if(m_curFragments.Count > 0)
            {
                return m_curFragments[m_curFragments.Count - 1];
            }

            return null;
        }
    }
}

