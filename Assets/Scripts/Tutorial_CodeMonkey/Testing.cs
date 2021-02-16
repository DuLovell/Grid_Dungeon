using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(16, 7, 1f, new Vector3(-8, -3));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            int value = grid.GetValue(mousePosition);
            grid.SetValue(mousePosition, value + 5);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Debug.Log(grid.GetValue(mousePosition));
        }
    }

}
