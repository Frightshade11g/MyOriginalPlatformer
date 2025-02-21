using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    public bool fadeIn = false;

    float fadeInCounter;
    [SerializeField] float fadeInCount = 5f;

    [SerializeField] float gameOverFadeInSpeed = 0.5f;


    private void Awake()
    {
        fadeInCounter = fadeInCount;
    }

    private void Update()
    {
        fadeInCounter -= Time.deltaTime;
        if (fadeInCounter <= 0)
        {
            fadeIn = true;
        }

        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime * gameOverFadeInSpeed;
                if (myUIGroup.alpha > 1)
                {
                    fadeIn = false;
                }
            }
        }
    }
}
