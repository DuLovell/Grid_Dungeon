using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Manager_Board : MonoBehaviour
{
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    [SerializeField] int columns = 8;
    [SerializeField] int rows = 8;

    [SerializeField] Count wallCount = new Count(3, 7);
    [SerializeField] Count mageCount = new Count(1, 3);

    #region Tiles Prefabs
    [SerializeField] GameObject[] edgeTiles_Top;
    [SerializeField] GameObject[] edgeTiles_Right;
    [SerializeField] GameObject[] edgeTiles_Bottom;
    [SerializeField] GameObject[] edgeTiles_Left;

    [SerializeField] GameObject[] cornerTiles;

    [SerializeField] GameObject[] floorTiles;

    [SerializeField] GameObject[] wallTiles;
    #endregion

    List<Vector3> gridPositions = new List<Vector3>();
    Transform boardHolder;
    
    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                
                if (x == -1 && y == -1)
                    toInstantiate = cornerTiles[0]; // left bottom corner
                else if (x == -1 && y == rows)
                    toInstantiate = cornerTiles[1]; // left up corner
                else if (x == columns && y == -1)
                    toInstantiate = cornerTiles[2]; // right bottom corner
                else if (x == columns && y == rows)
                    toInstantiate = cornerTiles[3]; // right up corner
                else if (x == -1)
                    toInstantiate = edgeTiles_Left[Random.Range(0, edgeTiles_Left.Length)];
                else if (x == columns)
                    toInstantiate = edgeTiles_Right[Random.Range(0, edgeTiles_Right.Length)];
                else if (y == -1)
                    toInstantiate = edgeTiles_Bottom[Random.Range(0, edgeTiles_Bottom.Length)];
                else if (y == rows)
                    toInstantiate = edgeTiles_Top[Random.Range(0, edgeTiles_Top.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition(int size)
    {
        int randomIndex = Random.Range(0, gridPositions.Count);

        if (size == 2 && randomIndex != gridPositions.Count - 1)
            gridPositions.RemoveAt(randomIndex + 1);

        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        int objectSize = (int)tileArray[0].GetComponent<SpriteRenderer>().size.y;

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition(objectSize);
            GameObject toInstantiate = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(toInstantiate, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
    }

    private void Start()
    {
        SetupScene(1);
    }
}
