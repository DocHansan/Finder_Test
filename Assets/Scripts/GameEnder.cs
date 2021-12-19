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
        _endGameScreenFadeAnimator.FadeIn();
        _restartButton.SetButtonActivity(true);
    }
}
