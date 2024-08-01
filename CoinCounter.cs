using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public PlayerController playerController;
    public Image coinImage;
    public TextMeshProUGUI coinText;

    void Start()
    {
        UpdateCoinUI();
    }

    void Update()
    {
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = playerController.coinCount.ToString();
    }
}
