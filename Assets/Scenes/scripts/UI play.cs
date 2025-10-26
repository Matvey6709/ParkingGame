using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UIplay : MonoBehaviour
{
    [Header("You Lost")]
    public GameObject win;

    [Header("You win")]
    public GameObject lost;

    public GameObject pauseScreen;
    public Button playButton;
    public Button pauseButton;
    public CarMove carMove;
    public CanvasScaler canvas;
    public Timer timer;
    public string name_lvl = "lvl2";


    void Start()
    {
        invisibleLost();
        invisibleWin();
        

    }

    private void Update()
    {
        if(Screen.height*0.5 < Screen.width)
        {
            canvas.matchWidthOrHeight = 1;
        }
        if (Screen.height > Screen.width*0.5)
        {
            canvas.matchWidthOrHeight = 0;
        }
    }
    bool los = false;

    public void visibleLost()
    {
        if (!los)
        {
            los = true;
            foreach (Button child in lost.GetComponentsInChildren<Button>())
            {
                child.interactable = false;
            }
            StartCoroutine(WaitForRealSeconds(1));
        }
        lost.SetActive(true);
    }
    public void invisibleLost()
    {
        los = false;
        lost.SetActive(false);
    }
    bool gg = false;
    
    public void visibleWin()
    {
        PlayerPrefs.SetInt(name_lvl, 1);
        win.SetActive(true);
        if (!gg)
        {
            foreach (Button child in win.GetComponentsInChildren<Button>())
            {
                child.interactable = false;
            }
            StartCoroutine(WaitForRealSeconds(1));
            gg = true;
        }
    }

    

    IEnumerator WaitForRealSeconds(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < seconds)
        {
            yield return null;
        }
        YGAdsProvider.TryShowFullScreenAdWithChance(90);
        foreach (Button child in win.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }
        foreach (Button child in lost.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }

    }

    public void invisibleWin()
    {
        
        win.SetActive(false);
    }

    public void PauseOn()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void PauseOff()
    {
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
    public void CameraMod()
    {
        if(!carMove.enable)
        {
            carMove.enable = true;
        }
        else
        {
            carMove.enable = false;
        }
        
    }
    public void showRevarded()
    {
        if(Time.timeScale != 0f)
        {
            YGAdsProvider.ShowRevardedAds(1);
        }
        

    }
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    void Rewarded(int id)
    {

        if (id == 1) { 
            timer.timeStart += 100;
        }
            
        
    }

    public void addTime()
    {
        timer.timeStart += 100;
       
    }

    public void resetPref()
    {
        PlayerPrefs.SetInt("lvl2", 0);
        PlayerPrefs.SetInt("lvl3", 0);
        PlayerPrefs.SetInt("lvl4", 0);
        PlayerPrefs.SetInt("lvl5", 0);
        PlayerPrefs.SetInt("lvl6", 0);
        PlayerPrefs.SetInt("lvl7", 0);
        PlayerPrefs.SetInt("lvl8", 0);
        PlayerPrefs.SetInt("lvl9", 0);
        
    }
}
