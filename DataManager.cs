using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int coins;
    public int selectedFishIndex = 0;
    public bool[] unlockedFishes = new bool[4] { true, false, false, false };
    public int[] fishPrices = new int[4] { 0, 100, 200, 300 };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadData()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);

        selectedFishIndex = PlayerPrefs.GetInt("SelectedFish", 0);

        for (int i = 0; i < unlockedFishes.Length; i++)
        {
            unlockedFishes[i] = PlayerPrefs.GetInt("Fish_" + i, i == 0 ? 1 : 0) == 1;
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("SelectedFish", selectedFishIndex);

        for (int i = 0; i < unlockedFishes.Length; i++)
        {
            PlayerPrefs.SetInt("Fish_" + i, unlockedFishes[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }
}