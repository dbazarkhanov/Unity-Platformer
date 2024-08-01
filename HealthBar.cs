using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthManager playerHealth;
    public Image totalHealthBar;
    public Image currentHealthBar;

    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }

    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 3;        
    }
}
