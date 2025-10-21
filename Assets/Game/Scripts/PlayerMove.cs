using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator animator;
    // Llamemos a los inputs
    private InputAction moveAction;
    private InputAction jumpAction;
    // Campo que detecte el salto
    private bool isInGround;

    // Los campos serializados pueden ser modificados en el editor
    [SerializeField] private float speedX;
    [SerializeField] private float jumpImpulse;

    // Vamos a agregar propiedades para detectar un piso
    [Header("Ground Detection Fields")]
    [SerializeField] private Transform groundDetection;
    [SerializeField] private float radiusDetection;
    [SerializeField] private LayerMask layerDetection;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        Collider2D col = Physics2D.OverlapCircle(groundDetection.position, radiusDetection, layerDetection);
        // Si el collider existe, es porque hemos detectado un piso con nuestro detector.
        isInGround = col != null;

        Vector2 move = moveAction.ReadValue<Vector2>();
        // Al multiplicar el componente en x por la velocidad tenemos la velocidad relativa en x
        body.linearVelocityX = move.x * speedX;
        if (move.x != 0)
        {
            sprite.flipX = move.x < 0 ? true : false;
        }

        if (jumpAction.WasPressedThisFrame() && isInGround)
        {
            body.linearVelocityY = jumpImpulse;
        }

        // Acá vamos a controlar el animator
        animator.SetInteger("moveX", (int)move.x);
        animator.SetBool("IsInGround", isInGround);
        animator.SetFloat("speedY", body.linearVelocityY);
    }
}
