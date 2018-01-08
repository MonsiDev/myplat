using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Transform Grounded;
	public bool isGrounded;
	public bool isRun = false;
	public Animator animator;
	public float JumpForce = 15.0f;
	public int life = 3;
	public int MaxLife = 3;
	public int score = 0;
    public int record = 0;
	public GameState gState;
	public GameObject UIRefresh;
	public GameObject UIPause;
    public GameObject UIQuit;
	public Text ScoreText;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float lastTime = 0.0f;
    public Text RecordUI;
    public GameObject RecUI;

    private Collider2D[] colliders;

	void Start () {
        record = PlayerPrefs.GetInt("record");
	}

	void FixedUpdate() {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	}

	public void onRun() {
		isRun = true;
	}

	public void onIdle() {
		isRun = false;
	}

	void Update () {
		animator.SetBool ("isGrounded", isGrounded);
		animator.SetBool ("isRun", isRun);
		ScoreText.text = score.ToString ();
        if(score > record)
        {
            record = score;
        }
        RecordUI.text = record.ToString();
	}

	public void onJump() {
		if (isRun == true && isGrounded == true) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * JumpForce, ForceMode2D.Impulse);
		}
	}

	void RefreshUI(){
		UIRefresh.SetActive(true);
		UIPause.SetActive(false);
        UIQuit.SetActive(true);
        RecUI.SetActive(true);
		gState.isPlay = false;
		isRun = false;
	}

	public void onRefresh() {
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "obstacle" && isRun == true) {
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * (JumpForce / 1.45f), ForceMode2D.Impulse);
			other.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
			life--;
			if (life < 1) {
				RefreshUI ();
			}
		}
		if (other.tag == "coin") {
			score++;
			if(score % 70 == 0){
				Time.timeScale = 0;
					Advertisement.Show ();
				Time.timeScale = 1;
			}
			Destroy (other.gameObject);
		}
		if (other.tag == "life") {
			life++;
			if (life > MaxLife) {
				life = MaxLife;
			}
			Destroy (other.gameObject);
		}
	}
}
