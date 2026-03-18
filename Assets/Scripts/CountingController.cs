using System.Collections;
using UnityEngine;

public class CountingController : MonoBehaviour
{
    [SerializeField] private Count _count;
    [SerializeField] private float _interval = 0.5f;

    private Coroutine _countingCoroutine;

    private void OnEnable()
    {
        _count.CountingStateChanged += HandleCountingStateChanged;
    }

    private void OnDisable()
    {
        _count.CountingStateChanged -= HandleCountingStateChanged;
        StopCounting();
    }

    private void HandleCountingStateChanged(bool isCounting)
    {
        if (isCounting)
            StartCounting();
        else
            StopCounting();
    }

    private void StartCounting()
    {
        if (_countingCoroutine != null)
            StopCoroutine(_countingCoroutine);

        _countingCoroutine = StartCoroutine(CountRoutine());
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_count.IsCounting)
        {
            yield return new WaitForSeconds(_interval);
            _count.Increase();
        }
    }
}
