using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwordScoreScript : MonoBehaviour
{
    public int score = 0;

    public void UpdateScore()
    {
        GetComponent<TextMeshProUGUI>().text = "Sword: " + score;
    }
}
