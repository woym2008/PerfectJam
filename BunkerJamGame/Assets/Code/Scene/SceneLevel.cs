using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JamGame
{
    public class SceneLevel : MonoBehaviour
    {
        public List<SceneFragment> m_curReadyFragments;

        public int MaxEnemy = 1;

        public int NeedKillEnemy = 1;

        public int NeedCrossFragment = 3;

        public bool NeedKillBoss = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsComplete()
        {
            if(NeedKillEnemy <=0 && NeedCrossFragment<=0 && !NeedKillBoss)
            {
                return true;
            }

            return false;
        }

        public int GetMaxEnemy()
        {
            return MaxEnemy;
        }

        public void KillOneEnemy()
        {
            NeedKillEnemy -= 1;
        }

        public void KillOneBoss()
        {
            NeedKillBoss = false;
        }

        public void CrossOneFragMent()
        {
            NeedCrossFragment -= 1;
        }
    }
}

