using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Cross : MonoBehaviour
{
    public GameObject cross;
    public Transform shootingPoint;
    private GameObject crossInstant;
    public Movement movement;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            crossInstant = Instantiate(cross, shootingPoint.position, transform.rotation);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(crossInstant);
        }
    }
}
