using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Square;
    public GameObject EndPanel;
    public Text timetxt;
    public Text nowscore;
    public Text bestScore;
    float time = 0.0f;
    bool isPlay = true;
    string key = "bestScore";
    public Animator anime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            timetxt.text = time.ToString("N2");
        }
    }
    void MakeSquare()
    {
        Instantiate(Square);
    }

    public void GameOver()
    {
        isPlay = false;
        Invoke("TimeStop", 0.5f);
        anime.SetBool("IsDie", true);
        EndPanel.SetActive(true);
        nowscore.text = time.ToString("N2");
        float best = PlayerPrefs.GetFloat(key);
        if (best < time)
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }
        else
        {
            bestScore.text = best.ToString("N2");
        }
    }

    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
