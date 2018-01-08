using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public Player player;
	public SpriteRenderer LifeUI;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LifeUI.size = new Vector2 (0.8666667f * player.life, 0.69f);
	}
}
