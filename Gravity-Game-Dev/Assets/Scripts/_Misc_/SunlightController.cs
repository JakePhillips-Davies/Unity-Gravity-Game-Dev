using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SunlightController : MonoBehaviour
{
    new Light light;
    void Update()
    {
        light = GetComponent<Light>();

        transform.LookAt(Vector3.zero);

        transform.forward = -transform.forward;

        light.intensity = 50000000 / (transform.position.magnitude * transform.position.magnitude);
    }
}
