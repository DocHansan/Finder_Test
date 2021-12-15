using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChecker : MonoBehaviour
{
    [SerializeField]
    public GameField GameField;

    public void CompareCardIdentifiers(int klickedCellIdentifier)
    {
        if (klickedCellIdentifier == GameField.GetCardIdentifier())
            ChangeLevel();
    }

    void ChangeLevel()
    {
        GameField.ChangeLevel—omplexity();
    }
}
