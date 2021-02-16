using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Manager_Board : MonoBehaviour
{
    [SerializeField] int columns = 8;
    [SerializeField] int rows = 8;

    [SerializeField] GameObject[] edgeTiles_Top;
    [SerializeField] GameObject[] edgeTiles_Right;
    [SerializeField] GameObject[] edgeTiles_Bottom;
    [SerializeField] GameObject[] edgeTiles_Left;
    [SerializeField] GameObject[] cornerTiles;
    [SerializeField] GameObject[] floorTiles;

    Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 0; x < columns - 1; x++)
        {
            for (int y = 0; y < rows - 1; y++)
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

    // Start is called before the first frame update
    void Start()
    {
        InitializeList();
        BoardSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
