using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    [SerializeField] public bool fadeIn = false;
    [SerializeField] public bool fadeOut = false;

    void ShowUI()
    {
        fadeIn = true;   
    }

    void HideUI()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if(fadeIn)
        {
            if(myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha > 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
