using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hear : MonoBehaviour
{
    GameObject Blockage;
    GameObject Karnickel;
    public bool playerIsClose;
    public Sprite activate;
    // Start is called before the first frame update
    void Start()
    {
        Blockage = GameObject.FindWithTag("Blockage");
        Karnickel = GameObject.FindWithTag("Karnickel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = activate;
            Destroy (Blockage);
            Destroy (Karnickel);
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
