using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private CharacterController _characterController;
    private float _ySpeed;
    

    void Start()
    {
        
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_characterController.isGrounded)
        {
            _ySpeed = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                _ySpeed = jump;
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = _ySpeed;

        _characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.right)
        {
            

            
        }
        else
        {
            
        }
    }
}
