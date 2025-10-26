using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingInterface : MonoBehaviour
{

    public int[] numParking;
    public Text text;
    public string str;
    
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < numParking.Length; i++) 
        {
            str += " " + numParking[i] + " |";
        }
        text.text = "|" + str;

        str = "";
    }
}
