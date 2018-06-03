using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class EnemyBase : MonoBehaviour, IMoveObject
    {
        public EnemyFSM m_EnemyFSM;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(Vector3 speed)
        {
            this.transform.position = new Vector3(
                this.transform.position.x + Time.deltaTime * speed.x,
                this.transform.position.y,
                this.transform.position.z
            );
        }

        public void Jump()
        {
            ;
        }

        public virtual void Die()
        {
            ;
        }

        public virtual void OnRemoveEnemy()
        {
            ;
        }

        public virtual float GetSpeed()
        {
            return 0;
        }

        public virtual float AttackDis()
        {
            return 1;
        }

        public virtual string getResPath()
        {
            return "";
        }

        public virtual void Hurt(int dmg)
        {
            ;
        }


    }
}

