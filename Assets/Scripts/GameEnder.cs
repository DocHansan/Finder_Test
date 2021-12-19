using UnityEngine;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    [SerializeField]
    RestartButton _restartButton;
    [SerializeField]
    FadeAnimator _endGameScreenFadeAnimator;

    public void EndGame()
    {
        _endGameScreenFadeAnimator.Fade(true);
        _restartButton.SetButtonActivity(true);
    }
}
