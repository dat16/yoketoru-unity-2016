using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kantu : MonoBehaviour {
	private float time = 5;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Reset trigger")) 
		{
			gameObject.layer = 11;
			Invoke("DelayMethod",5f);
		}
	}

	void DylayMethod()
	{
		gameObject.layer = 10;

	}
	// Update is called once per frame
	void Update () {

	}
}