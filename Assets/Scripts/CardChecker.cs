using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField]
    GameField _gameField;
    [SerializeField][Range(0f, 2f)]
    float _changeDifficultyDelay;

    bool _isRightCardCklicked = false;

    public void CompareCardIdentifiers(string klickedCellIdentifier, Cell cell)
    {
        CellAnimator cellAnimator = cell.GetComponent<CellAnimator>();
        if (klickedCellIdentifier == _gameField.GetCardIdentifier())
        {
            cellAnimator.BounceCard();
            if (!_isRightCardCklicked)
            {
                _isRightCardCklicked = true;
                Invoke(nameof(ChangeLevel), _changeDifficultyDelay);
            }
            
        }
        else
        {
            cellAnimator.ShakeCard();
        }
    }

    void ChangeLevel()
    {
        _isRightCardCklicked = false;
        _gameField.ChangeLevel—omplexity();
    }
}
