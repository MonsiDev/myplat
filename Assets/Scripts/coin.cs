using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (transform.position.x, Random.Range (1, 4));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
