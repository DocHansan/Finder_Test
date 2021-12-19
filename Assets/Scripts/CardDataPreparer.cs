using System.Collections.Generic;
using UnityEngine;

public class CardDataPreparer
{
    AllCardData _cardDataKits;
    int _chosenCardDataKit;
    int _chosenCard;
    List<int> _cardDataIndexes;
    List<string>[] _previousChosenCards;

    public CardDataPreparer(AllCardData InputCardData)
    {
        _cardDataKits = InputCardData;
        ResetParameters();
    }

    public void CreateLevelData(int lengthResultList)
    {
        _chosenCardDataKit = Random.Range(0, _cardDataKits.CardDataKits.Length);
        _chosenCard = Random.Range(0, lengthResultList);
        _cardDataIndexes = new List<int>();

        // Endless recursion if small DataKits
        if (CheckPossibilityToUseDataKit(lengthResultList))
        {
            CreateLevelData(lengthResultList);
            return;
        }

        while (_cardDataIndexes.Count < lengthResultList)
        {
            int tempIndex = Random.Range(0, _cardDataKits.CardDataKits[_chosenCardDataKit].CardData.Length);
            string tempCard = _cardDataKits.CardDataKits[_chosenCardDataKit].CardData[tempIndex].Identifier;


            if (_cardDataIndexes.Contains(tempIndex) || _previousChosenCards[_chosenCardDataKit].Contains(tempCard)) continue;
            else
            {
                _cardDataIndexes.Add(tempIndex);
            }
        }

        _chosenCard = _cardDataIndexes[_chosenCard];
        _previousChosenCards[_chosenCardDataKit].Add(_cardDataKits.CardDataKits[_chosenCardDataKit].CardData[_chosenCard].Identifier);
    }

    bool CheckPossibilityToUseDataKit(int lengthResultList)
    {
        return _cardDataKits.CardDataKits[_chosenCardDataKit].CardData.Length - _previousChosenCards[_chosenCardDataKit].Count < lengthResultList;
    }

    public List<int> GetLevelCardIndexes()
    {
        return _cardDataIndexes;
    }

    public int GetChosenCardDataKit()
    {
        return _chosenCardDataKit;
    }

    public string GetChosenCardType()
    {
        return _cardDataKits.CardDataKits[_chosenCardDataKit].CardData[_chosenCard].Identifier;
    }

    public void ResetParameters()
    {
        _previousChosenCards = new List<string>[_cardDataKits.CardDataKits.Length];

        for (int i = 0; i < _previousChosenCards.Length; i++)
        {
            _previousChosenCards[i] = new List<string>();
        }
    }
}
