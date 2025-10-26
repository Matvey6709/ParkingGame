using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRenderingHandler : MonoBehaviour
{
    TrailRenderer trailRenderer;
    CarMove carMove;

    private void Awake()
    {
        carMove = GetComponentInParent<CarMove>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carMove.IsTireScreeching(out float later, out bool isBraking)) 
            trailRenderer.emitting = true;          
        else trailRenderer.emitting = false;
    }
}
