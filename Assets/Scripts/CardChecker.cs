using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField]
    public GameField GameField;

    float _bounceCardAnimTime = 0.5f;
    float _shakeCardAnimTime = 0.5f;
    bool _isRightCardCklicked = false;

    public void CompareCardIdentifiers(string klickedCellIdentifier, Cell cell)
    {
        if (klickedCellIdentifier == GameField.GetCardIdentifier())
        {
            cell.DoBounceCard(_bounceCardAnimTime);
            if (!_isRightCardCklicked)
            {
                _isRightCardCklicked = true;
                Invoke(nameof(ChangeLevel), _bounceCardAnimTime);
            }
            
        }
        else
        {
            cell.DoShakeCard(_shakeCardAnimTime);
        }
    }

    void ChangeLevel()
    {
        _isRightCardCklicked = false;
        GameField.ChangeLevel—omplexity();
    }
}
