using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wheelManager : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Transform myTransform;
    private Touch myTouch;
    public Text textRotate;
    void Start()
    {
        myTransform = transform;
    }


    void Update()
    {
        if (Input.touchCount == 1)
        {
            myTouch = Input.GetTouch(0);
        }
        if (myTouch.phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(myTouch.position);
        }
        if (Physics.Raycast(ray, out hit))
        {
            if ((hit.collider.name == "wheel_obj") & (myTouch.phase == TouchPhase.Moved))
            {
                myTransform.Rotate(0, 0, myTouch.deltaPosition.x, Space.World);
                textRotate.text = (myTransform.rotation.z).ToString();
            }
        }
    }
}
