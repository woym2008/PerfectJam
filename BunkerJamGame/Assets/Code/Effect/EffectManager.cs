using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    static EffectManager m_Instance;
    public static EffectManager getInstance
    {
        get
        {
            return m_Instance;
        }
    }

    public GameObject BoomPrefab = null;

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

    public GameObject CreateEffect(Vector3 pos, string name = "boom")
    {
        switch(name)
        {
            case "boom":
                GameObject pObj = Instantiate(BoomPrefab);
                pObj.transform.position = pos;
                pObj.SetActive(true);

                return pObj;
                break;
        }

        return null;
    }
}
