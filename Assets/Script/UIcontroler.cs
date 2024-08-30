using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class UIcontroler : MonoBehaviour
{
    public TextMeshProUGUI ScoreTimeText;
    public GameObject GameOverPanel;
    SceneManager SceneManager;
    public TextMeshProUGUI ScoreText;
    float score;
    float time = 60;
    bool isOver;
    SoundEffect soundEffect;
    private void Start()
    {   
        soundEffect = FindObjectOfType<SoundEffect>();
        StartCoroutine(CountDownTime());
        ScoreTimeText.text = "Score: " + score + " | Time: " + time;
    }
    private void Update()
    {
        ScoreTimeText.text = "Score: " + score + " | Time: " + time;
        ScoreText.text = "GAME OVER\nScore: " + score;
        if (time <= 0)
        {
            isOver = true;
        }
        if(isOver)
        {
            GameOverPanel.SetActive(true);
        }
    }
    public void IncreasementScore()
    {
        soundEffect.CollectingHeartSound();
        score++;
    }

    public void replay()
    {
        SceneManager.LoadScene("GamePlayScence");
    }
    IEnumerator CountDownTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
        }
    }
    public bool GameIsOver
    {
        get { return isOver; }
    }
    public void DecreasementScore()
    {
        score--;
        soundEffect.CollectingBadItems();       
    }
    public void CollectingGem()
    {
        score += 4;
        soundEffect.CollectingGem();
    }
    public void AddTime()
    {
        time += 5;
        soundEffect.IncreasementTIme();
    }
    public void RemoveTime()
    {
        time -= 5;
        soundEffect.DecreasementTime();
    }
}
