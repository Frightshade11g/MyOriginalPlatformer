using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    public bool fadeIn = false;

    float fadeCounter;
    [SerializeField] float timeBeforeFadeIn;
    [SerializeField] float fadeTime = 0.5f;

    private void Start()
    {
        fadeCounter = timeBeforeFadeIn;
    }

    private void Update()
    {
        fadeCounter -= Time.deltaTime;
        if(fadeCounter <= 0)
        {
            fadeIn = true;
        }

        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime * fadeTime;
                if (myUIGroup.alpha > 1)
                {
                    fadeIn = false;
                }
            }
        }
    }
}
