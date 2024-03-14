using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControler : MonoBehaviour
{
    public Text force;
    public Text period;

    public KeyCode fUp;
    public KeyCode fDn;
    public KeyCode pUp;
    public KeyCode pDn;

    public GameObject blobbener;
    ShipBlobSpawner bloob;

    private void Start() {
        bloob = blobbener.GetComponent<ShipBlobSpawner>();
    }

    void Update()
    {
        if(Input.GetKeyDown(fUp) && Input.GetKey(KeyCode.LeftShift))
            bloob.forceMult += 10;
        else if(Input.GetKeyDown(fUp))
            bloob.forceMult += 1;
        if(Input.GetKeyDown(fDn) && Input.GetKey(KeyCode.LeftShift))
            bloob.forceMult -= 10;
        else if(Input.GetKeyDown(fDn))
            bloob.forceMult -= 1;
        if(Input.GetKeyDown(pUp))
            bloob.period += 1;
        if(Input.GetKeyDown(pDn))
            bloob.period -= 1;

        bloob.forceMult = Mathf.Clamp(bloob.forceMult, 0, 200);
        bloob.period = Mathf.Clamp(bloob.period, 1, 30);

        force.text = String.Format("{0}", bloob.forceMult);
        period.text = String.Format("{0}", bloob.period);
    }
}
