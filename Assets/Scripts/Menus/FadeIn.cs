using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    bool fadeInOwO = false;

    public void SetToTrue()
    {
        fadeInOwO = true;
    }

    private void Update()
    {
        if (fadeInOwO)
        {
            if(myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha > 1)
                {
                    fadeInOwO = false;
                }
            }
        }
    }
}
