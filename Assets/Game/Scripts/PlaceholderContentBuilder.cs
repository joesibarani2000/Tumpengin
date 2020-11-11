using UnityEngine;

public class PlaceholderContentBuilder : MonoBehaviour
{
    [SerializeField] private StackingPlateManagement stackingPlateManagement;

    [SerializeField] private GameObject foodContentBuilderPrefabs;
    [SerializeField] private Vector3 placementFoodContent;
    [SerializeField] private Transform cursorPlacement;
    [SerializeField] private GameObject serveTable;
    [SerializeField] private PlayerHolder playerHolder;

    [SerializeField] private SpriteRenderer characterFace;
    [SerializeField] private SpriteRenderer table;
    [SerializeField] private Sprite normalMeja;

    public void SetContent()
    {
        if (playerHolder.GetPlayer())
        {
            SpawnBuilder();
            UpdateTable(true);
            UpdateOther(true);
            
        } else
        {
            UpdateTable(false);
            UpdateOther(false);
        }
    }

    public void UpdateContent()
    {
        if (playerHolder.GetPlayer())
        {
            UpdateTable(true);
            UpdateOther(true);
        }
        else
        {
            UpdateTable(false);
            UpdateOther(false);
        }
    }

    public void UpdateCursor()
    {
        playerHolder.GetPlayer()?.ActivateController(cursorPlacement.position);
    }

    private void UpdateOther(bool flag)
    {
        characterFace.sprite = flag ? playerHolder.GetPlayerData()?.face[Random.Range(0, playerHolder.GetPlayerData().face.Length)] : null;
    }

    private void UpdateTable(bool flag)
    {
        serveTable.SetActive(flag);
        serveTable.GetComponent<SmallTableServe>().SetOwner(playerHolder.GetPlayerData());
        serveTable.GetComponent<SmallTableServe>().SetMaxFood();

        table.sprite = playerHolder.GetPlayer() ? playerHolder.GetPlayerData().table : normalMeja;

        playerHolder.SetPosFoodContentBuilder(placementFoodContent, transform);
    }

    private void SpawnBuilder()
    {
        FoodContentBuilder builder = Instantiate(foodContentBuilderPrefabs, transform).GetComponent<FoodContentBuilder>();
        builder.transform.localPosition = placementFoodContent;
        playerHolder.SetFoodContentBuilder(builder);
    }

    public void UpdateStackPlate()
    {
        stackingPlateManagement.UpdateStack(playerHolder.GetPlayer().GetFoodCollects());
    }
}
