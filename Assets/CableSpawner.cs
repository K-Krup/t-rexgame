using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSpawner : MonoBehaviour
{
	public GameObject cable, cable2;
	public float frequency;

	float nextSpawn;
	
	Vector3[] spots;

	

	public int spotsCount = 18;
	public float gap = 0.5f;
    void Awake()
    {
		nextSpawn = 0;

		spots = new Vector3 [spotsCount];
		for(int i = 0; i < spotsCount; i+=2)
		{
			spots[i] = new Vector3(i* gap + gap, -5, 0);
			spots[i+1] = new Vector3(-1* (i * gap + gap), -5, 0);
		}

    }

    void Update()
    {
		if (Time.time >= nextSpawn)
		{
			nextSpawn = Time.time + (5f / frequency);
			SpawnNewCable();
		}
	}

	void SpawnNewCable()
	{
		Vector3 spot = GetFreeSpot();
		if (spot != Vector3.zero) {
			if(Random.value > 0.5f) Instantiate(cable, spot, Quaternion.Euler(0,0,90));
			else Instantiate(cable2, spot, Quaternion.Euler(0, 0, 90));
		}
	}

	Vector3 GetFreeSpot()
	{
		for(int i =0; i<spots.Length; i++)
		{
			if (spots[i].z==0)
			{
				spots[i].z -=1;
				return spots[i];
			}
		}
		return Vector3.zero;
	}
}
