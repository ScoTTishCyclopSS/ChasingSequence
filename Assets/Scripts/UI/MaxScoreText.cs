using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        SaveSystem.LoadData();
        int highscore = SaveSystem.data.highscore;
        text.text = "max score: " + highscore;
    }
}
