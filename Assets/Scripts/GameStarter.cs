using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    public GameField GameField;
    [SerializeField]
    public Button RestartButton;
    [SerializeField]
    public Text TaskText;
    [SerializeField]
    public FadeAnimator FadeAnimator;

    RestartButton _restartButton;
    GameField _gameField;

    void Awake()
    {
        _restartButton = RestartButton.GetComponent<RestartButton>();
        _gameField = GameField.GetComponent<GameField>();
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _restartButton.HideRestartButton();
        FadeAnimator.Fade(FadeAnimator.FadeTime, TaskText, true);
        _gameField.ResetField();
    }
}
