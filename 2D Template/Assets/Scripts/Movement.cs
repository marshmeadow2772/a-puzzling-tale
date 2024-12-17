using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public float speed;
    private Rigidbody2D rigidbody2d;
    private GameObject boxRef;
    public Vector2 boxSize = new Vector2(0.25f, 0.01f);
    public Vector3 boxOffset;
    public LayerMask groundLayer;
    public Sprint Sprint;

    // Update is called once per frame

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(left))
        {
            Debug.Log("print");
            GetComponent<Rigidbody2D>().velocity = new Vector2(-Sprint.speed, GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(right))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Sprint.speed, GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        RaycastHit2D hitInfo;
        
        hitInfo = Physics2D.BoxCast(transform.position + boxOffset, boxSize, 0, Vector2.down, boxSize.y, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && hitInfo)
        {
            float jumpVelocity = 15f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + boxOffset, boxSize);
    }
}
