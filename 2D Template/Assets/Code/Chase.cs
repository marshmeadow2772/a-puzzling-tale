using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 8f;

    private Vector2 movement;
    private Rigidbody2D rb;
    
    
    public EnemyPatrol targetPatorl;
    public FieldOfView targetView;

    public enum AIstate
    {
        patorl, chase
    }
    public AIstate state;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (state == AIstate.chase)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            direction.Normalize();
            movement = direction;
            rb.velocity = movement * moveSpeed;
            print("Hello");
            
           
            state = AIstate.chase;
        }
        else
        {
           
            state = AIstate.patorl;
        }
    }

}
