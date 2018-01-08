using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public float speed = 3.0f;
	public GameState gState;
	public Transform EndPoint;
	public Vector3 ThisPoint;
	public bool isTriggerEnter = false;

	void Start () {
		if (!gState) {
			gState = FindObjectOfType<GameState> ();
		}
	}

	void Update () {
		ThisPoint = gState.screenCamera.WorldToScreenPoint (EndPoint.position);

		if (isTriggerEnter == false) {
			if (ThisPoint.x < gState.GenPoint.x) {
				gState.GenArea ();
				isTriggerEnter = true;
			}
		}
		if (gState.isPlay == true) {
			transform.Translate (-Vector2.right * (speed * Time.deltaTime));
			if (ThisPoint.x < 0) {
				Destroy (gameObject);
			}
		}
	}
}
