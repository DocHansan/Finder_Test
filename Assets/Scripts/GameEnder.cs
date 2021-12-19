using UnityEngine;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    FadeAnimator _fadeAnimator;

    void Awake()
    {
        _fadeAnimator = GetComponent<FadeAnimator>();
    }

    public void ShowEndGameScreen()
    {
        _fadeAnimator.Fade(true);
    }
}
