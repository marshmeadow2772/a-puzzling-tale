using JetBrains.Annotations;
using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;
    public bool isRunning;
    public float speed;
    void Awake()
    {
        stamina = totalStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            isRunning = true;
            stamina -= 5.0f * Time.deltaTime;
            speed = 10;
        }
        else
        {
            isRunning = false;
            speed = 5;
        }

        if(stamina < 25 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.05f;
        }
    }

    
}
