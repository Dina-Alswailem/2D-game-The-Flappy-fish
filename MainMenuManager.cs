using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button levelTwoButton;
    public Text price;
    public int coinsToOpenLevelTwo = 15;

    void Start()
    {

        if (DataManager.Instance.coins >= coinsToOpenLevelTwo)
        {
            PlayerPrefs.SetInt("LevelOneCompleted", 1);
        }

        levelTwoButton.interactable = PlayerPrefs.GetInt("LevelOneCompleted", 0) == 1;
        price.text = PlayerPrefs.GetInt("LevelOneCompleted", 0) != 1 ? "15" : "";
    }
}
