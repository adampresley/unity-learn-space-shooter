using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public float fireRate = 0.5F;
	public Transform shotSpawn;

	private float nextFire = 0.0f;

	void FixedUpdate() {
		/*
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		*/
		float moveHorizontal = Input.GetAxis("Mouse X");
		float moveVertical = Input.GetAxis("Mouse Y");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * this.speed;

		rigidbody.position = new Vector3(
			Mathf.Clamp(rigidbody.position.x, this.boundary.xMin, this.boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z, this.boundary.zMin, this.boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -this.tilt);
	}

	void Update() {
		/*
		 * Instantiate an instance of a bolt for shooting
		 */
		if (Input.GetButton("Fire1") && Time.time > this.nextFire) {
			this.nextFire = Time.time + this.fireRate;
			Instantiate(this.shot, this.shotSpawn.position, this.shotSpawn.rotation);
			audio.Play();
		}
	}
}
