using UnityEngine;
using UnityEngine.UI;

public class ShipBombGun : MonoBehaviour
{
    //---          ---//
    public GameObject prefab;
    public GameObject ship;
    public GameObject parent;
    Rigidbody rb;
    Bomb bm;

    public KeyCode shoot;
    int force = 50;
    public int forceMult = 10;
    public int power = 20;
    Vector3 initialForce;
    //---          ---//

    void OnEnable()
    {
        parent = GameObject.FindWithTag("System");
    }

    void Update()
    {

        if(Input.GetKeyDown(shoot)){
            GameObject obj = Instantiate(prefab, transform.position, new Quaternion(0, 0, 0, 0), parent.transform) as GameObject;

            rb = obj.GetComponent<Rigidbody>();
            bm = obj.GetComponent<Bomb>();

            bm.power = power;

            initialForce = transform.forward * force * forceMult;
            rb.velocity += ship.GetComponent<Rigidbody>().velocity;
            rb.AddForce(initialForce, ForceMode.Impulse);
        }
    }
}
