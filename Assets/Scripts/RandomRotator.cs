using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public float tumble;

	void Start() {
		/*
		 * Give our asteroid a random rotation vector by using insideUnitSphere.
		 */
		rigidbody.angularVelocity = Random.insideUnitSphere * this.tumble;
	}
}
