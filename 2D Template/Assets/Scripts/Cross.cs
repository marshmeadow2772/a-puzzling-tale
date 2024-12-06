using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cross : MonoBehaviour
{
    public GameObject cross;
    public Transform shootingPoint;
    private GameObject crossInstant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
