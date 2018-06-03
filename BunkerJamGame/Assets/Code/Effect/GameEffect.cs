using UnityEngine;
using System.Collections;

public class GameEffect : MonoBehaviour
{
    public float LiveTime = 1.5f;
	// Use this for initialization
	void Start()
	{
        Animator anim = this.GetComponent<Animator>();
        anim.Play("Anim_Effect_Boom");
	}

	// Update is called once per frame
	void Update()
	{
        LiveTime -= Time.deltaTime;
        if(LiveTime < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
