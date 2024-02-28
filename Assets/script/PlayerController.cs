
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //приватные поля
    private float _fallVelocity;

    private CharacterController _characterController;

    private Vector3 _moveVector;
    
    private Animator anim;    
    
    //публичные поля
    [SerializeField] private float gravity = 9.8f;
    
    [SerializeField] private float jumpForse;

    [SerializeField] private int jump;
    private int _jump1;
    
    [SerializeField] private float speedBase;
    private float speed;
    private float timeSpeed;
    [SerializeField] private float timeSpeedMax; 
    [SerializeField] private float acceleration;




    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        //гравитация
        if (!_characterController.isGrounded)
        {
            _fallVelocity += gravity * Time.fixedDeltaTime;
        }

        _characterController.Move(_moveVector * (speed * Time.fixedDeltaTime));
        
        _characterController.Move(Vector3.down * (Time.fixedDeltaTime * _fallVelocity));
    }

    
    private void Update()
    {
        #region передвижение
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


        
        _moveVector = Vector3.zero;

        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            anim.SetBool("run", false);
        }
        //движение на кнопку W 
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            
            anim.SetBool("run", true);
            
            //ускорение игрока
            if (timeSpeedMax >= timeSpeed)
            {
                timeSpeed = timeSpeed + Time.deltaTime;

                speed = speed + acceleration * Time.deltaTime;
            }
        }
        else
        {
            timeSpeed = 0;
            
            speed = speedBase;
        }

        //движение на кнопку S
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
                        
            anim.SetBool("run", true);
        }

        //движение на кнопку A
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
                        
            anim.SetBool("run", true);
        }

        //движение на кнопку D
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            
            anim.SetBool("run", true);
        }
        #endregion
    }
}

