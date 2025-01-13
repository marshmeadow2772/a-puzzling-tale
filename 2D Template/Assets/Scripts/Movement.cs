using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public float speed;
    public Vector2 boxSize = new Vector2(0.25f, 0.01f);
    public Vector3 boxOffset;
    public LayerMask groundLayer;
    public Sprint Sprint;

    private Rigidbody2D rb;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float moveDirection = 0;

        // Keyboard input
        if (Input.GetKey(left) || Input.GetKey(KeyCode.LeftArrow)) moveDirection = -1;
        if (Input.GetKey(right) || Input.GetKey(KeyCode.RightArrow)) moveDirection = 1;

        // Controller input (Left Joystick and D-pad without custom axis)
        float joystickHorizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(joystickHorizontal) > 0.1f)
        {
            moveDirection = joystickHorizontal;
        }
        else
        {
            // D-pad detection using raw input
            if (Input.GetKey(KeyCode.Joystick1Button6)) moveDirection = -1; // D-pad left
            if (Input.GetKey(KeyCode.Joystick1Button7)) moveDirection = 1;  // D-pad right
        }

        if (moveDirection != 0)
        {
            rb.velocity = new Vector2(moveDirection * Sprint.speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, moveDirection < 0 ? 180 : 0, 0);
        }

        animator.SetFloat("Walk", Mathf.Abs(moveDirection));
    }

    private void HandleJump()
    {
        bool isGrounded = Physics2D.BoxCast(transform.position + boxOffset, boxSize, 0, Vector2.down, boxSize.y, groundLayer);
        Debug.Log(isGrounded);

        // Keyboard jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isGrounded)
        {
            rb.velocity = Vector2.up * 15f;
            animator.SetBool("Landed", false);
            animator.SetTrigger("Jump");
        } else if (isGrounded && rb.velocity.y <= 0)
        {
            animator.SetBool("Landed", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + boxOffset, boxSize);
    }
}
