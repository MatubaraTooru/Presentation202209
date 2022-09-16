using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] GameManager _gm;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }
    void death()
    {
        if (_gm._death == true)
        {
            gameObject.SetActive(false);
        }
    }
}
