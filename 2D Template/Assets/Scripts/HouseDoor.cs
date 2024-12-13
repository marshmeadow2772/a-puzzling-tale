using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoor : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.GetComponent<FirstDoor>())
       {
            sceneToLoad = "Inside House 1";
            enterAllowed = true;
       }
       else if (collision.GetComponent<SecondDoor>())
       {
            sceneToLoad = "Inside House 2";
            enterAllowed = true;
       }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<FirstDoor>() || collision.GetComponent<SecondDoor>()) ;
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.E))
        {
            //ScemeController.LoadScene(sceneToLoad);
        }
    }
}
