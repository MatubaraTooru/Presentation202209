using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ChengeScene : MonoBehaviour
{
    [SerializeField] Image _fadeoutImage;
    public void ChangeScene(string sceneName)
    {
        _fadeoutImage.DOFade(1f, 1f).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
