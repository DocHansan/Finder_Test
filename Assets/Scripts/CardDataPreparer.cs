using System.Collections.Generic;
using UnityEngine;

public class CardDataPreparer
{
    readonly CardDataKit[] _cardDataKits;
    int _chosenCardDataKit;
    int _chosenCard;
    List<int> _cardDataIndexes;
    readonly int _cardDataKitsLenth;
    readonly List<string>[] _previousChosenCards;

    public List<int> GetLevelCardIndexes => _cardDataIndexes;
    public int GetChosenCardDataKit => _chosenCardDataKit;
    public string GetChosenCardType => _cardDataKits[_chosenCardDataKit].CardData[_chosenCard].Identifier;

    public CardDataPreparer(AllCardData InputCardData)
    {
        _cardDataKits = InputCardData.CardDataKits;
        _cardDataKitsLenth = _cardDataKits.Length;

        _previousChosenCards = new List<string>[_cardDataKitsLenth];
        for (int i = 0; i < _previousChosenCards.Length; i++)
        {
            _previousChosenCards[i] = new List<string>();
        }
    }

    public bool CreateLevelData(int lengthResultList)
    {
        List<int> validDataKitsIndexes = GetValidDataKitsIndexes(lengthResultList);
        int validDataKitsCount = validDataKitsIndexes.Count;

        if (validDataKitsCount == 0)
            return false;

        _chosenCardDataKit = validDataKitsIndexes[Random.Range(0, validDataKitsCount)];
        _cardDataIndexes = new List<int>();
        CardData[] cardData = _cardDataKits[_chosenCardDataKit].CardData;

        while (_cardDataIndexes.Count < lengthResultList)
        {
            int tempIndex = Random.Range(0, cardData.Length);

            if (_cardDataIndexes.Contains(tempIndex))
                continue;

            _cardDataIndexes.Add(tempIndex);
        }
        _chosenCard = ChooseCard();
        _previousChosenCards[_chosenCardDataKit].Add(cardData[_chosenCard].Identifier);
        return true;
    }

    List<int> GetValidDataKitsIndexes(int lengthResultList)
    {
        List<int> validDataKitsIndexes = new();

        for (int i = 0; i < _cardDataKitsLenth; i++)
        {
            int currentCardDataLenth = _cardDataKits[i].CardData.Length;
            int currentPreviousChosenCardsCount = _previousChosenCards[i].Count;
            if (currentCardDataLenth - currentPreviousChosenCardsCount > 0 && currentCardDataLenth >= lengthResultList)
                validDataKitsIndexes.Add(i);
        }
        return validDataKitsIndexes;
    }

    int ChooseCard()
    {
        int chosenCard = _cardDataIndexes[Random.Range(0, _cardDataIndexes.Count)];
        if (_previousChosenCards[_chosenCardDataKit].Contains(_cardDataKits[_chosenCardDataKit].CardData[chosenCard].Identifier))
            return ChooseCard();
        return chosenCard;
    }
}
