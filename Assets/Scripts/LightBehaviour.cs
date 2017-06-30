using UnityEngine;

public class LightBehaviour : MonoBehaviour {
	public Light spotLight;
	public Light[] pointLight;

	private static float spotLightAngle = 0;
	private static float pointLightIntensity = 0;


	void Start () {
		LightDown();
	}
	
	void Update () {
		spotLight.spotAngle += spotLightAngle;
		if (spotLight.spotAngle >= 100) {
			spotLightAngle = 0;
		}

		foreach (Light light in pointLight) {
			light.intensity += pointLightIntensity;
		}
	}

	public static void StartIllumination() {
		spotLightAngle = 0.5f;
		pointLightIntensity = 0.05f;
	}

	public void LightDown() {
		spotLight.spotAngle = 1;

		foreach (Light light in pointLight) {
			light.intensity = 0;
		}
	}
}
