using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFreeCam : MonoBehaviour
{

    public float sensitivity;
    private float yRot;
    private float xRot;
    RaycastHit hit;
    public KeyCode lClick;
    public GameObject dot;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        dot.SetActive(false);
    }

    void Update()
    {
        yRot += Input.GetAxisRaw("Mouse X") * sensitivity;
        yRot = Mathf.Clamp(yRot, -95, 95);
        xRot -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 60f);

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0);

        Input.mousePosition.Set(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Input.mousePosition.Set(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        dot.SetActive(true);
    }
}
