using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerIndikatorJoinParent;
    [SerializeField] private Text[] playerIndikatorJoin;
    [SerializeField] private Image[] playerIndikatorJoinColor;
    [SerializeField] private string selectTable, startGame;

    [SerializeField] private Text stageInfo;

    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    public void PlayerJoins(int index)
    {
        AudioController.PlaySFX("klik_menu");
        playerIndikatorJoin[index].text = startGame;
        playerIndikatorJoinColor[index].color = new Color(playerIndikatorJoinColor[index].color.r,
            playerIndikatorJoinColor[index].color.g, playerIndikatorJoinColor[index].color.b, 0.7f);
    }

    public void EnablePlayerJoinUI(bool flag)
    {
        playerIndikatorJoinParent.SetActive(flag);
    }

    public void selectTables(int index)
    {
        AudioController.PlaySFX("klik_menu");
        playerIndikatorJoin[index].text = selectTable; 
    }

    public void Retry()
    {
        AudioController.PlaySFX("klik_menu");
        TransitionManager.Instance.FadeIn(() => GoToScene("Game"));
    }

    public void BackToMenu()
    {
        AudioController.PlaySFX("klik_menu");
        TransitionManager.Instance.FadeIn(()=> GoToScene("MainMenu"));
    }

    private void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void TriggerStageText(string text)
    {
        stageInfo.gameObject.SetActive(true);
        stageInfo.text = text;
        DOTween.Sequence()
            .AppendCallback(() => stageInfo.transform.DOScale(new Vector2(1.2f, 1.2f), 0.5f))
            .AppendInterval(0.5f)
            .AppendCallback(() => stageInfo.transform.DOScale(new Vector2(1f, 1f), 0.5f))
            .AppendInterval(0.5f)
            .SetLoops(3)
            .OnComplete(()=> stageInfo.gameObject.SetActive(false));
    }
}
