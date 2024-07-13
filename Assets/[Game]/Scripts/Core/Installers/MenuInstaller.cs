using Reflex.Core;
using UnityEngine;

public class MenuInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private Menu _menuPrefab;

    private ContainerBuilder _containerBuilder;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        _containerBuilder = containerBuilder;
        
        BindMenu();
    }

    private void BindMenu()
    {
        var menu = Instantiate(
            _menuPrefab
            , Vector3.zero
            , Quaternion.identity
            , null);

        _containerBuilder
            .AddSingleton(menu);
    }
}
