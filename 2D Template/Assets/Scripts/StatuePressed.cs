using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StatuePressed : MonoBehaviour
{
    public GameObject myObject;
    public GameObject secondObject;
    public Rockactivate targetScript;
    public bool playerIsClose;
    public Sprite activate;
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
            myObject.GetComponent<BoxCollider2D>().enabled = false;
            myObject.GetComponent<CapsuleCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = activate;
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
