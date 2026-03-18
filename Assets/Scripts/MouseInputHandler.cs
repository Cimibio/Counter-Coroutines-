using UnityEngine;
using System;

public class MouseInputHandler : MonoBehaviour
{
    public event Action OnMouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClicked?.Invoke();
        }
    }
}
