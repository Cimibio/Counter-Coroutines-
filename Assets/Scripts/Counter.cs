using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Count _count;
    [SerializeField] private MouseInputHandler _mouseInput;

    private void OnEnable()
    {
        _mouseInput.OnMouseClicked += OnMouseClicked;
    }

    private void OnDisable()
    {
        _mouseInput.OnMouseClicked -= OnMouseClicked;
    }

    private void OnMouseClicked()
    {
        _count.ToggleCounting();
    }
}