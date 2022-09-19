using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Playerが倒されたか判断するための変数
    public bool _death = false;
    //Playerが倒されたときに表示するパネル
    [SerializeField] GameObject _deathPanel;
    //スコアを保持する変数
    int _score;
    GameObject[] _enemiesArray;
    [SerializeField] Image _fadeImage;
    bool _start = false;
    void Start()
    {
        _enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        _fadeImage.DOFade(0, 1).OnComplete(() => _start = true);
    }

    void Update()
    {
        if (_death == true)
        {
            Gameover();
        }

        if (_enemiesArray.Length > 0)
        {
            GameClear();
        }
    }
    void Gameover()
    {
        _deathPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
    public void GetScore(int getScore)
    {
        _score += getScore;
        Debug.Log(_score);
    }
    void GameClear()
    {
        
    }
}
