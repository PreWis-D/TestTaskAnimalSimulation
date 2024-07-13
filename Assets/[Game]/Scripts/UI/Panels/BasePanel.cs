using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    [SerializeField] private Transform _panel;

    public virtual void Show()
    {
        _panel.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        _panel.gameObject.SetActive(false);
    }
}