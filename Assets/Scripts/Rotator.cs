using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public bool dursunMu = false;
	public float dondurmeHizi = 10f;
	public Transform akrepObj;
	public Transform yelkovanObj;

	private void Update()
	{
		Cevir();
	}

	private void Cevir()
	{
		if (!dursunMu)
		{
			akrepObj.Rotate(new Vector3(0f, 0f, dondurmeHizi / 12f) * -Time.deltaTime);
			yelkovanObj.Rotate(new Vector3(0f, 0f, dondurmeHizi) * -Time.deltaTime);
		}
	}

}
