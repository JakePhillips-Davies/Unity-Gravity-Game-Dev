using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    //---             ---//
    private Vector2 screenCenter, dotDistance;
    private float rotation;
    public int lookSpeed;
    public GameObject ship;
    //---             ---//
    void Update()
    {
        MoveDot();
        RotateShip();
    }

    void MoveDot()
    {
        screenCenter.y = Screen.height * 0.5f;
        screenCenter.x = Screen.width * 0.5f;

        dotDistance.y = (Input.mousePosition.y - screenCenter.y) / screenCenter.y;
        dotDistance.x = (Input.mousePosition.x - screenCenter.x) / screenCenter.y;

        dotDistance = Vector2.ClampMagnitude(dotDistance, 1f);

        transform.localPosition = new Vector3(dotDistance.x*1.5f, dotDistance.y*1.5f, 0f);
    }

    void RotateShip()
    {
        rotation = Mathf.Lerp(rotation, Input.GetAxisRaw("Rotational"), 0.1f);
        ship.transform.Rotate(-dotDistance.y * lookSpeed * Time.deltaTime, dotDistance.x * lookSpeed * Time.deltaTime, rotation * lookSpeed * 2 * Time.deltaTime);
    }
}
