using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Player���|���ꂽ�����f���邽�߂̕ϐ�
    public bool _death = false;
    //Player���|���ꂽ�Ƃ��ɕ\������p�l��
    [SerializeField] GameObject _deathPanel;
    //�X�R�A��ێ�����ϐ�
    int _score;
    public List<GameObject> _enemies = new();
    [SerializeField] Image _fadeImage;
    public bool _start { get; set;}
    void Start()
    {
        _fadeImage.DOFade(0, 1).OnComplete(() => _start = true);
    }

    void Update()
    {
        if (_death == true)
        {
            Gameover();
        }
        else if (_enemies.Count == 0)
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
        GetComponent<ChengeScene>().ChangeScene("ClearScene");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
        {
            GameClear();
        }
    }
}
