using DG.Tweening;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    public CharacterBehaviour player;

    private PlaceholderContentBuilder placeholderContentBuilder;

    private Vector3 baseScale;
    private Vector3 hoverScale;

    private void Start()
    {
        placeholderContentBuilder = transform.parent.GetComponent<PlaceholderContentBuilder>();
        baseScale = transform.localScale;
        hoverScale = baseScale * 1.1f;
    }

    public void AddFoodData(GameObject foodData)
    {
        player.AddFoodCollects(foodData);
        placeholderContentBuilder.UpdateStackPlate();
    }

    public void Hover(bool hovering)
    {
        if (player)
        {
            if (transform.localScale != baseScale) transform.DOScale(baseScale, 0.5f);
            return;
        }

        if (hovering)
        {
            transform.DOScale(hoverScale, 0.5f);
        } else
        {
            transform.DOScale(baseScale, 0.5f);
        }
    }

    public void SetPlayer(CharacterBehaviour player)
    {
        this.player = player;
        placeholderContentBuilder.SetContent();
    }

    public void SetFoodContentBuilder(FoodContentBuilder builder)
    {
        if (player == null) return;
        player.SetFoodContentBuilder(builder);
    }

    public void SetPosFoodContentBuilder(Vector3 position, Transform parent)
    {
        if (player == null) return;
        player.GetFoodContentBuilder().transform.parent = parent;
        player.GetFoodContentBuilder().transform.localPosition = position;
    }

    public PlaceholderContentBuilder GetPlaceHolderContentBuilder()
    {
        return placeholderContentBuilder;
    }

    public CharacterBehaviour GetPlayer()
    {
        return player;
    }

    public PlayerData GetPlayerData()
    {
        return GetPlayer()?.GetPlayerData();
    }
}
