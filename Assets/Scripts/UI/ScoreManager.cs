using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { private set; get; }
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    [SerializeField] private Hitable playerHitable;

    [SerializeField]private GameObject runtimeCanvas;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private bool dead = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playerHitable.OnDeath.AddListener(OnDeath);
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDeath(DeathArgs arg)
    {
        dead = true;
        runtimeCanvas.SetActive(false);
        deathCanvas.SetActive(true);
        finalScoreText.text = score.ToString();
        SaveSystem.LoadData();
        int highscore = SaveSystem.data.highscore;
        if (highscore < score)
        {
            highscore = score;
            SaveSystem.data.highscore = score;
            SaveSystem.SaveData();
        }
        highScoreText.text = highscore.ToString();
    }

    void FixedUpdate()
    {
        if (dead) return;
        score += 1;
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
