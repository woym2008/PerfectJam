using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamGame
{
    public class SFXPlayerManager : MonoBehaviour
    {

        static SFXPlayerManager m_Instance;

        public static SFXPlayerManager getInstance
        {
            get
            {
                return m_Instance;
            }
        }


        public AudioClip m_Shoot;
        public AudioClip m_Crush;
        public AudioClip m_Lazzer;
        public AudioClip m_AddSpeed;

        public AudioSource m_Source;

        private void Awake()
        {
            m_Instance = this;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CreateSFX(string name)
        {

            switch (name)
            {
                case "shoot":
                    m_Source.PlayOneShot(m_Shoot);
                    break;
                case "crush":
                    m_Source.PlayOneShot(m_Crush);
                    break;
                case "lazzer":
                    m_Source.PlayOneShot(m_Lazzer);
                    break;
                case "addspeed":
                    m_Source.PlayOneShot(m_AddSpeed);
                    break;
            }
        }
    }
}
