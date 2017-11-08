using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject Sword;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
	public float rollSpeed = 5f;
	private float addRoll = 0f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    public float currentSpeed;

    private Vector3 moveDirection = Vector3.zero;
    private float gravity = -20.0f;

    private float moveSpeedX = 5f;
    private float moveSpeedY;
    private Vector3 moveInput;
    private Animator _panimator;
    private Vector3 rotateInput;
	private float _rollInput;

    Transform cameraT;

    private CharacterController controller;

    // Use this for initialization
    void Start()
    {
        _panimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

    }
	// Update is called once per frame
	void Update () {
        //MOVIMIENTO PERSONAJE(Controller) 
        Vector2 input = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        moveSpeedY += Time.deltaTime * gravity;
        float targetSpeed = 0f;

        if (controller.isGrounded){
            moveSpeedY = 0;
        }
		//Está Rolling Dodging
		_rollInput = Input.GetAxisRaw("Jump");

		if (_rollInput > 0.1 && Input.GetButtonDown("Jump"))
		{
			if (!_panimator.GetCurrentAnimatorStateInfo(0).IsName("Sprinting Forward Roll"))
			{
				addRoll = rollSpeed;
				_panimator.SetFloat("Roll", _rollInput);
			}
		}
		else
		{
			if (addRoll > 0)
			{
				addRoll -= 1f;
				_panimator.SetFloat("Roll", 0);
			}
		}


        //Está atacando
        if (_panimator.GetCurrentAnimatorStateInfo(0).IsName("slash4"))
        {

            Sword.GetComponent<SwordLogic>().Atacando();
            targetSpeed = walkSpeed * inputDir.magnitude;
        }
        else
        {
            
            targetSpeed = runSpeed* inputDir.magnitude;
        }
        //Actually move the player
        
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed + addRoll, ref speedSmoothVelocity, speedSmoothTime);
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * moveSpeedY;
        controller.Move(velocity * Time.deltaTime);

        //Rotation of the player
        transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * runSpeed, 0f));

        // Activate animation
        _panimator.SetFloat("Attack", Input.GetAxis("Fire1"));//ATAQUE
        _panimator.SetFloat("Movedf", Input.GetAxis("Vertical"));//ACTIVAMOS LA CONDICION/PARAMETRO DEL ANIMATOR para mover

	}
}
