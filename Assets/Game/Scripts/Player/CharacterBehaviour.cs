using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerJoinData playerJoinData;
    [SerializeField] private FoodContentBuilder foodContentBuilder;

    [SerializeField] private CharacterCursorController controller;
    [SerializeField] private GameObject cursor;

    private List<GameObject> foodCollect = new List<GameObject>();
    private Score score = new Score();

    private FoodData lastFood;

    public void Initialize(PlayerData playerData, PlayerJoinData playerJoinData)
    {
        this.playerData = playerData;
        this.playerJoinData = playerJoinData;
        controller.enabled = false;
        controller.SetPointerImage(playerData);
    }

    public void ActivateController(Vector2 position)
    {
        controller.enabled = true;
        cursor.SetActive(true);
        cursor.transform.position = position;
    }

    public int GetControllerIndex()
    {
        return playerJoinData.controllerIndex;
    }

    public int GetPlayerIndex()
    {
        return playerJoinData.playerIndex;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public FoodContentBuilder GetFoodContentBuilder()
    {
        return foodContentBuilder;
    }

    public void SetFoodContentBuilder(FoodContentBuilder builder)
    {
        foodContentBuilder = builder;
    }

    public void AddFoodCollects(GameObject foodData)
    {
        foodCollect.Add(foodData);

        AddScore(foodData.GetComponent<Food>().GetFoodData());
    }

    public void SetLastFood(FoodData food)
    {
        lastFood = food;
    }

    public FoodData GetLastFood()
    {
        return lastFood;
    }

    public Score GetScore()
    {
        return score;
    }

    private void AddScore(FoodData foodData)
    {
        if (foodData.name == "Ayam") score.ayam++;
        if (foodData.name == "Ikan") score.ikan++;
        if (foodData.name == "Urap") score.urap++;
        if (foodData.name == "Lalapan") score.lalapan++;
        if (foodData.name == "Telur") score.telur++;
        if (foodData.name == "Perkedel") score.perkedel++;
        if (foodData.name == "Sambal") score.sambal++;
        if (foodData.name == "Nasi Kuning") score.nasiKuning++;
        if (foodData.name == "Telur Iris") score.telurIris++;
    }

    public List<GameObject> GetFoodCollects()
    {
        return foodCollect;
    }

    public int GetCollectsFoodCount()
    {
        return foodCollect.Count;
    }

    public void ReleaseFood()
    {
        controller.ForceRelease();
    }
}
