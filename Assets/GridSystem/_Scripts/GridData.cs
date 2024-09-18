using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    Dictionary<Vector3Int, PlacementData> placedObject = new();
    public void AddObjectAt(Vector3Int gridposition,
                            Vector2Int ObjectSize,
                            int ID,
                            int placeObjectIndex)
    {
        List<Vector3Int> positionToOccupy = CalculatePosition(gridposition, ObjectSize);
        PlacementData data = new PlacementData(positionToOccupy, ID, placeObjectIndex);

        foreach(var pos in positionToOccupy)
        {
            if (placedObject.ContainsKey(pos))
                throw new Exception($"Dictionary already contains this cell position {pos}");
            placedObject[pos] = data;
        }
    }

    private List<Vector3Int> CalculatePosition(Vector3Int gridposition, Vector2Int objectSize)
    {
        List<Vector3Int> retuenVal = new();
        for(int x = 0; x < objectSize.x; x++)
        {
            for(int y = 0;y< objectSize.y; y++)
            {
                retuenVal.Add(gridposition + new Vector3Int(x,0,y));
            }
        }
        return retuenVal;
    }

    public bool CanPlaceObjectAt(Vector3Int gridposition, Vector2Int objectSize)
    {
        List<Vector3Int> positionToOccupy = CalculatePosition(gridposition, objectSize);
        foreach(var pos in positionToOccupy)
        {
            if(placedObject.ContainsKey(pos)) return false;
        }
        return true;
    }
}

public class PlacementData
{
    public List<Vector3Int> occupiedPositions;
    public int ID { get; private set; }

    public int PlacedObjectIndex { get; private set; }
    public PlacementData(List<Vector3Int> occupiedPositions, int iD, int placedObjectIndex)
    {
        this.occupiedPositions = occupiedPositions;
        ID = iD;
        PlacedObjectIndex = placedObjectIndex;
    }
}