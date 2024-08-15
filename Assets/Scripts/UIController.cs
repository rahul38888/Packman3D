using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] public GameState gameState;
    [SerializeField] public TMP_Text scoreBoard;
    //[SerializeField] public Image lifeImagePrefab;

    public List<Image> healthImages = new List<Image>();

    private void Update()
    {
        ScoreUpdate();
        LifesUpdate();
    }
    public void ScoreUpdate()
    {
        scoreBoard.text = gameState.Score().ToString();
    }

    public bool LifesUpdate()
    {
        int lifes = gameState.Lifes();
        for (int i = 0; i < this.healthImages.Count; i++)
        {
            Image health = this.healthImages[i];
            if(i < lifes)
            {
                health.enabled = true;
            }
            else
            {
                health.enabled = false;
            }
        }

        if (lifes == 0)
            return false;

        return true;
    }
}
