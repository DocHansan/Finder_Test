using UnityEngine;

[CreateAssetMenu(fileName = "New CardDataKit", menuName = "ScriptableObjects/Card Data Kit")]
public class CardDataKit : ScriptableObject
{
    [SerializeField]
    public CardData[] CardData;
}
