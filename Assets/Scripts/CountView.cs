using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _countText;

    private void OnEnable()
    {
        _counter.Changed += UpdateText;
        UpdateText(_counter.CurrentNumber);
    }

    private void OnDisable()
    {
        _counter.Changed -= UpdateText;
    }

    private void UpdateText(float value)
    {
        _countText.text = value.ToString("");
    }
}