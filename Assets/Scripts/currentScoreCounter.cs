using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currentScoreCounter : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI currentScoreText;
    public void increaseCurrentScore(int score)
    {
        currentScoreText.text = $"Current Score: {score}";
    }
}
