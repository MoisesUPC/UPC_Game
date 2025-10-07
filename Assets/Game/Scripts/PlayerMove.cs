using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    // Llamemos a los inputs
    InputAction moveAction;
    InputAction jumpAction;

    // Los campos serializados pueden ser modificados en el editor
    [SerializeField] private float speedX;
    [SerializeField] private float jumpImpulse;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        // Al multiplicar el componente en x por la velocidad tenemos la velocidad relativa en x
        body.linearVelocityX = move.x * speedX;
        if (move.x != 0)
        {
            sprite.flipX = move.x < 0 ? true : false;
        }

        if (jumpAction.WasPressedThisFrame())
        {
            body.linearVelocityY = jumpImpulse;
        }
    }
}
