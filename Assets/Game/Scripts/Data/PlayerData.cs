using UnityEngine;

[CreateAssetMenu(menuName = "Create Player Data", fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public Sprite normalCursor;
    public Sprite dragCursor;
    public Sprite table;
    public Sprite[] face;
    public string name;
    public Color color;
}
