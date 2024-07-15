using UnityEngine;

public class VFXsSpawner
{
    private VFXsContainer _container;

    public VFXsSpawner(VFXsContainer vFXsContainer)
    {
        _container = vFXsContainer;
    }

    public void Spawn(ParticleController particleController, Vector3 position)
    {
        if (_container.ParticleControllers.Count < 1)
        {
            Create(particleController, position);
        }
        else
        {
            var vfx = _container.GetVfx();

            if (vfx != null)
            {
                vfx.gameObject.SetActive(true);
                vfx.transform.position = position;
                return;
            }

            Create(particleController, position);
        }
    }

    private void Create(ParticleController particleControllerPrefab, Vector3 position)
    {
        var particleController = Object.Instantiate(particleControllerPrefab, position, Quaternion.identity, _container.transform);
    }
}
