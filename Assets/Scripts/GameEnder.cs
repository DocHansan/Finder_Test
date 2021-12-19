using UnityEngine;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    FadeAnimator _fadeAnimator;
    Image _endScreenImage;

    void Awake()
    {
        _fadeAnimator = GetComponent<FadeAnimator>();
        _endScreenImage = GetComponent<Image>();
    }

    public void ShowEndGameScreen()
    {
        _fadeAnimator.Fade(_endScreenImage, true);
    }
}
