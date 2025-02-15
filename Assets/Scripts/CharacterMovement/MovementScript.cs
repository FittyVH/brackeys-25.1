using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [Header("Action Map Reference")]
    private string actionMapName = "Player";

    [Header("Input Action")]
    private InputAction moveAction;

    [Header("Action Map References")]
    [SerializeField] private string move = "Move";

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset inputActions;

    //section for setting up components in the inspector
    [Header("Components")]
    private Rigidbody2D rb;

    //section for setting variables
    [Header("Variables")]
    [SerializeField] private float speed;


    public Vector2 MoveInput { get; private set; }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Awake()
    {
        moveAction = inputActions.FindActionMap(actionMapName).FindAction(move);
        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = MoveInput * speed;

    }

}
