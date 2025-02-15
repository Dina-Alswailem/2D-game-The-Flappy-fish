using UnityEngine;

public class FishColor : MonoBehaviour
{
    public Color[] fishColors; 
    public SpriteRenderer fishBodySprite;
    public SpriteRenderer fishTailSprite;

    void Start()
    {
        UpdateFishColor();
    }

    public void UpdateFishColor()
    {
        fishBodySprite.color = fishColors[DataManager.Instance.selectedFishIndex];
        fishTailSprite.color = fishColors[DataManager.Instance.selectedFishIndex];
    }
}