using System.Collections.Generic;
using UnityEngine;

public class VFXsContainer : MonoBehaviour
{
    public List<ParticleController> ParticleControllers { get; private set; } = new List<ParticleController>();

    public void Add(ParticleController particleController)
    {
        ParticleControllers.Add(particleController);
    }

    public void Remove(ParticleController particleController)
    {
        ParticleControllers.Remove(particleController);
    }

    public ParticleController GetVfx()
    {
        foreach (ParticleController vfx in ParticleControllers)
        {
            if (vfx.gameObject.activeSelf == false)
                return vfx;
        }

        return null;
    }
}