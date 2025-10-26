using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingHandler : MonoBehaviour
{
    public ParkingPlaceTog[] parkingPlaceTogs1;
    public int[] numParkings;
    public Transform[] target;
    public GameObject gm_arrow;
    public GameObject arrow;
    public float distant = 9.0f;
    float timeStart = 0;
    bool ttt = false;
    public int numParking = 0;
    public Timer timer;
    public Text text;
    public Text textParking;
    public float timeParking = 2;
    public UIplay uIplay;
    public Sprite sprite_y;
    public Sprite sprite_g;
    float time = 1;
  

    void Start()
    {
        for (int i = 1; i < parkingPlaceTogs1.Length; i++)
        {
            for (int j = 0; j < parkingPlaceTogs1[i].parkingSpaceEdge1.Length; j++)
            {
                parkingPlaceTogs1[i].parkingSpaceEdge1[j].GetComponent<Collider2D>().enabled = false;
                parkingPlaceTogs1[i].parkingSpaceEdge1[j].GetComponent<SpriteRenderer>().enabled = false;
            }
            parkingPlaceTogs1[i].parkingSpaceMain1.GetComponent<Collider2D>().enabled = false;
            parkingPlaceTogs1[i].parkingSpaceMain1.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    //parkingPlaceTogs1[i].parkingSpaceMain1.GetComponent<Renderer>().material.color = new Color(0f, 255f, 0f, 0.00001f);
    void Update()
    {
       
        if (numParking < parkingPlaceTogs1.Length)
        {
            text.text = (numParkings[numParking]) + "";
            textParking.text = "";
            if (numParking != 0)
            {
                for (int j = 0; j < parkingPlaceTogs1[numParking].parkingSpaceEdge1.Length; j++)
                {
                    parkingPlaceTogs1[numParking].parkingSpaceEdge1[j].GetComponent<Collider2D>().enabled = true;
                    parkingPlaceTogs1[numParking].parkingSpaceEdge1[j].GetComponent<SpriteRenderer>().enabled = true;
                                //  parkingPlaceTogs1[numParking-1].parkingSpaceEdge1[j].GetComponent<Collider2D>().enabled = false;
                                //   parkingPlaceTogs1[numParking-1].parkingSpaceEdge1[j].GetComponent<SpriteRenderer>().enabled = false;

                 }
                    parkingPlaceTogs1[numParking].parkingSpaceMain1.GetComponent<Collider2D>().enabled = true;
                    parkingPlaceTogs1[numParking].parkingSpaceMain1.GetComponent<SpriteRenderer>().enabled = true;
                            //parkingPlaceTogs1[numParking-1].parkingSpaceMain1.GetComponent<Collider2D>().enabled = false;
                            // parkingPlaceTogs1[numParking-1].parkingSpaceMain1.GetComponent<SpriteRenderer>().enabled = false;
            }

            


            if (parkingPlaceTogs1[numParking].parkingSpaceMain1.getIsStay() && !parkingPlaceTogs1[numParking].parkingSpaceEdge1[0].getIsStay() && !parkingPlaceTogs1[numParking].parkingSpaceEdge1[1].getIsStay() && !parkingPlaceTogs1[numParking].parkingSpaceEdge1[2].getIsStay() && !parkingPlaceTogs1[numParking].parkingSpaceEdge1[3].getIsStay())
            {
                timeParking -= Time.deltaTime;
                
                textParking.text = Mathf.Round(timeParking)+"";
                if (Mathf.Round(timeParking) <= 0)
                {
                    parkingPlaceTogs1[numParking].parkingSpaceMain1.GetComponent<SpriteRenderer>().sprite = sprite_g;
                    numParking++;

                }
               // if (!ttt)
                //{
                //    ttt = true;
                //    timeStart = timer.getTime() - timeParking + 1;
               // }
               
                //textParking.text = (timer.getTime() - timeStart)+"";
                //if (timer.getTime() - timeStart <= -1)
                //{
                //    textParking.text = "0";
                //}
                //    if (timeStart > timer.getTime())
                //{
                 //   ttt = false;
                 //   parkingPlaceTogs1[numParking].parkingSpaceMain1.GetComponent<SpriteRenderer>().sprite = sprite_g;
                 //   numParking++;
                //}

            }
            else
            {
                ttt = false;
                parkingPlaceTogs1[numParking].parkingSpaceMain1.GetComponent<SpriteRenderer>().sprite = sprite_y;
                timeParking = 2;

            }
            time -= Time.deltaTime;
            var dir = target[numParking].position - gm_arrow.transform.position;
            gm_arrow.transform.position = transform.position;
            if (dir.magnitude < distant)
            {
                foreach (Transform child in transform)
                {
                    arrow.gameObject.SetActive(false);
                }
            }
            else if(time < 0)
            {
                foreach (Transform child in transform)
                {
                    arrow.gameObject.SetActive(true);
                }

                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                gm_arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }


        if(timer.getTime() <= 0)
        {
            Time.timeScale = 0f;
            timer.timeStart = 0;
            timer.timeStart2 = 0;
            uIplay.visibleLost();
        }

        if(numParkings.Length == numParking)
        {
            Time.timeScale = 0f;
            uIplay.visibleWin();
        }
    }


   
}
