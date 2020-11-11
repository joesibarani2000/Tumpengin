using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreboardPanel;
    [SerializeField] private ScoreboardPanel[] panels;

    [Header("Win Panel Section")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Image panelGuard;
    [SerializeField] private Image facePict;
    [SerializeField] private Text playerId;

    [SerializeField] private Text stageInfo;


    private int lastJumlah;
    private CharacterBehaviour heighestScore;

    public void ActiveScore()
    {
        UIManager.Instance.TriggerStageText("Stage Selesai!");
        DOTween.Sequence()
            .AppendInterval(2f)
            .AppendCallback(() => scoreboardPanel.SetActive(true))
            .AppendCallback(() => FetchData())
            .AppendInterval(10f)
            .AppendCallback(() => ShowWinMenu());
    }

    private void FetchData()
    {
        ScoreboardPanel panelActive;
        foreach (CharacterBehaviour character in MultiplayerManagement.Instance.GetPlayersActive())
        {
            panelActive = panels.First(e => e.name == character.GetPlayerData().name);

            panelActive.SetItemCollect("Nasi Kuning", character.GetScore().nasiKuning);
            panelActive.SetItemCollect("Ayam", character.GetScore().ayam);
            panelActive.SetItemCollect("Ikan", character.GetScore().ikan);
            panelActive.SetItemCollect("Perkedel", character.GetScore().perkedel);
            panelActive.SetItemCollect("Urap", character.GetScore().urap);
            panelActive.SetItemCollect("Lalapan", character.GetScore().lalapan);
            panelActive.SetItemCollect("Telur Iris", character.GetScore().telurIris);
            panelActive.SetItemCollect("Telur", character.GetScore().telur);
            panelActive.SetItemCollect("Sambal", character.GetScore().sambal);

            int jumlahNasiKuning = FoodScoring.Instance.GetScoreNasiKuning(character.GetScore().nasiKuning);
            int jumlahAyam = FoodScoring.Instance.GetScoreLauk("Ayam", character.GetScore().ayam);
            int jumlahIkan = FoodScoring.Instance.GetScoreLauk("Ikan", character.GetScore().ikan);
            int jumlahPerkedel = FoodScoring.Instance.GetScorePerkedel(character.GetScore().perkedel);
            int jumlahTelurIris = FoodScoring.Instance.GetScoreTelurIris(character.GetScore().telurIris);
            int jumlahTelur = FoodScoring.Instance.GetScoreLauk("Telur", character.GetScore().telur);
            int jumlahUrap = FoodScoring.Instance.GetScoreUrap(MultiplayerManagement.Instance.GetPlayersActive(), character);
            int jumlahLalapan = FoodScoring.Instance.GetScoreLalapan(MultiplayerManagement.Instance.GetPlayersActive(), character);
            int jumlahSambal = FoodScoring.Instance.GetScoreSambal(character.GetScore().ayam, character.GetScore().ikan, character.GetScore().telur, character.GetScore().sambal);

            panelActive.SetJumlahTotal("Nasi Kuning", jumlahNasiKuning);
            panelActive.SetJumlahTotal("Ayam", jumlahAyam);
            panelActive.SetJumlahTotal("Ikan", jumlahIkan);
            panelActive.SetJumlahTotal("Perkedel", jumlahPerkedel);
            panelActive.SetJumlahTotal("Urap", jumlahUrap);
            panelActive.SetJumlahTotal("Lalapan", jumlahLalapan);
            panelActive.SetJumlahTotal("Telur Iris", jumlahTelurIris);
            panelActive.SetJumlahTotal("Telur", jumlahTelur);
            panelActive.SetJumlahTotal("Sambal", jumlahSambal);

            int jumlahTotal = jumlahNasiKuning + jumlahAyam + jumlahIkan + jumlahPerkedel + jumlahTelurIris + jumlahTelur + jumlahSambal + jumlahLalapan + jumlahUrap;
            Debug.Log(jumlahNasiKuning + " - " + jumlahAyam + " - " + jumlahIkan + " - " + jumlahPerkedel + " - " + jumlahTelurIris + " - " + jumlahTelur + " - " + jumlahSambal + " - " + jumlahLalapan + " - " + jumlahUrap);
            if (jumlahTotal > lastJumlah)
            {
                lastJumlah = jumlahTotal;
                heighestScore = character;
            }

            panelActive.SetTotalReward(jumlahTotal);
        }
    }

    private void ShowWinMenu()
    {
        panelGuard.color = heighestScore.GetPlayerData().color;
        facePict.sprite = heighestScore.GetPlayerData().face[Random.Range(0,2)];
        playerId.text = (heighestScore.GetPlayerIndex() + 1).ToString();
        winPanel.SetActive(true);
    }
}
