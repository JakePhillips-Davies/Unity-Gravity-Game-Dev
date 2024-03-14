using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    void FixedUpdate()
    {
        transform.Rotate(direction.normalized * speed * Time.fixedDeltaTime);
    }
}
