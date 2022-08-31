using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
