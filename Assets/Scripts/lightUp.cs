using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour {
	public Material lightUpMaterial;
	public Material hoverMaterial;
	//public GameObject gameLogic;
	public GameLogic gameLogic;
	private Material defaultMaterial;
	private ParticleSystem.EmissionModule particle;

	void Start() {
		defaultMaterial = GetComponent<MeshRenderer>().material; //Save our initial material as the default
		particle = GetComponentInChildren<ParticleSystem>().emission;
		particle.enabled = false; //Start without emitting particles
		//gameLogic = GameObject.Find ("gameLogic");
	}

	public void patternLightUp(float duration) { //The lightup behavior when displaying the pattern
		StartCoroutine(lightFor(duration));
	}

	public void gazeLightUp() {
		GetComponent<MeshRenderer>().material = hoverMaterial; //Assign the hover material
		particle.enabled = true; //Turn on particle emmission

		//this.GetComponent<GvrAudioSource>().Play();
		//gameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);
	}

	public void playerSelection() {
		//GetComponent<GameLogic>().playerSelection(gameObject);
		gameLogic.playerSelection(gameObject);
		GetComponent<GvrAudioSource>().Play();
	}

	public void aestheticReset() {
		GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
		particle.enabled = false; //Turn off particle emission
	}

	public void patternLightUp() { //Lightup behavior when the pattern shows.
		GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		particle.enabled = true; //Turn on particle emmission
		GetComponent<GvrAudioSource>().Play(); //Play the audio attached
	}

	IEnumerator lightFor(float duration) { //Light us up for a duration. Used during the pattern display
		patternLightUp();
		yield return new WaitForSeconds(duration - .1f);
		aestheticReset();
	}
}
