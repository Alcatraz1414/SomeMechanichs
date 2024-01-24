using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
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

    //[SerializeField ]private AnimatorController anim;
    private Animator animator;



    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
    }

    #region pek önemli deðil
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

    }

    private void FixedUpdate()
    {
        Moving();

        if (transform.position.y >= 4.5f) // çok yükseðe çýkýp engelleri aþmasýn diye

        {
            Vector3 newPosition = transform.position;
            newPosition.y = 4.49f;
            transform.position = newPosition;
        }
    }


    private void InputSystem()
    {
        //hareket için yön deðerleri
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
        heightMovement.y -= gravityModifier * Time.deltaTime; // YERÇEKÝMÝ KUVVETÝ


        Vector3 localVerticalVector = transform.forward * verticalInput;
        animator.SetFloat("Dikey", horizontalInput);
        Vector3 localHorizontalVector = transform.right * horizontalInput;
        animator.SetFloat("Yatay", verticalInput);


        Vector3 movementVector = localVerticalVector + localHorizontalVector; //sað-sol- yukarý,aþaðý vectorleri topluyor
        movementVector.Normalize(); // burda ise her vektörü 1 e eþitliyor, çapraz giderken daha hýzlý olmasýn diye
        movementVector *= currentSpeed * Time.deltaTime; // hýzýný veriyoruz
        characterController.Move(movementVector + heightMovement);
        //print(currentSpeed);
        if (characterController.isGrounded)
        {
            heightMovement.y = 0;
        }


    }


}
