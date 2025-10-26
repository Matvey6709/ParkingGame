using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpaceMain : MonoBehaviour
{
    public Transform car;
    public bool isStay = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        isStay = true;        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
    }

    public bool getIsStay()
    {
        return isStay;
    }
 
}
