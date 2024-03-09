using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightConrtoller : MonoBehaviour
{
    public new GameObject light;
    void OnEnable()
    {
        light.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        light.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        light.SetActive(false);
    }
}
