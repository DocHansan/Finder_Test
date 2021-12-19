using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    public GameField GameField;
    [SerializeField]
    public GameObject TaskText;

    GameField _gameField;
    FadeAnimator _fadeAnimator;
    Text _taskText;

    void Awake()
    {
        _gameField = GameField.GetComponent<GameField>();
        _fadeAnimator = TaskText.GetComponent<FadeAnimator>();
        _taskText = TaskText.GetComponent<Text>();
    }

    void Start()
    {
        _fadeAnimator.Fade(_taskText, true);
        _gameField.ResetField();
    }
}
