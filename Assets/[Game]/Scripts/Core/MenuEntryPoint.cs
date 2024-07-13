using Reflex.Attributes;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    private Menu _menu;

    [Inject]
    private void Construct(Menu menu)
    {
        _menu = menu;
    }

    private void Start()
    {
        _menu.Init();
    }
}