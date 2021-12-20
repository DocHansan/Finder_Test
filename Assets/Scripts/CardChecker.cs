using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField]
    GameField _gameField;
    [SerializeField][Range(0f, 2f)]
    float _changeDifficultyDelay;

    bool _isRightCardClicked = false;

    public void CompareCardIdentifiers(string identifier, CellAnimator cellAnimator)
    {
        if (_isRightCardClicked)
            return;
        if (identifier != _gameField.CurentCardIdentifier)
        {
            cellAnimator.ShakeCard();
            return;
        }
        _isRightCardClicked = true;
        cellAnimator.BounceCard();
        cellAnimator.MakeStars();
        Invoke(nameof(ChangeLevel), _changeDifficultyDelay);
    }

    void ChangeLevel()
    {
        _isRightCardClicked = false;
        _gameField.ChangeLevel—omplexity();
    }
}
