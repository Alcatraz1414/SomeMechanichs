using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [Header("Move Control Settings")]
    [SerializeField] private InputAction movementKeys;
    private float currentSpeed = 10f;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float gravityModifier = 0.95f;
    [SerializeField] private float jumpPower = 0.30f;
    private Vector3 heightMovement;
    private bool isJumping = false;

 


    [SerializeField] private CharacterController characterController;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private Transform[] jumpRayStartPoint;


    [Header("Mouse Control Options")]
    [SerializeField] float maxViewAngle = 50f;

    private Transform mainCamera;

    private Animator animator;



    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = GameObject.FindWithTag("CameraPoint").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    #region pek �nemli de�il
    private void OnEnable()
    {
        movementKeys.Enable();
    }
    private void OnDisable()
    {
        movementKeys.Disable();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputSystem();
        Moving();
        Rotate();

        if (transform.position.y >= 4.5f) // �ok y�kse�e ��k�p engelleri a�mas�n diye

        {
            Vector3 newPosition = transform.position;
            newPosition.y = 4.49f;
            transform.position = newPosition;
        }
    }

    private void FixedUpdate()
    {
        /*  //normalde buradalard� ama b�yle yap�nca elime ald���m obje d�nerken veya y�r�rken �ok titre�iyor, bu �ekilde daha az titriyor
        Moving();
        Rotate();

        if (transform.position.y >= 4.5f) // �ok y�kse�e ��k�p engelleri a�mas�n diye

        {
            Vector3 newPosition = transform.position;
            newPosition.y = 4.49f;
            transform.position = newPosition;
        }*/
    }


    private void InputSystem()
    {
        //hareket i�in y�n de�erleri
        horizontalInput = movementKeys.ReadValue<Vector2>().x;
        verticalInput = movementKeys.ReadValue<Vector2>().y;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            isJumping = true;
        }
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }

    private void Moving()
    {
        if (isJumping)
        {
            heightMovement.y = jumpPower;
            isJumping = false;
        }
        heightMovement.y -= gravityModifier * Time.deltaTime; // YER�EK�M� KUVVET�


        Vector3 localVerticalVector = transform.forward * verticalInput;
        Vector3 localHorizontalVector = transform.right * horizontalInput;

        Vector3 movementVector = localVerticalVector + localHorizontalVector; //sa�-sol- yukar�,a�a�� vectorleri topluyor
        movementVector.Normalize(); // burda ise her vekt�r� 1 e e�itliyor, �apraz giderken daha h�zl� olmas�n diye
        movementVector *= currentSpeed * Time.deltaTime; // h�z�n� veriyoruz
        characterController.Move(movementVector + heightMovement);
        //print(currentSpeed);
        if (characterController.isGrounded)
        {
            heightMovement.y = 0;
        }


    }


    //MOUSE KONUMUNU BULMA
    private Vector2 MouseInput()
    {
        return new Vector2(Mouse.current.delta.x.value, Mouse.current.delta.y.value);
    }

    //KAMERAYI D�ND�RME
    private void Rotate()
    {
        //print(mainCamera.eulerAngles.x);

        if (mainCamera != null)
        {
            mainCamera.rotation = Quaternion.Euler(mainCamera.rotation.eulerAngles + new Vector3(-MouseInput().y, 0f, 0f));
        }

        if (mainCamera.eulerAngles.x > maxViewAngle && mainCamera.eulerAngles.x < 180f)
        {
            mainCamera.rotation = Quaternion.Euler(maxViewAngle, mainCamera.eulerAngles.y, mainCamera.eulerAngles.z);
        }
        else if (mainCamera.eulerAngles.x > 180f && mainCamera.eulerAngles.x < 360 - maxViewAngle)
        {
            mainCamera.rotation = Quaternion.Euler(360f - maxViewAngle, mainCamera.eulerAngles.y, mainCamera.eulerAngles.z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + MouseInput().x, transform.eulerAngles.z);
        }
    }

    
}
