using DG.Tweening;
using UnityEngine;

public class CellAnimator : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)]
    float _bounceCellTime;
    [SerializeField][Range(0f, 1f)]
    float _bounceCardTime;
    [SerializeField][Range(0f, 1f)]
    float _shakeCardTime;

    Vector3 _cellSize;
    Vector3 _cardSpriteSize;
    GameObject _cardGameObject;

    void Awake()
    {
        _cellSize = gameObject.GetComponent<Cell>().CellSize;
        _cardSpriteSize = gameObject.GetComponent<Cell>().CardSpriteSize;
        _cardGameObject = gameObject.transform.GetChild(0).gameObject;
    }

    public void Bounce()
    {
        gameObject.transform.DORewind();
        gameObject.transform.DOPunchScale(punch: _cellSize / 4, duration: _bounceCellTime, vibrato: 8);
    }

    public void BounceCard()
    {
        _cardGameObject.transform.DORewind();
        _cardGameObject.transform.DOPunchScale(punch: _cardSpriteSize / 4, duration: _bounceCardTime, vibrato: 8);
    }

    public void ShakeCard()
    {
        _cardGameObject.transform.DORewind();
        _cardGameObject.transform.DOShakePosition(_shakeCardTime, strength: _cardSpriteSize / 3, vibrato: 14, randomness: 60);
    }
}
