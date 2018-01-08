using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameState : MonoBehaviour {

	public bool isPlay = false;
	public Transform Ob_Gen;
	public GameObject[] Ob_areas;
	public Vector3 GenPoint;
	public Camera screenCamera;
	public float minTime = 2.0f;
	public float maxTime = 5.0f;
    public Player player;
	public float lastTime = 0.0f;

    public void onPlay() {
		isPlay = true;
	}

	public void onPause() {
		isPlay = false;
	}

	void Start () {
		GenPoint = screenCamera.WorldToScreenPoint (Ob_Gen.position);
		GenArea ();
	}

	void Update () {
		
	}

    public void OnQuit()
    {
        PlayerPrefs.SetInt("record", player.record);
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void GenArea() {
        if (Ob_areas.Length > 0) {
            Instantiate (Ob_areas [Random.Range(0, Ob_areas.Length)], Ob_Gen.position, Ob_Gen.rotation);
		}
	}
}
