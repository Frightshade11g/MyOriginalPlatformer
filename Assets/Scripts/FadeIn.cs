using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    public bool fadeIn = false;

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

        if(myUIGroup.alpha == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
