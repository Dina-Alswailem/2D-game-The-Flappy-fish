using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Color[] fishColors = new Color[4];
    public Button[] fishButtons;
    public Button backButtons;
    public Text[] priceTexts;
    public Text coinsText;
    public Text selectedFishText;
    public string[] fishNames = { "Normal Fish", "Blue Fish", "Red Fish", "Green Fish" };

    void Start()
    {
        backButtons.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        UpdateUI();
    }

    void UpdateUI()
    {
        coinsText.text = "Coin: " + DataManager.Instance.coins.ToString();

        for (int i = 0; i < fishButtons.Length; i++)
        {
            if (DataManager.Instance.unlockedFishes[i])
            {
                priceTexts[i].text = "Owned";
            }
            else
            {
                priceTexts[i].text = DataManager.Instance.fishPrices[i].ToString();
            }
        }

        selectedFishText.text = "Selected Fish : " + fishNames[DataManager.Instance.selectedFishIndex];
    }

    public void SelectFish(int index)
    {
        if (DataManager.Instance.unlockedFishes[index])
        {
            DataManager.Instance.selectedFishIndex = index;
            DataManager.Instance.SaveData();
            UpdateUI();
        }
        else if (DataManager.Instance.coins >= DataManager.Instance.fishPrices[index])
        {
            DataManager.Instance.coins -= DataManager.Instance.fishPrices[index];
            DataManager.Instance.unlockedFishes[index] = true;
            DataManager.Instance.selectedFishIndex = index;
            DataManager.Instance.SaveData();
            UpdateUI();
        }
    }
}