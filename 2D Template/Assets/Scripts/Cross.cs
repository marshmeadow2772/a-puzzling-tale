using System.Collections;
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

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with is the "Doverhare"
        if (other.CompareTag("Doverhare"))
        {
            StartCoroutine(StunTarget(other.gameObject));
        }
    }

    private IEnumerator StunTarget(GameObject target)
    {
        // Assuming the "Doverhare" has a script with a method or property to disable its behavior
        var targetMovement = target.GetComponent<Movement>();
        if (targetMovement != null)
        {
            targetMovement.enabled = false; // Disable movement or actions
        }

        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Re-enable the "Doverhare's" behavior
        if (targetMovement != null)
        {
            targetMovement.enabled = true;
        }
    }
}