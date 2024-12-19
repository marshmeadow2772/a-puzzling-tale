using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 8f;

    private Vector2 movement;
    private Rigidbody2D rb;

    public LayerMask crossLayer; 
    public EnemyPatrol targetPatorl;
    public FieldOfView targetView;

    public enum AIstate
    {
        patorl, chase, deterred
    }
    public AIstate state;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // This part of the code is to control wether or not it is patorling or chasing the player 
        if (state == AIstate.chase)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            direction.Normalize();
            movement = direction;
            rb.velocity = movement * moveSpeed;
            
            
           
            state = AIstate.chase;
        }
        else
        {
           
            state = AIstate.patorl;
        }
        // When the cross is brought out by the player the Dover will freeze for 5-7 seconds 
        if (state == AIstate.deterred)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

}
