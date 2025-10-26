using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Tagrget;
    public Transform car;
    public float distant = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Tagrget.position - transform.position;
        transform.position = car.position;

        if(dir.magnitude < distant)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
