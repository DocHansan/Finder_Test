using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField]
    public GameObject CellPrefab;
    [SerializeField]
    public int CellLineCount;
    [SerializeField]
    public int CellColumnCount;
    [SerializeField]
    public AllCardData CardDataKits;
    [SerializeField][Range(0f, 2f)]
    public float IntercellularSpace = 0.2f;

    Vector3 _horizontalOffset;
    Vector3 _verticalOffset;
    Vector3 _cellSize;
    CardPreparer _dataPreparer;
    int _levelIteration = 0;


    public void CreateCell(int index, Vector3 position)
    {
        int tempIdentifier = _dataPreparer.GetLevelCardIndexes()[index];
        Sprite tempSprite = CardDataKits.CardDataKits[_dataPreparer.GetChosenCardDataKit()].CardData[_dataPreparer.GetLevelCardIndexes()[index]].Sprite;
        float tempRotationAngle = CardDataKits.CardDataKits[_dataPreparer.GetChosenCardDataKit()].CardData[_dataPreparer.GetLevelCardIndexes()[index]].RotationAngle;

        GameObject newCell = Instantiate(CellPrefab, position, Quaternion.identity);
        newCell.GetComponent<Cell>().SetCellParameters(tempIdentifier, tempSprite, tempRotationAngle);
    }

    void Start()
    {
        _cellSize = Vector3.Scale(CellPrefab.GetComponent<BoxCollider2D>().size, CellPrefab.GetComponent<Transform>().localScale);
        _horizontalOffset = new Vector3(_cellSize.x + IntercellularSpace, 0, 0);
        _verticalOffset = new Vector3(0, (_cellSize.y + IntercellularSpace) / 2, 0);

        CreateCardPreparer();
        _dataPreparer.CreateLevelData(3);

        CreateCellLine();
        CreateCellColumn();
        CreateCellColumn();
    }

    void CreateCardPreparer()
    {
        _dataPreparer = new CardPreparer(CardDataKits);
    }

    void CreateCellLine()
    {
        for (int i = 0; i < CellLineCount; i++)
        {
            CreateCell(i, _horizontalOffset - Vector3.Scale(_horizontalOffset, new Vector3(i, 0, 0)) - _verticalOffset * _levelIteration);
        }
    }

    void CreateCellColumn()
    {
        _levelIteration++;

        foreach (GameObject cellPrefab in GameObject.FindGameObjectsWithTag("Cell"))
        {
            //Debug.Log(cellPrefab.GetType());
            cellPrefab.transform.position += _verticalOffset;
        }
        CreateCellLine();
    }
}
