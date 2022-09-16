using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool _death = false;
    [SerializeField] GameObject _deathPanel;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void death()
    {
        if (_death == true)
        {
            _deathPanel.SetActive(true);
        }
    }
    void Retry()
    {
        if (_death == true && Input.GetKeyDown("R"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
