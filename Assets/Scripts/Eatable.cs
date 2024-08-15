using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public EatableType foodType = EatableType.SIMPLE;

    private void OnTriggerEnter(Collider other)
    {
        var canEat = other.GetComponent<ICanEat>();

        if (canEat != null)
        {
            canEat.Eat(this);
        }
    }
}

public enum EatableType
{
    SIMPLE, POWER, FRUIT
}
