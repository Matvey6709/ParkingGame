using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour
{
    public Transform pointerImage;
    public Transform target;
    public Transform car;

    private Vector2 pointerPosition;
    void Start()
    {
    }

   
    void Update()
    {
        if((car.transform.position.x - target.transform.position.x) * (car.transform.position.x - target.transform.position.x) < Screen.width)
        {
           // pointerPosition = pointerImage.position;
           // pointerPosition.x = target.transform.position.x;
           // pointerPosition.y = target.transform.position.y;
           pointerImage.transform.position = car.transform.position;

        }
        
    }
}
