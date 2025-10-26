 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    float leftlimit;
    [SerializeField]
    float rightlimit;
    [SerializeField]
    float bottomlimit;
    [SerializeField]
    float upperlimit;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftlimit, rightlimit), 
            Mathf.Clamp(transform.position.y, bottomlimit, upperlimit), transform.position.z);
    }
}
