using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public GameObject SpawnCell(GameObject cellPrefab, Vector3 position, bool isNeedBounce)
    {
        GameObject newCell = Instantiate(cellPrefab, position, Quaternion.identity);
        if (isNeedBounce)
            newCell.GetComponent<CellAnimator>().Bounce();
        return newCell;
    }
}
