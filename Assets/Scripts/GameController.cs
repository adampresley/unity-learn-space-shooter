using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float waveWait;
	public float startWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	public void addScore(int newScoreValue) {
		this.score += newScoreValue;
		this.updateScore();
	}

	public void endGame() {
		this.gameOverText.text = "Game Over!";
		this.gameOver = true;
	}

	IEnumerator spawnWaves() {
		yield return new WaitForSeconds(this.startWait);

		while (true) {
			for (int i = 0; i < this.hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), this.spawnValues.y, this.spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; // No rotation == Quaternion.identity

				Instantiate(this.hazard, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(this.spawnWait);
			}

			yield return new WaitForSeconds(this.waveWait);

			if (this.gameOver) {
				this.restartText.text = "Press 'R' for Restart";
				this.restart = true;
				break;
			}
		}
	}

	void Start() {
		Screen.lockCursor = true;

		this.gameOver = false;
		this.restart = false;
		this.score = 0;

		this.restartText.text = "";
		this.gameOverText.text = "";
		this.updateScore();

		StartCoroutine(spawnWaves());
	}

	void Update() {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			Application.Quit();
		}

		if (this.restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	void updateScore() {
		this.scoreText.text = "Score: " + this.score;
	}
}
