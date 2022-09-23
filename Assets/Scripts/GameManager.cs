using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Player‚ª“|‚³‚ê‚½‚©”»’f‚·‚é‚½‚ß‚Ì•Ï”
    public bool _death = false;
    //Player‚ª“|‚³‚ê‚½‚Æ‚«‚É•\¦‚·‚éƒpƒlƒ‹
    [SerializeField] GameObject _deathPanel;
    //ƒXƒRƒA‚ğ•Û‚·‚é•Ï”
    public static int _score{ get; set;}
    //Scene‚É‚¢‚éEnemy‚ğ’T‚µ‚Äˆê“I‚É•Û‘¶‚µ‚Ä‚¨‚­”z—ñ
    GameObject[] _enemiesArray;
    //Enemy‚ğŠi”[‚µ‚Ä‚¨‚­List
    public List<GameObject> _enemies = new List<GameObject>(); 
    [SerializeField] Image _fadeImage;
    //ƒQ[ƒ€‚ğƒNƒŠƒA‚µ‚½‚©”»’f‚·‚é‚½‚ß‚Ì•Ï”
    bool _clear = false;
    public bool _start { get; set;}
    //ƒQ[ƒ€’†‚©”»’f‚·‚é•Ï”
    int isGame = 1;
    void Start()
    {
        _score = 0;
        Debug.Log(_score);
        _enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < _enemiesArray.Length; i++)
        {
            _enemies.Add(_enemiesArray[i]);
        }
        _fadeImage.DOFade(0, 1).OnComplete(() => _start = true);
        Debug.Log(_enemies.Count);
    }
    void Update()
    {
        if (isGame == 1)
        {
            if (_death == true)
            {
                Gameover();
            }
            else if (_enemies.Count == 0)
            {
                _clear = true;
            }

            if (_clear == true)
            {
                GameClear();
            }
        }
    }
    void Gameover()
    {
        _deathPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            _score = 0;
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
        Debug.Log("GameClear");
        isGame = 0;
        GetComponent<ChengeScene>().ChangeScene("ClearScene");
    }
}
