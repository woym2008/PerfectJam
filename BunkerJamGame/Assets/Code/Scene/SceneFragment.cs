using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace JamGame
{
    public class SceneFragment : MonoBehaviour
    {
        public List<GameObject> m_SceneObjs = new List<GameObject>();

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

		private void OnEnable()
		{
            foreach(var obj in m_SceneObjs)
            {
                if(obj != null)
                {
                    ISceneObj iso = obj.GetComponent<ISceneObj>();
                    if (iso != null)
                    {
                        iso.SceneInit();
                    }
                }


            }
		}

		private void OnDisable()
		{
            for (int i = 0; i < this.transform.childCount; ++i)
            {
                IGirlSkill skill = this.transform.GetChild(i).GetComponent<IGirlSkill>();
                if(skill != null)
                {
                    skill.RemoveSelf();
                }
            }
		}
	}
}

