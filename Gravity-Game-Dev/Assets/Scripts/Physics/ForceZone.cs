using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    public float force;
    Rigidbody rb;
    void OnTriggerStay(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * force, ForceMode.Force);
    }
}
