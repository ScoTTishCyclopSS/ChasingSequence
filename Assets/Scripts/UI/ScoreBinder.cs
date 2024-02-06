using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBinder : MonoBehaviour
{
    public void Score(int amount)
    {
        ScoreManager.instance.AddScore(amount);
    }
}
