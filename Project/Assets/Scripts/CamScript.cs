using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    private GameObject ObjectToFollow;
    void Start()
    {
        ObjectToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, -10);
    }
}
