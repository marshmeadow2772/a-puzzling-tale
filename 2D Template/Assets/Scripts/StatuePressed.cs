using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatuePressed : MonoBehaviour
{
    public Rockactivate targetScript;
    public bool playerIsClose;
    // Start is called before the first frame update
    void Start()
    {
        targetScript = GameObject.FindWithTag("Rock").GetComponent<Rockactivate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            targetScript.Fall();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
