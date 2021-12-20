using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameField : MonoBehaviour
{
    [SerializeField]
    GameObject _cellPrefab;
    [SerializeField][Range(1, 4)]
    int _cellLineCount;
    [SerializeField][Range(1, 5)]
    int _cellColumnCount;
    [SerializeField]
    AllCardData _cardDataKits;
    [SerializeField][Range(0f, 2f)]
    float _intercellularSpace = 0.2f;
    [SerializeField]
    UITaskText _uiTaskText;
    [SerializeField]
    GameEnder _gameEnder;

    public string GetCardIdentifier => _curentCardIdentifier;

    Vector3 _horizontalStartPoint;
    Vector3 _horizontalOffset;
    Vector3 _verticalOffset;
    Vector3 _cellSize;
    CardDataPreparer _dataPreparer;
    int _levelIteration = 1;
    string _curentCardIdentifier;
    List<GameObject> _cellsList;
    CellSpawner _cellSpawner;

    void Awake()
    {
        _cellSize = Vector3.Scale(_cellPrefab.GetComponent<BoxCollider2D>().size, _cellPrefab.GetComponent<Transform>().localScale);
        _horizontalStartPoint = new Vector3(0.5f * (_cellColumnCount - 1) * (_cellSize.x + _intercellularSpace), 0, 0);
        _horizontalOffset = new Vector3(_cellSize.y + _intercellularSpace, 0, 0);
        _verticalOffset = new Vector3(0, (_cellSize.y + _intercellularSpace) / 2, 0);
        _dataPreparer = new CardDataPreparer(_cardDataKits);
        _cellSpawner = GetComponent<CellSpawner>();
        _cellsList = new List<GameObject>();
    }

    public void CreateLevel()
    {
        _dataPreparer.CreateLevelData(_levelIteration * _cellColumnCount);
        _curentCardIdentifier = _dataPreparer.GetChosenCardType;
        _uiTaskText.UpdateTaskText(_curentCardIdentifier);
        CreateCellColumn();
    }

    void CreateCellColumn()
    {
        foreach (GameObject Cell in _cellsList)
        {
            Cell.transform.position += _verticalOffset;
        }
        CreateCellLine();
        _levelIteration++;
    }

    void CreateCellLine()
    {
        for (int i = 0; i < _cellColumnCount; i++)
        {
            Vector3 newCellPosition = _horizontalStartPoint - Vector3.Scale(_horizontalOffset, new Vector3(i, 0, 0)) - _verticalOffset * (_levelIteration - 1);
            _cellsList.Add(_cellSpawner.SpawnCell(_cellPrefab, newCellPosition, _levelIteration == 1));
        }
        FillCells();
    }

    void FillCells()
    {
        List<int> tempIdentifiersList = _dataPreparer.GetLevelCardIndexes;
        int tempChosenCardDataKit = _dataPreparer.GetChosenCardDataKit;

        for (int i = 0; i < _cellsList.Count; i++)
        {
            string tempIdentifier = _cardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].Identifier;
            Sprite tempSprite = _cardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].Sprite;
            float tempRotationAngle = _cardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].RotationAngle;

            _cellsList[i].GetComponent<Cell>().SetCellParameters(tempIdentifier, tempSprite, tempRotationAngle);
        }
    }

    public void ChangeLevel—omplexity()
    {
        if (_levelIteration <= _cellLineCount)
        {
            CreateLevel();
            return;
        }

        foreach (GameObject Cell in _cellsList)
        {
            Destroy(Cell.GetComponent<BoxCollider2D>());
        }
        _gameEnder.EndGame();
    }
}
