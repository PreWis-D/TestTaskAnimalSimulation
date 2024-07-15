using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ColorChanger
{
    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private string _shaderColorName;

    public Color Color {  get; private set; }

    public void GenerateRandomColor()
    {
        Color = Random.ColorHSV();

        SetColor(Color);
    }

    public void SetColor(Color color)
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            _meshRenderers[i].GetPropertyBlock(materialPropertyBlock);
            materialPropertyBlock.SetColor(_shaderColorName, color);
            _meshRenderers[i].SetPropertyBlock(materialPropertyBlock);
        }
    }
}
