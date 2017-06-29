using UnityEngine;

public class Rolling : MonoBehaviour {

	public GameObject barrelPoinit;
	private const float speed = 0.14f;
	private float rotateIncrement = 0f;

	private void Update() {
		transform.Rotate(Vector3.forward, Time.deltaTime * rotateIncrement);
	}

	public void StartAnimation() {
		iTween.MoveTo(gameObject, iTween.Hash(
				"position", barrelPoinit.transform.position,
				"speed", speed,
				"easetype", iTween.EaseType.easeOutBounce,
				"oncomplete", "DestroyThis",
				"oncompletetarget", gameObject
			)
		);

		rotateIncrement = 35f;
	}

	private void DestroyThis() {
		Debug.Log("Animation Ended");
		rotateIncrement = 0f;
	}
}
