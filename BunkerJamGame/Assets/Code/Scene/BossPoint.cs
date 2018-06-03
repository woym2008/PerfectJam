using UnityEngine;
using System.Collections;

namespace JamGame
{

    public class BossPoint : MonoBehaviour, ISceneObj
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "BossCreatePoint")
            {
                if(SceneFragmentManager.getInstance.GetCurLevel() != null)
                {
                    if (SceneFragmentManager.getInstance != null && !SceneFragmentManager.getInstance.GetCurLevel().BossCreated)
                    {
                        MoverManager.getInstance.CreateBoss();
                    }
                }


            }

        }

        public void SceneInit()
        {
        }
    }
}
