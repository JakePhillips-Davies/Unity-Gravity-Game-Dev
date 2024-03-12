using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //---                      ---//
    public new GameObject camera;
    public GameObject ship;

    //||-- movement --||//

    float forwardInput;
    float rightInput;
    float upInput;
    Vector3 shipForce;
    public int shipSpeed;
    Rigidbody rb;

    //||-- movement --||//

    public KeyCode activate;
    public KeyCode freeCam;
    //---                      ---//

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Input.mousePosition.Set(Screen.width * 0.5f, Screen.height * 0.5f, 0f);

        rb = ship.GetComponent<Rigidbody>();

        rb.drag = 0.5f;
    }

    void Update()
    {
        if(Input.GetKeyDown(activate)){
            ControlSwapper cs = GetComponent<ControlSwapper>();
            cs.Activate();
        }
        if(Input.GetKeyDown(freeCam))
        {
            ShipFreeCam cam = camera.GetComponent<ShipFreeCam>();
            cam.enabled = !cam.enabled;
        }

    }

    void FixedUpdate()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        rightInput = Input.GetAxisRaw("Horizontal");
        upInput = Input.GetAxisRaw("UppyDowny");

        shipForce = (transform.forward * forwardInput + transform.right * rightInput + transform.up * upInput) * shipSpeed * rb.mass;

        rb.AddForce(shipForce);
    }
}
