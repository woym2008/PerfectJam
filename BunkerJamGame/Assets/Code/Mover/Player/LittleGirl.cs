using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class LittleGirl : MonoBehaviour
    {
        Animator m_Anim;

        public SkillEmitter m_SkillEmit;

		private void Awake()
		{
            m_Anim = this.gameObject.GetComponent<Animator>();
		}
		// Use this for initialization
		void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowAnimation(string animname)
        {
            m_Anim.Play(animname);
        }
    }
}


