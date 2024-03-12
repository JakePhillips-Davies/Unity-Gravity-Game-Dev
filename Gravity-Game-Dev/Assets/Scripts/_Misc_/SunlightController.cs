using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SunlightController : MonoBehaviour
{
    new HDAdditionalLightData light;
    public float intensity;
    public float sunPower;
    void Start()
    {
        light = GetComponent<HDAdditionalLightData>();
    }
    void FixedUpdate()
    {
        Transform cam = Camera.main.transform;

        transform.LookAt(cam.position);

        intensity = sunPower / (cam.position.magnitude / 1000);

        light.intensity = intensity;
    }
}
