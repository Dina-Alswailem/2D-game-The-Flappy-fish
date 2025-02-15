using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePanel : MonoBehaviour
{
    public Text coin;
    public Text score;
    public GameManager manager;

    private void OnEnable()
    {
        coin.text = $"Coins : {DataManager.Instance.coins}";
        score.text = $"Score : {manager.pipe}";
    }
}
