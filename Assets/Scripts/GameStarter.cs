using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameField _gameField;
    [SerializeField]
    FadeAnimator _taskText;

    void Start()
    {
        _taskText.Fade(true);
        _gameField.CreateLevel();
    }
}
