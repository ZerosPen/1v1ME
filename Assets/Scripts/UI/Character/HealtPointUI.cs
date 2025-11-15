using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealtPointUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthPoint;

    public void UpdateHealtPoints (float healtPoint, float maxHealtPoint)
    {
        healthPoint.text = healtPoint + " / " + maxHealtPoint;
    }
}
