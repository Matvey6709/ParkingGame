using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject lvlPanel;
    public GameObject startPanel;
    public Sprite[] main_cars;
    public Sprite[] dors_r;
    public Sprite[] dors_l;
    public Image main_car;
    public Image dor_r;
    public Image dor_l;
    public static int num_car = 0;
    public GameObject[] lvls;

    public int getum_parking()
    {
        return num_car;
    }


    void Start()
    {
        try
        {
            for(int i = 0; i < PlayerPrefs.GetInt("SavedInteger"); i++)
            {
                num_car += 1;
                if (num_car > main_cars.Length - 1)
                {
                    num_car = 0;
                }

                main_car.sprite = main_cars[num_car];
                dor_r.sprite = dors_r[num_car];
                dor_l.sprite = dors_l[num_car];
            }
        }
        catch
        {

        }
     
        if (PlayerPrefs.GetInt("lvl2") != 0)
        {
            lvls[1].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[1].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl3") != 0)
        {
            lvls[2].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[2].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl4") != 0)
        {
            lvls[3].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[3].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl5") != 0)
        {
            lvls[4].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[4].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl6") != 0)
        {
            lvls[5].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[5].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl7") != 0)
        {
            lvls[6].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[6].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl8") != 0)
        {
            lvls[7].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[7].GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("lvl9") != 0)
        {
            lvls[8].GetComponent<Graphic>().color = new Color(255, 255, 255, 1);
            lvls[8].GetComponent<Button>().interactable = true;
        }




    }

    void Update()
    {
        
    }

    public void openScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LvlPanekOn()
    {
        YGAdsProvider.TryShowFullScreenAdWithChance(90);
        lvlPanel.SetActive(true);
        startPanel.SetActive(false);
    }
    public void LvlPanekOff()
    {
        lvlPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void Right_Click()
    {
        num_car += 1;
        if(num_car > main_cars.Length-1)
        {
            num_car = 0;
        }
        
        main_car.sprite = main_cars[num_car];
        dor_r.sprite = dors_r[num_car];
        dor_l.sprite = dors_l[num_car];
        PlayerPrefs.SetInt("SavedInteger", num_car);
        PlayerPrefs.Save();
    }

    public void Left_Click()
    {
        num_car -= 1;
        if (num_car < 0)
        {
            num_car = main_cars.Length-1;
        }
        main_car.sprite = main_cars[num_car];
        dor_r.sprite = dors_r[num_car];
        dor_l.sprite = dors_l[num_car];
        PlayerPrefs.SetInt("SavedInteger", num_car);
        PlayerPrefs.Save();
    }


}
