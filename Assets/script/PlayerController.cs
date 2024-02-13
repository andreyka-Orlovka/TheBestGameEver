
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //приватные поля
    private float _fallVelocity;

    private CharacterController _characterController;

    private Vector3 _moveVector;
    
    //публичные поля
    [SerializeField] private float gravity = 9.8f;
    
    [SerializeField] private float jumpForse;

    [SerializeField] private int jump;
    private int _jump1;
    
    public float speed;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        //гравитация
        if (_characterController.isGrounded)
        {
            
        }
        else
        {
            _fallVelocity += gravity * Time.fixedDeltaTime;
        }

        _characterController.Move(_moveVector * (speed * Time.fixedDeltaTime));
        
        _characterController.Move(Vector3.down * (Time.fixedDeltaTime * _fallVelocity));
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            _jump1 = jump;

            _fallVelocity = 0;
        }

        //прыжок
        if (Input.GetKeyDown(KeyCode.Space) && _jump1 > 0)
        {
            _fallVelocity = -jumpForse;

            _jump1 -= 1;
        }


        //ДВИЖЕНИЕ
        _moveVector = Vector3.zero;

        //движение на кнопку W 
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        //движение на кнопку S
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        //движение на кнопку A
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        //движение на кнопку D
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
    }
}
