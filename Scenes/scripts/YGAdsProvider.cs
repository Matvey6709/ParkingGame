using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YGAdsProvider : MonoBehaviour
{
    public static void TryShowFullScreenAdWithChance(int chance)
    {
        var random = Random.Range(0, 101);
        print(random);
        if(chance < random) {
            return;
        }
        YandexGame.FullscreenShow();
        
    }

    public static void ShowRevardedAds(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
