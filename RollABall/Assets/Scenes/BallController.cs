using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    [SerializeField] private Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;
    public float jumpForce = 1f;
    bool isGrounded = false;
    void Start()
    {
    
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void Update()
    {

        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up; // "a += b" <=> "a = a + b"
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        

        OnMove?.Invoke(inputVector); // When is this used?

        MoveBall(inputVector);


        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        sphereRigidbody.linearVelocity = new Vector3(inputXZPlane.x * ballSpeed, sphereRigidbody.linearVelocity.y, inputXZPlane.z * ballSpeed);
    }


}
