using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _cellPrefab;

    public GameObject SpawnCell(Vector3 position, bool isNeedBounce)
    {
        GameObject newCell = Instantiate(_cellPrefab, position, Quaternion.identity);
        if (isNeedBounce)
            newCell.GetComponent<CellAnimator>().BounceCell();
        return newCell;
    }
}
