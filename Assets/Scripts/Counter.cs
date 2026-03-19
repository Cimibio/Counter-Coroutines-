using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startNumber = 0f;
    [SerializeField] private float _step = 1f;
    [SerializeField] private float _interval = 0.5f;

    private float _currentNumber;
    private bool _isCounting = false;

    private Coroutine _countingCoroutine;

    public event Action<float> Changed;

    public float CurrentNumber => _currentNumber;

    private void Awake()
    {
        _currentNumber = _startNumber;
    }


    public void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
            StartCounting();
        else
            StopCounting();
    }


    private void Increase()
    {
        _currentNumber += _step;
        Changed?.Invoke(_currentNumber);
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
        while (_isCounting)
        {
            yield return new WaitForSeconds(_interval);
            Increase();
        }
    }
}