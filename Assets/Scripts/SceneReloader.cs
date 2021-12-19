using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneReloader : MonoBehaviour
{
    [SerializeField]
    public Text LoadProgress;

    FadeAnimator _fadeAnimator;
    float _fadeTime;
    float _loadTime = 1f;

    void Awake()
    {
        _fadeAnimator = GetComponent<FadeAnimator>();
        _fadeTime = _fadeAnimator.FadeTime;
    }

    public void RestartScene()
    {
        StartCoroutine(MakeFadeEndScreen());
    }

    IEnumerator MakeFadeEndScreen()
    {
        _fadeAnimator.Fade(true);
        yield return new WaitForSeconds(_fadeTime);
        StartCoroutine(UpdateLoadProgress());
        
    }

    IEnumerator UpdateLoadProgress()
    {
        float passedTime = 0f;
        while (passedTime < _loadTime)
        {
            passedTime += Time.deltaTime / _loadTime;
            LoadProgress.text = Mathf.Round(passedTime / _loadTime * 100) + "%";
            yield return null;
        }
        LoadProgress.text = "";
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        SceneManager.LoadSceneAsync(0);
        yield return null;
    }
}
