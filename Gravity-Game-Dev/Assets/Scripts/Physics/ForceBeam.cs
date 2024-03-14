using UnityEngine;

public class ForceBeam : MonoBehaviour
{
    public float force;
    Rigidbody rb;
    void OnTriggerStay(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force * rb.mass);
    }
}
