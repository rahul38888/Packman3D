using UnityEngine;

public class Eatable : MonoBehaviour
{
    public EatableType foodType = EatableType.SIMPLE;

    public AudioClip simpleFoodEatingSound;
    public AudioClip powerFoodEatingSound;
    public AudioClip FruitEatingSound;

    private AudioClip selfClip;

    private void Start()
    {
        selfClip = getAudioClip();
    }

    private AudioClip getAudioClip()
    {
        switch (foodType)
        {
            case EatableType.FRUIT:
                return FruitEatingSound;
            case EatableType.POWER:
                return powerFoodEatingSound;
            case EatableType.SIMPLE:
            default:
                return simpleFoodEatingSound;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var canEat = other.GetComponent<ICanEat>();

        if (canEat != null)
        {
            GetComponent<AudioSource> ().PlayOneShot(selfClip);
            canEat.Eat(this);
        }
    }
}

public enum EatableType
{
    SIMPLE, POWER, FRUIT
}
