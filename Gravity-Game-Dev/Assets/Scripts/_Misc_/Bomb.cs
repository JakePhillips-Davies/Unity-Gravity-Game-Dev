using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Bomb : MonoBehaviour
{
    public int power;
    public float timerLength;
    float time = 0;

    int force = 10000000;
    int radius = 700;
    
    public GameObject boom;

    void FixedUpdate()
    {
        if(time > timerLength){

            GoBoom();

            Instantiate(boom, transform.position, transform.rotation);

            Destroy(this);

        }
        else time += Time.fixedDeltaTime;
    }

    void GoBoom()
    {
        radius *= power;
        force *= power;

        AddForceToAll();
    }
    void AddForceToAll()
    {
        Rigidbody rb;
        Vector3 pos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(pos, radius);

        foreach(Collider hitObject in colliders){
            rb = hitObject.GetComponent<Rigidbody>();

            if(rb != null){
                rb.AddExplosionForce(force, pos, radius);
            }
        }
    }
}
