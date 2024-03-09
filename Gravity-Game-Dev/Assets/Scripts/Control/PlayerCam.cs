using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PlayerCam : MonoBehaviour
{
    //---                      ---//

    public float sensitivity;

    private float yRot;
    private float xRot;

    public GameObject Body;

    public float reach;
    private RaycastHit hit;
    public KeyCode activateKey;

    //---                      ---//
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        yRot += Input.GetAxisRaw("Mouse X") * sensitivity;

        xRot -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        Body.transform.localRotation = Quaternion.Euler(0, yRot, 0);

        transform.position = Body.transform.position + Body.transform.up * 1.5f;

        activatableHandler();
    }

    void activatableHandler()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, reach)){
            if(Input.GetKeyDown(activateKey) && (hit.transform != null) && (hit.collider.GetComponent<Activator>() != null))
                hit.collider.GetComponent<Activator>().Activate();
        }
    }
}
