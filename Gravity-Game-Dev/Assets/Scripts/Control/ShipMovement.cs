using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //---                      ---//
    public KeyCode activate;
    //---                      ---//

    void Update()
    {
        if(Input.GetKeyDown(activate)){
            ControlSwapper cs = GetComponent<ControlSwapper>();
            cs.Activate();
        }

    }
}
