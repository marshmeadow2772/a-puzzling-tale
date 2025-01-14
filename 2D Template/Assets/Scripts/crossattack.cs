using UnityEngine;

public class CrossAttack : MonoBehaviour
{
    public float attackRadius = 5f;
    public float stunDuration = 10f;
    public float playerFreezeDuration = 5f;
    public float cooldownDuration = 15f;

    private bool isOnCooldown = false;
    private float cooldownTimer = 0f;

    void Update()
    {
        // Cooldown logic
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
                isOnCooldown = false;
        }

        // Activate attack when Mouse1 is pressed
        if (Input.GetMouseButtonDown(0) && !isOnCooldown)
        {
            //StartCoroutine(ExecuteCrossAttack());
        }
    }
}

    /*private IEnumerator ExecuteCrossAttack()
    {
        isOnCooldown = true;
        cooldownTimer = cooldownDuration;

        // Freeze player movement
        PlayerMovement playerMovement = GetComponent<PlayerMovement>(); // Assumes a PlayerMovement script is attached
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Check for targets within radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider hit in hitColliders)
        {
            /*Target target = hit.GetComponent<Target>(); // Assumes a Target script on potential targets
            if (target != null)
            {
                StartCoroutine(StunTarget(target));
            }
        }

        // Wait for player freeze duration
        yield return new WaitForSeconds(playerFreezeDuration);

        // Re-enable player movement
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }

    //private IEnumerator StunTarget(Target target)
    {
        //target.Stun(); // Assumes a Stun method in the Target script
        //yield return new WaitForSeconds(stunDuration);
        //target.Unstun(); // Assumes an Unstun method in the Target script
    }

    /*private void OnDrawGizmosSelected()
    {
        // Draw radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}*/