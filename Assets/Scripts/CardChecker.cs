using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField]
    public GameField GameField;
    [SerializeField]
    public GameObject Cell;

    float _bounceCardAnimTime = 0.5f;
    float _shakeCardAnimTime = 0.5f;
    bool _isRightCardCklicked = false;

    public void CompareCardIdentifiers(int klickedCellIdentifier, Cell cell)
    {
        if (klickedCellIdentifier == GameField.GetCardIdentifier())
        {
            cell.DoBounceCard(_bounceCardAnimTime);
            if (!_isRightCardCklicked)
            {
                _isRightCardCklicked = true;
                Invoke("ChangeLevel", _bounceCardAnimTime);
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
