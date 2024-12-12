using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius = 5;
    [Range(1, 360)]public float angle = 45;
    [Range(0, 1)]public float dotAngle = 0.7f;
    public float offSet;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject playerRef;

    public Chase chase;
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            Vector2 dir = DirecetionFromAngle(transform.up.y, offSet);

            float dot = Vector2.Dot(dir, directionToTarget);
            Debug.Log(dot);

            if (dot > dotAngle)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                
                    chase.state = Chase.AIstate.chase;
                else
                    chase.state = Chase.AIstate.patorl;
            }
            else
            {
                chase.state = Chase.AIstate.patorl;
            }
        }
        else
        {
            chase.state = Chase.AIstate.patorl;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirecetionFromAngle(-transform.eulerAngles.z, - angle / 2 + offSet);
        Vector3 angle02 = DirecetionFromAngle(-transform.eulerAngles.z, angle / 2 + offSet);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if (chase.state == Chase.AIstate.chase)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }
    
    private Vector2 DirecetionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    } 
}
