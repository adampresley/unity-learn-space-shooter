using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.name);

		if (other.tag != "Boundary") {
			if (other.tag == "Player") {
				Instantiate(this.playerExplosion, other.transform.position, other.transform.rotation);
				this.gameController.endGame();
			}

			this.gameController.addScore(this.scoreValue);
			Instantiate(this.explosion, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			this.gameController = gameControllerObject.GetComponent<GameController>();
		}

		if (this.gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
	}
}
