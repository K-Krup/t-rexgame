using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
	public float speed;
	bool reached;

    void Awake()
    {
		reached = false;
    }


	void Update()
	{
		if(transform.position.y >= 5)
		{
			reached = true;
		}
		if (!reached) { 
			transform.position += new Vector3(0, speed * Time.deltaTime, 0);
		}
	}
}
