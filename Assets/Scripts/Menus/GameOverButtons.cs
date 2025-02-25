using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    [SerializeField] Button button;
    [SerializeField] Button Otherbutton;

    private void Start()
    {
        button.interactable = false;
        Otherbutton.interactable = false;
    }

    private void Update()
    {
        if (myUIGroup.alpha == 1)
        {
            button.interactable = true;
            Otherbutton.interactable = true;
        }
    }

    public void PlayGame()
    {
        if (myUIGroup.alpha == 1)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        if (myUIGroup.alpha == 1)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
