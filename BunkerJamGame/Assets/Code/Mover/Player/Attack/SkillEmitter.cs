using UnityEngine;
using System.Collections;

namespace JamGame
{
    public class SkillEmitter : MonoBehaviour
    {
        public GameObject BearPrefab;
        public GameObject FishPrefab;
        public GameObject TearPrefab;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public IGirlSkill ThrowSkil(string name)
        {
            IGirlSkill skill = null;
            switch (name)
            {
                case "Bear":
                    GameObject pobject = Instantiate(BearPrefab);
                    pobject.SetActive(true);
                    skill = pobject.GetComponent<IGirlSkill>();

                    break;

                case "Fish":
                    GameObject pfobject = Instantiate(FishPrefab);
                    pfobject.SetActive(true);
                    skill = pfobject.GetComponent<IGirlSkill>();

                    break;

                case "Tear":
                    GameObject ptobject = Instantiate(TearPrefab);
                    ptobject.SetActive(true);
                    skill = ptobject.GetComponent<IGirlSkill>();

                    break;
            }

            return skill;
        }
    }
}

