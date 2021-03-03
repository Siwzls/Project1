using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    private Vector3 ObjectToFollow;
    private Vector3 point;
    void Update()
    {
        FollowToObject();
    }
    private void FollowToObject()
    {
        //Слежение за игроком, при помощи деления отерзка
        
        ObjectToFollow = GameObject.FindWithTag("Player").transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(ObjectToFollow.x + mousePos.x / 2, ObjectToFollow.y + mousePos.y / 2, -10);

    }
    private void OnDrawGizmos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawSphere(new Vector3(ObjectToFollow.x + mousePos.x / 2, ObjectToFollow.y + mousePos.y / 2, 0), 0.1f);

    }
}
