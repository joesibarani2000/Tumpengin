using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject tutorialUI;
    void Start()
    {
        AudioController.PlayBGM("menu_game", PlayType.AUTO, true);
        TransitionManager.Instance.FadeOut(null);
    }

    public void StartGame()
    {
        AudioController.PlaySFX("klik_menu");
        AudioController.PlaySFX("Scene_Transition");
        TransitionManager.Instance.FadeIn(StartLevelGame);
    }

    public void StartLevelGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


    public void ExitGame()
    {
        AudioController.PlaySFX("klik_menu");
        TransitionManager.Instance.FadeIn(Quit);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        AudioController.PlaySFX("klik_menu");
        tutorialUI.SetActive(true);
    }
}
