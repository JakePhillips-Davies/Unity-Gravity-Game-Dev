using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFreeCam : MonoBehaviour
{

    public float sensitivity;
    private float yRot;
    private float xRot;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        yRot += Input.GetAxisRaw("Mouse X") * sensitivity;
        yRot = Mathf.Clamp(yRot, -95, 95);
        xRot -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 60f);

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Input.mousePosition.Set(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
