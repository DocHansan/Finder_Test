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
    Text _uiTaskText;
    [SerializeField]
    Button _restartButton;
    [SerializeField]
    GameObject _endGameScreen;

    Vector3 _horizontalStartPoint;
    Vector3 _horizontalOffset;
    Vector3 _verticalOffset;
    Vector3 _cellSize;
    CardDataPreparer _dataPreparer;
    int _levelIteration;
    string _curentCardIdentifier;
    List<GameObject> _cellsList;
    float _cellSpawnTime = 0.5f;
    GameEnder _gameEnder;

    void Awake()
    {
        _cellSize = Vector3.Scale(_cellPrefab.GetComponent<BoxCollider2D>().size, _cellPrefab.GetComponent<Transform>().localScale);
        _horizontalStartPoint = new Vector3(0.5f * (_cellColumnCount - 1) * (_cellSize.x + _intercellularSpace), 0, 0);
        _horizontalOffset = new Vector3(_cellSize.y + _intercellularSpace, 0, 0);
        _verticalOffset = new Vector3(0, (_cellSize.y + _intercellularSpace) / 2, 0);
        _dataPreparer = new CardDataPreparer(_cardDataKits);
        _gameEnder = _endGameScreen.GetComponent<GameEnder>();
    }

    void CreateCell(Vector3 position)
    {
        GameObject newCell = Instantiate(_cellPrefab, position, Quaternion.identity);
        if (_levelIteration == 1)
            newCell.GetComponent<Cell>().DoBounce(_cellSpawnTime);
        _cellsList.Add(newCell);
    }

    void FillCells()
    {
        List<int> tempIdentifiersList = _dataPreparer.GetLevelCardIndexes();
        int tempChosenCardDataKit = _dataPreparer.GetChosenCardDataKit();

        for (int i = 0; i < _cellsList.Count; i++)
        {
            string tempIdentifier = _cardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].Identifier;
            Sprite tempSprite = _cardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].Sprite;
            float tempRotationAngle = _cardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].RotationAngle;
            
            _cellsList[i].GetComponent<Cell>().SetCellParameters(tempIdentifier, tempSprite, tempRotationAngle);
        }
    }

    public void ResetField()
    {
        _levelIteration = 1;
        _cellsList = new List<GameObject>();

        DestroyCells();

        _dataPreparer.ResetParameters();

        CreateLevel();
    }

    void DestroyCells()
    {
        foreach (GameObject Cell in GameObject.FindGameObjectsWithTag("Cell"))
        {
            Destroy(Cell);
        }
    }

    void CreateLevel()
    {
        _dataPreparer.CreateLevelData(_levelIteration * _cellColumnCount);
        _curentCardIdentifier = _dataPreparer.GetChosenCardType();

        int tempChosenCardDataKit = _dataPreparer.GetChosenCardDataKit();
        _uiTaskText.GetComponent<UITaskText>().UpdateTaskText(_curentCardIdentifier);

        CreateCellColumn();
    }

    void CreateCellLine()
    {
        for (int i = 0; i < _cellColumnCount; i++)
        {
            CreateCell(_horizontalStartPoint - Vector3.Scale(_horizontalOffset, new Vector3(i, 0, 0)) - _verticalOffset * (_levelIteration - 1));
        }
        FillCells();
    }

    void CreateCellColumn()
    {
        foreach (GameObject cellPrefab in GameObject.FindGameObjectsWithTag("Cell"))
        {
            cellPrefab.transform.position += _verticalOffset;
        }
        CreateCellLine();

        _levelIteration++;
    }

    public string GetCardIdentifier()
    {
        return _curentCardIdentifier;
    }

    public void ChangeLevelÑomplexity()
    {
        if (_levelIteration > _cellLineCount)
        {
            foreach (GameObject Cell in _cellsList)
            {
                Destroy(Cell.GetComponent<BoxCollider2D>());
            }
            _restartButton.GetComponent<RestartButton>().SetButtonActivity(true);
            _gameEnder.ShowEndGameScreen();
        }
        else
            CreateLevel();
    }
}
