using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class SceneTrap : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

		private void OnTriggerStay2D(Collider2D collision)
		{
            if(collision.tag == "Enemy")
            {
                EnemyBase pEnemy = collision.gameObject.GetComponent<EnemyBase>();
                if(pEnemy != null)
                {
                    pEnemy.Hurt(100);
                }
            }
            else if(collision.tag == "Player")
            {
                Player pPlayer = collision.gameObject.GetComponent<Player>();
                if (pPlayer != null)
                {
                    pPlayer.Hurt();
                }
            }
		}
	}

}
