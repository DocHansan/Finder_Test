using UnityEngine;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    FadeAnimator _fadeAnimator;
    Image _endScreenImage;
    float _fadeTime = 1f;

    void Awake()
    {
        _fadeAnimator = GetComponent<FadeAnimator>();
        _endScreenImage = GetComponent<Image>();
    }

    public void ShowEndGameScreen(bool isNeedFadeIn)
    {
        _fadeAnimator.Fade(_fadeTime, _endScreenImage, isNeedFadeIn);
    }
}
