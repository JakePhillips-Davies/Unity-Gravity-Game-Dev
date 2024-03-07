using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSeat : MonoBehaviour
{
    public KeyCode activate;
    void OnMouseOver()
    {
        if(Input.GetKeyDown(activate)){
            ControlSwapper cs = GetComponent<ControlSwapper>();
            cs.Activate();
        }
    }
}
