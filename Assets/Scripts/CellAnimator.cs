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
    Transform _cardGameObject;
    Transform _cellGameObject;
    ParticleSystem _cellStarsParticle;

    void Awake()
    {
        Cell cell = gameObject.GetComponent<Cell>();
        _cellSize = cell.CellSize;
        _cardSpriteSize = cell.CardSpriteSize;
        _cardGameObject = gameObject.transform;
        _cellGameObject = _cardGameObject.GetChild(0);
        _cellStarsParticle = _cardGameObject.GetChild(1).GetComponent<ParticleSystem>();
    }

    public void BounceCell()
    {
        Bounce(_cardGameObject, _cellSize / 4, _bounceCellTime, 8);
    }

    public void BounceCard()
    {
        Bounce(_cellGameObject, _cardSpriteSize / 4, _bounceCardTime, 8);
    }

    public void ShakeCard()
    {
        _cellGameObject.DORewind();
        _cellGameObject.DOShakePosition(_shakeCardTime, _cardSpriteSize / 3, 14, 60);
    }

    void Bounce(Transform transform, Vector3 punch, float duration, int vibratio)
    {
        transform.DORewind();
        transform.DOPunchScale(punch, duration, vibratio);
    }

    public void MakeStars()
    {
        _cellStarsParticle.Play();
    }
}
