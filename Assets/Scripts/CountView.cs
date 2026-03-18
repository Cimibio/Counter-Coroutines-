using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private Count _count;
    [SerializeField] private TextMeshProUGUI _countText;

    private void OnEnable()
    {
        _count.Changed += UpdateText;
        UpdateText(_count.CurrentNumber);
    }

    private void OnDisable()
    {
        _count.Changed -= UpdateText;
    }

    private void UpdateText(float value)
    {
        _countText.text = value.ToString("");
    }
}