using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameField : MonoBehaviour
{
    [SerializeField]
    public GameObject CellPrefab;
    [SerializeField][Range(1, 4)]
    public int CellLineCount;
    [SerializeField][Range(1, 5)]
    public int CellColumnCount;
    [SerializeField]
    public AllCardData CardDataKits;
    [SerializeField][Range(0f, 2f)]
    public float IntercellularSpace = 0.2f;
    [SerializeField]
    public Text UITaskText;
    [SerializeField]
    public Button RestartButton;
    [SerializeField]
    public FadeAnimator FadeAnimator;

    Vector3 _horizontalStartPoint;
    Vector3 _horizontalOffset;
    Vector3 _verticalOffset;
    Vector3 _cellSize;
    CardDataPreparer _dataPreparer;
    int _levelIteration;
    int _curentCardIdentifier;
    List<GameObject> _cellsList;

    void Awake()
    {
        _cellSize = Vector3.Scale(CellPrefab.GetComponent<BoxCollider2D>().size, CellPrefab.GetComponent<Transform>().localScale);
        _horizontalStartPoint = new Vector3(0.5f * (CellColumnCount - 1) * (_cellSize.x + IntercellularSpace), 0, 0);
        _horizontalOffset = new Vector3(_cellSize.y + IntercellularSpace, 0, 0);
        _verticalOffset = new Vector3(0, (_cellSize.y + IntercellularSpace) / 2, 0);

        _dataPreparer = new CardDataPreparer(CardDataKits);
    }

    void CreateCell(Vector3 position)
    {
        GameObject newCell = Instantiate(CellPrefab, position, Quaternion.identity);
        _cellsList.Add(newCell);
    }

    void FillCells()
    {
        List<int> tempIdentifiersList = _dataPreparer.GetLevelCardIndexes();
        int tempChosenCardDataKit = _dataPreparer.GetChosenCardDataKit();

        for (int i = 0; i < _cellsList.Count; i++)
        {
            int tempIdentifier = tempIdentifiersList[i];
            Sprite tempSprite = CardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].Sprite;
            float tempRotationAngle = CardDataKits.CardDataKits[tempChosenCardDataKit].CardData[tempIdentifiersList[i]].RotationAngle;
            
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
        _dataPreparer.CreateLevelData(_levelIteration * CellColumnCount);
        _curentCardIdentifier = _dataPreparer.GetChosenCardType();

        int tempChosenCardDataKit = _dataPreparer.GetChosenCardDataKit();
        UITaskText.GetComponent<UITaskText>().UpdateTaskText(CardDataKits.CardDataKits[tempChosenCardDataKit].CardData[_curentCardIdentifier].Identifier);

        CreateCellColumn();
    }

    void CreateCellLine()
    {
        for (int i = 0; i < CellColumnCount; i++)
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

    public int GetCardIdentifier()
    {
        return _curentCardIdentifier;
    }

    public void ChangeLevelÑomplexity()
    {
        if (_levelIteration > CellLineCount)
        {
            foreach (GameObject Cell in _cellsList)
            {
                FadeAnimator.FadeOut(FadeAnimator.FadeTime, Cell);
                FadeAnimator.FadeOut(FadeAnimator.FadeTime, Cell.transform.GetChild(0).gameObject);
                Destroy(Cell.GetComponent<BoxCollider2D>());
            }
            RestartButton.GetComponent<RestartButton>().ShowRestartButton();
        }
        else
            CreateLevel();
    }
}
