using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPatch : MonoBehaviour
{
    public enum MovmentType
    {
        Moveing,
        Lerping
    }

    public MovmentType Type = MovmentType.Moveing;
    public MovementPach MyPath;
    public float speed = 1;
    public float maxDistance = .1f;
    public int move = 0;
    public int[] rotation_num;
    public int[] rotation;
    bool isMove = false;
    int numMove = 0;

    private IEnumerator<Transform> pointInPath;

    void Start()
    {
        if(MyPath == null)
        {
       
            return;
        }

        pointInPath = MyPath.GetnextPatcPoint();


        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    void Update()
    {
        move = MyPath.getMovmentTo();

        if(pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if(Type == MovmentType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (Type == MovmentType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }

        if(move == numMove+1)
        {
            isMove = false;
        }

        for (int i = 0; i < rotation_num.Length; i++)
        {

            if (move == rotation_num[i] && !isMove)
            {
                transform.Rotate(0f, 0f, rotation[i]);
                
              
                isMove = true;
                numMove = rotation_num[i];
            }
            }
        }
}

