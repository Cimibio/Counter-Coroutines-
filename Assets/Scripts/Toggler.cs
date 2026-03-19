using UnityEngine;

public class Toggler : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private MouseInputReader _mouseInput;

    private void OnEnable()
    {
        _mouseInput.MouseClick += OnMouseClick;
    }

    private void OnDisable()
    {
        _mouseInput.MouseClick -= OnMouseClick;
    }

    private void OnMouseClick()
    {
        _counter.ToggleCounting();
    }
}