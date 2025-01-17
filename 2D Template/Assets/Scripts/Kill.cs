using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private bool isDead = false;
    public GameManger gameManger;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isDead)
        {
            Destroy(other.gameObject);
            isDead = true;
            Debug.Log("Dead");
            gameManger.gameOver();
        }
    }
}
