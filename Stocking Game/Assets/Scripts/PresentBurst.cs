using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBurst : MonoBehaviour {

	// this is the particle system
	public GameObject confetti;

	// when the present is destroyed...
	void OnDestroy () {

		Instantiate (confetti, transform.position, Quaternion.identity);

	}

}
