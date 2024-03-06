using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector3 initialForce;
    public float forceMult;
    public float distMult;
    public float randomness;
    public GameObject prefab;
    public GameObject parent;
    Rigidbody rb;
    public int period;
    public int numOfBlobs;
    int count;
    int countMax;

    void Start()
    {
        count = 0;
        countMax = numOfBlobs * period;
    }
    void FixedUpdate()
    {
        if(count % period == 0){
            GameObject obj = Instantiate(prefab, (transform.position + transform.forward * distMult), new Quaternion(0, 0, 0, 0), parent.transform) as GameObject;

            rb = obj.GetComponent<Rigidbody>();

            initialForce = (transform.forward + (new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f)) * randomness)) * forceMult;
            rb.AddForce(initialForce, ForceMode.Impulse);

            count++;
        }else count++;
        if(count >= countMax){
            gameObject.SetActive(false);
        }
    }
}