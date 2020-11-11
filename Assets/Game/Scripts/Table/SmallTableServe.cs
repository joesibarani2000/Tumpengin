using UnityEngine;

public class SmallTableServe : MonoBehaviour
{
    private PlayerData owner;
    private int maxFood;

    public bool SetFoodData(Food food)
    {
        if (maxFood > 0)
        {
            maxFood--;

            food.GetComponent<Collider2D>().enabled = false;
            transform.parent.GetComponent<PlayerHolder>().player.GetFoodContentBuilder().PlaceFood(food.GetFoodData());
            transform.parent.GetComponent<PlayerHolder>().AddFoodData(food.gameObject);
            transform.parent.GetComponent<PlayerHolder>().player.SetLastFood(food.GetFoodData());
            GameManagement.Instance.decrementFood();
            return true;
        }

        return false;
    }

    public void SetOwner(PlayerData newOwner)
    {
        owner = newOwner;
    }

    public PlayerData GetOwner()
    {
        return owner;
    }

    public void SetMaxFood()
    {
        maxFood = GameManagement.Instance.GetSpawnTotal();
    }
}
