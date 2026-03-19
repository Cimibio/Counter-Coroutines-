using System;
using UnityEngine;

public class MouseInputReader : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Выберите кнопку для запуска/остановки таймера: LeftClick/RightClick")]
    private InputButton _primaryActionButton = InputButton.LeftClick;

    public event Action MouseClick;
    private enum InputButton { LeftClick = 0, RightClick = 1 }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)_primaryActionButton))
        {
            MouseClick?.Invoke();
        }
    }
}
