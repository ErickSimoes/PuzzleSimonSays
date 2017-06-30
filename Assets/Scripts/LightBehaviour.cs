using UnityEngine;

public class LightBehaviour : MonoBehaviour {
	public Light spotLight;
	public Light[] pointLight;

	private static float spotLightAngle = 0;
	private static float pointLightIntensity = 0;
	private bool intesityMax = false;
	private float lastTime = 0;

	void Start () {
		LightDown();
	}
	
	void Update () {
		spotLight.spotAngle += spotLightAngle;
		if (spotLight.spotAngle >= 100) {
			spotLightAngle = 0;
		}

		foreach (Light light in pointLight) {
			if (!intesityMax) {
				light.intensity += pointLightIntensity;
				if (light.intensity >= 8)
					intesityMax = true;
			} else {
				if (Time.time - lastTime >= 0.5) {
					light.intensity = Random.Range(6, 8); ;
					lastTime = Time.time;
				}
			}

		}
	}

	public static void StartIllumination() {
		spotLightAngle = 1;
		pointLightIntensity = 0.1f;
	}

	public void LightDown() {
		spotLight.spotAngle = 1;

		foreach (Light light in pointLight) {
			light.intensity = 0;
		}
	}
}
