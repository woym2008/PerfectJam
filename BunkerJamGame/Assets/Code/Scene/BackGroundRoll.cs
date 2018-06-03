using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRoll : MonoBehaviour {
    SpriteRenderer m_Render;

    public float RollSpeed = 1.0f;
    float m_offsetx = 0;

    Material m_Material;

	private void Awake()
	{
        m_Render = this.gameObject.GetComponent<SpriteRenderer>();

        m_Material = m_Render.material;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(m_Material != null)
        {
            //Debug.Log(m_Material.name);
            m_offsetx = m_offsetx + Time.deltaTime * RollSpeed;
            if(m_offsetx > 1)
            {
                m_offsetx = m_offsetx - 1;
            }
            m_Material.mainTextureOffset = new Vector2(m_offsetx, 0);
        }
	}
}
