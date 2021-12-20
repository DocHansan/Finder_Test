using UnityEngine;

[CreateAssetMenu(fileName = "New CardDataKit", menuName = "ScriptableObjects/Card Data Kit")]
public class CardDataKit : ScriptableObject
{
    [SerializeField]
    CardData[] _cardData;

    public CardData[] CardData => _cardData;
}
