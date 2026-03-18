using System.Collections;
using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private Count _count;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private float _interval = 0.5f;

    private Coroutine _countingCoroutine;

    private void Start()
    {
        UpdateText(_count.CurrentNumber);
    }

    private void OnEnable()
    {
        _count.Changed += UpdateText;
        _count.CountingStateChanged += HandleCountingStateChanged;
    }

    private void OnDisable()
    {
        _count.Changed -= UpdateText;
        _count.CountingStateChanged -= HandleCountingStateChanged;

        StopCountingCoroutine();
    }

    private void HandleCountingStateChanged(bool isCounting)
    {
        if (isCounting)
        {
            StartCountingCoroutine(isCounting);
        }
        else
        {
            StopCountingCoroutine();
        }
    }

    private void StartCountingCoroutine(bool isCounting)
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }

        _countingCoroutine = StartCoroutine(CountRoutine(isCounting));
    }

    private void StopCountingCoroutine()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator CountRoutine(bool isCounting)
    {
        while (isCounting)
        {
            yield return new WaitForSeconds(_interval);
            _count.Increase();
        }
    }

    private void UpdateText(float value)
    {
        _countText.text = value.ToString("F0");
    }
}