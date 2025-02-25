using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    public bool fadeIn = false;

    [SerializeField] float timeBeforeFadeIn;
    [SerializeField] float fadeTime = 0.5f;

    public void SetToTrue()
    {
        fadeIn = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            timeBeforeFadeIn -= Time.deltaTime;
            if (timeBeforeFadeIn <= 0)
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
}
