using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //---                                ---//

    //|| movement ||//
    [Header("Movement")]
    public int moveSpeed;
    public float groundDrag;
    private float forwardInput;
    private float rightInput;
    private Vector3 moveDirection;

    public float jumpForce;
    private bool readyToJump;
    //|| movement ||//

    //|| key binds ||//
    [Header("Key Binds")]
    public KeyCode jumpKey;
    //|| key binds ||//

    //|| grounding ||//
    private bool grounded;
    //|| grounding ||//
    private Rigidbody rb;

    public GameObject ship;

    //---                                ---//

    void Start() 
    {
        rb = GetComponent<Rigidbody>();

        readyToJump = true;
    }

    void Update()
    {
        GroundCheck();
        GetDirection();

        if(Input.GetKey(jumpKey))
            Jump();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void GetDirection()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        rightInput = Input.GetAxisRaw("Horizontal");

        moveDirection = transform.forward * forwardInput + transform.right * rightInput;
    }

    void MovePlayer()
    {
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
        else
            rb.AddForce(-transform.up * 9.81f, ForceMode.Force);
    }

    void GroundCheck()
    {
        grounded = Physics.Raycast(transform.position, -transform.up, 2.2f);

        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    void Jump()
    {
        if(grounded && readyToJump){
            readyToJump = false;

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(ResetJump), 1);
        }
    }
    void ResetJump()
    {
        readyToJump = true;
    }
}
