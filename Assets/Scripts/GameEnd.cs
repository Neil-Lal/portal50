using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {

	public Text endText;
	private Boolean endReached;

	// Use this for initialization
	private void Start () {
		endReached = false;
	}

	private void Update() {

		// End reached and user presses enter - start level over
		if (endReached) {
			if (Input.GetAxis("Submit") == 1) {
				endText.enabled = false;
				endReached = false;
				SceneManager.LoadScene("PortalScene");
			}
		}
	}

	private IEnumerator OnTriggerEnter(Collider col) {

		// Make sure triggering object is player and they haven't already reached the end
		if (col.gameObject.tag == "Player" && !endReached) {
			
			// Add game winning text
			endText.enabled = true;
			endText.text = "You won!\n";
			yield return new WaitForSeconds(2f);

			// Set flag for end being reached
			endReached = true;
			endText.text = "Press enter or space to go again.";
		}
	}
}
