using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;

public class ClearSceneController : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    int _score = GameManager._score;
    [SerializeField] float _scoreChangeInterval = 0.5f;
    int _maxScore = 99999999;
    [SerializeField] AudioClip _clickSound;
    AudioSource _audioSource;
    static int _bestScore;
    [SerializeField] Text _bestScoreText;
    private void Start()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
        }
        AddScore();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _score = 0;
            _audioSource.PlayOneShot(_clickSound);
            GetComponent<ChengeScene>().ChangeScene("Title");
        }
    }
    void AddScore()
    {
        int tempScore = 0;
        _score = Mathf.Min(_score, _maxScore);
        int tempScore2 = 0;
        _bestScore = Mathf.Min(_bestScore, _maxScore);
        if (tempScore != _score)
        {
            DOTween.To(() => tempScore, 
                    x => tempScore = x, 
                    _score,
                    _scoreChangeInterval)
                    .OnUpdate(() => _scoreText.text = tempScore.ToString("00000000"))
                    .OnComplete(() => _scoreText.text = _score.ToString("00000000"));
        }

        if (tempScore2 != _bestScore)
        {
            DOTween.To(() => tempScore,
                    x => tempScore = x,
                    _bestScore,
                    _scoreChangeInterval)
                    .OnUpdate(() => _bestScoreText.text = tempScore.ToString("00000000"))
                    .OnComplete(() => _bestScoreText.text = _bestScore.ToString("00000000"));
        }
    }
}
