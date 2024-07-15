using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsContainer : MonoBehaviour
{
    public List<Animal> Animals { get; private set; } = new List<Animal>();

    public event Action<Animal> AnimalFoodEated;

    public void Add(Animal animal)
    {
        Animals.Add(animal);
        animal.FoodEated += OnFoodEated;

        animal.Activate();
    }

    public void Remove(Animal animal)
    {
        Animals.Remove(animal);
        animal.FoodEated -= OnFoodEated;
    }

    private void OnFoodEated(Animal animal)
    {
        AnimalFoodEated?.Invoke(animal);
    }
}