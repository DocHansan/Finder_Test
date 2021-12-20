using UnityEngine;

public class AllCardData : MonoBehaviour
{
    [SerializeField]
    CardDataKit[] _cardDataKits;

    public CardDataKit[] CardDataKits => _cardDataKits;
}
