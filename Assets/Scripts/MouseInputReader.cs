using System;
using UnityEngine;

public class MouseInputReader : MonoBehaviour
{
    private enum InputButton { LeftClick = 0, RightClick = 1 }

    [SerializeField]
    [Tooltip("Выберите кнопку для запуска/остановки таймера: LeftClick/RightClick")]
    private InputButton _primaryActionButton = InputButton.LeftClick;

    public event Action MouseClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)_primaryActionButton))
        {
            MouseClick?.Invoke();
        }
    }
}
