using System;
using UnityEngine;

public class Count : MonoBehaviour
{
    [SerializeField] private float _startNumber = 0f;
    [SerializeField] private float _step = 1f;

    private float _currentNumber;
    private bool _isCounting = false;

    public event Action<float> Changed;
    public event Action<bool> CountingStateChanged;

    public float CurrentNumber => _currentNumber;
    public bool IsCounting => _isCounting;

    private void Awake()
    {
        _currentNumber = _startNumber;
    }

    public void ToggleCounting()
    {
        _isCounting = !_isCounting;
        CountingStateChanged?.Invoke(_isCounting);
    }

    public void Increase()
    {
        _currentNumber += _step;
        Changed?.Invoke(_currentNumber);
    }
}