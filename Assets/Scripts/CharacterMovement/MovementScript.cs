using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [Header("Action Map Reference")]
    private string actionMapName = "Player";

    [Header("Input Action")]
    private InputAction moveAction;
    private InputAction dashAction;

    [Header("Action Map References")]
    [SerializeField] private string move = "Move";
    [SerializeField] private string dash = "Sprint";

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset inputActions;

    //section for setting up components in the inspector
    [Header("Components")]
    private Rigidbody2D rb;

    //section for setting variables
    [Header("Variables")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private bool isDashing;


    public Vector2 MoveInput { get; private set; }
    public bool DashInput { get; private set; }

    private void OnEnable()
    {
        moveAction.Enable();
        dashAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        dashAction.Disable();
    }

    private void Awake()
    {
        moveAction = inputActions.FindActionMap(actionMapName).FindAction(move);
        dashAction = inputActions.FindActionMap(actionMapName).FindAction(dash);
        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        dashAction.performed += context => DashInput = true;
        dashAction.canceled += context => DashInput = false;



    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

    }

    private void FixedUpdate()
    {

        if (DashInput & !isDashing & MoveInput != Vector2.zero)
        {
            StartCoroutine(DashTime());
        }
        else
        {
            rb.linearVelocity = MoveInput * speed;
        }


        if (MoveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(MoveInput.y, MoveInput.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }


    }


    private IEnumerator DashTime()
    {
        isDashing = false;
        rb.linearVelocity = MoveInput * dashSpeed;
        yield return new WaitForSeconds(0.1f);
        isDashing = true;
        yield return new WaitForSeconds(2);
        isDashing = false;
    }

}
