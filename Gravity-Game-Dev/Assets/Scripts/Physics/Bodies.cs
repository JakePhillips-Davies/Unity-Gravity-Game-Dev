using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodies : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tm;
    public Vector3 initForce;
    
    void Awake()
    {
        tm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initForce, ForceMode.Impulse);
    }
}
