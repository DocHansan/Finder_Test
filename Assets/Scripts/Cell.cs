using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField]
    public GameObject CardSprite;

    string _identifier;
    float _rotationAngle;
    Sprite _cellSprite;
    Vector3 _cellSize;
    Vector3 _cardSpriteSize;

    void Awake()
    {
        _cellSize = Vector3.Scale(gameObject.GetComponent<BoxCollider2D>().size, gameObject.GetComponent<Transform>().localScale);
        _cardSpriteSize = Vector3.Scale(_cellSize, CardSprite.GetComponent<Transform>().localScale);
    }

    void OnMouseDown()
    {
        GameObject.Find("CardChecker").GetComponent<CardChecker>().CompareCardIdentifiers(_identifier, this);
    }

    public void SetCellParameters(string identifier, Sprite sprite, float rotationAngle)
    {
        _identifier = identifier;
        _cellSprite = sprite;
        _rotationAngle = rotationAngle;
        VisualizeSprite();
    }

    void VisualizeSprite()
    {
        CardSprite.GetComponent<SpriteRenderer>().sprite = _cellSprite;
        CardSprite.transform.rotation = Quaternion.identity;
        CardSprite.transform.Rotate(new Vector3(0, 0, -_rotationAngle));
    }

    public void DoBounce(float time)
    {
        gameObject.transform.DORewind();
        gameObject.transform.DOPunchScale(punch: _cellSize / 4, duration: time, vibrato: 8);
    }

    public void DoBounceCard(float time)
    {
        gameObject.transform.GetChild(0).gameObject.transform.DORewind();
        gameObject.transform.GetChild(0).gameObject.transform.DOPunchScale(punch: _cardSpriteSize / 4, duration: time, vibrato: 8);
    }

    public void DoShakeCard(float time)
    {
        gameObject.transform.GetChild(0).gameObject.transform.DORewind();
        gameObject.transform.GetChild(0).gameObject.transform.DOShakePosition(time, strength: _cardSpriteSize / 3, vibrato: 14, randomness: 60);
    }
}
