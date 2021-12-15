using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPreparer
{
    AllCardData _cardDataKits;
    int _chosenCardDataKit;
    int _chosenCard;
    List<int> _cardDataIndexes;

    public CardPreparer(AllCardData InputCardData)
    {
        _cardDataKits = InputCardData;
    }

    public void CreateLevelData(int lengthResultList)
    {
        _chosenCardDataKit = Random.Range(0, _cardDataKits.CardDataKits.Length);
        _chosenCard = Random.Range(0, lengthResultList);
        _cardDataIndexes = new List<int>();

        List<int> tempIndexes = new List<int>();

        while (_cardDataIndexes.Count < lengthResultList)
        {
            int tempIndex = Random.Range(0, _cardDataKits.CardDataKits[_chosenCardDataKit].CardData.Length);

            if (tempIndexes.Contains(tempIndex)) continue;
            else
            {
                tempIndexes.Add(tempIndex);
                _cardDataIndexes.Add(tempIndex);
            }
        }
    }

    public List<int> GetLevelCardIndexes()
    {
        return _cardDataIndexes;
    }

    public int GetChosenCardDataKit()
    {
        return _chosenCardDataKit;
    }

    public int GetChosenCardType()
    {
        return _chosenCard;
    }
}
