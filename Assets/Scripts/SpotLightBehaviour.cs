using UnityEngine;

public class SpotLightBehaviour : MonoBehaviour {
	public Light spotLight;
	private static float incrementAngle = 0;

	// Use this for initialization
	void Start () {
		spotLight.spotAngle = 1;
	}
	
	// Update is called once per frame
	void Update () {
		spotLight.spotAngle += incrementAngle;
		print(spotLight.spotAngle);
		if (spotLight.spotAngle >= 100) {
			incrementAngle = 0;
		}
	}

	public static void StartIncrement() {
		incrementAngle = 0.5f;
	}
}
