using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _death = false;
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
            GameObject.Find("DeathPanel").SetActive(true);
        }
    }
}
