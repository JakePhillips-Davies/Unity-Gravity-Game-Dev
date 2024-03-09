using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //---                      ---//
    public new GameObject camera;
    public KeyCode activate;
    public KeyCode freeCam;
    //---                      ---//

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Input.mousePosition.Set(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
    }

    void Update()
    {
        if(Input.GetKeyDown(activate)){
            ControlSwapper cs = GetComponent<ControlSwapper>();
            cs.Activate();
        }
        if(Input.GetKeyDown(freeCam))
        {
            ShipFreeCam cam = camera.GetComponent<ShipFreeCam>();
            cam.enabled = !cam.enabled;
        }

    }

    void FixedUpdate()
    {

    }
}
