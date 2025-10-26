using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fine : MonoBehaviour
{
   
    public Vector2 pos_start;
    float timer;

    void Start()
    {
        pos_start = gameObject.transform.localPosition;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/3;
        gameObject.transform.localPosition = new Vector2(pos_start.x, pos_start.y * timer + pos_start.y);
       
    }
    public void getEffect()
    {
        timer = 0;
    }
}
