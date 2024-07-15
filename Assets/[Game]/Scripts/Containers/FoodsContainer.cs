using System.Collections.Generic;
using UnityEngine;

public class FoodsContainer : MonoBehaviour
{
    public List<Food> Foods { get; private set; } = new List<Food>();

    public void Add(Food food)
    {
        Foods.Add(food);
    }

    public void Remove(Food food)
    {
        Foods.Remove(food);
    }

    public Food GetFood()
    {
        foreach (Food food in Foods)
        {
            if (food.gameObject.activeSelf == false)
                return food;
        }

        return null;
    }
}