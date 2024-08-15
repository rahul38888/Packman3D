using System.Collections;
using UnityEngine;

public class ICanEat : MonoBehaviour
{
    public float eatingTime = 0.01f;
    public float scatterTime = 2f;

    [SerializeField] public GameState gameState;

    public void Eat(Eatable eatable)
    {
        switch (eatable.foodType)
        {
            case EatableType.SIMPLE:
                gameState.AddScore(1);
                break;
            case EatableType.POWER:
                StartCoroutine(ScatterTimer());
                break;
            case EatableType.FRUIT:
                gameState.AddScore(10);
                break;
        }

        StartCoroutine(Disappear(eatable));
    }

    private IEnumerator ScatterTimer()
    {
        gameState.GhostsState(GhostState.SCATTER);
        yield return new WaitForSeconds(scatterTime);
        gameState.GhostsState(GhostState.CHASE);
    }

    private IEnumerator Disappear(Eatable eatable)
    {
        yield return new WaitForSeconds(eatingTime);
        Destroy(eatable.gameObject);
    }

    public void Hit()
    {
        gameState.ReduceLife();
    }
}
