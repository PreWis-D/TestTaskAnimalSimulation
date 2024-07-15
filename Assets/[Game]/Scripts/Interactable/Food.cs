using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    public void SetColor(Color color)
    {
        _colorChanger.SetColor(color);
    }
}
