using UnityEngine;
using UnityEngine.UI;

public class ShipBlobSpawner : MonoBehaviour
{
    //---          ---//
    public GameObject prefab;
    public GameObject ship;
    public GameObject parent;
    Rigidbody rb;

    int force = 150000;
    public int forceMult = 10;
    public int period = 4;
    int counter;
    Vector3 initialForce;
    //---          ---//

    void OnEnable()
    {
        counter = period;

        parent = GameObject.FindWithTag("System");
    }

    void FixedUpdate()
    {

        if(counter == period){
            GameObject obj = Instantiate(prefab, transform.position, new Quaternion(0, 0, 0, 0), parent.transform) as GameObject;

            rb = obj.GetComponent<Rigidbody>();

            initialForce = transform.forward * force * forceMult;
            rb.velocity += ship.GetComponent<Rigidbody>().velocity;
            rb.AddForce(initialForce, ForceMode.Impulse);

            counter = 0;
        }else counter++;
    }
}
