using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private Transform spriteTransform;
    private Vector3 playerPos;

    void Start()
    {
        spriteTransform = transform.Find("Sprite").transform;
    }
    private void Update()
    {
        LookAtPosition();
    }
    private void LookAtPosition()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        Vector3 direction = playerPos - transform.position;
        RaycastHit2D raycast2D = Physics2D.Raycast(transform.position, direction, 10f, layerMask);

        if (raycast2D.collider != null)
        {
            if (raycast2D.collider.gameObject.tag == "Player")
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                spriteTransform.rotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 direction = playerPos - transform.position;
        RaycastHit2D raycast2D = Physics2D.Raycast(transform.position, direction);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(raycast2D.point, 0.1f);
        Gizmos.DrawLine(transform.position, raycast2D.point);
    }
}
