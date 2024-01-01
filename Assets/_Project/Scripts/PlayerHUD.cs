using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Shmup
{
    public class PlayerHUD : MonoBehaviour
    {
         [SerializeField] Image fuelBar;
         [SerializeField] Image healthBar;
         [SerializeField] TextMeshProUGUI scoreText;

         void Update()
         {
            healthBar.fillAmount = GameManager.Instance.Player.GetHealthNormalized();
            fuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
            scoreText.text = $"Score: {GameManager.Instance.GetScore()}";
         }
    }
}
