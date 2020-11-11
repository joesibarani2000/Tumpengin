using UnityEngine;

[CreateAssetMenu(menuName = "Create Food", fileName = "Food")]
public class FoodData : ScriptableObject
{
    public string name;
    public Sprite[] image;
    public int point;
    //Ini scriptable object buat bikin object foodnya
}
