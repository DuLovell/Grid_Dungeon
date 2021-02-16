using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties

    public static Vector2 PositionForPlayerMove { get; private set; }

    public static bool MoveIsCorrect { get; private set; }

    public static Vector2 PlatePosition { get; private set; }

    #endregion

    #region Methods

    private void Awake()
    {
        PlatePosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveIsCorrect = false;
    }

    private void OnMouseDown()
    {
        PositionForPlayerMove = transform.position;

        if (Mathf.Abs(transform.position.x - Player.PlayerPosition.x) < 1.4f
            && Mathf.Abs(transform.position.y - Player.PlayerPosition.y) <= 0.01f
            || Mathf.Abs(transform.position.x - Player.PlayerPosition.x) <= 0.01f
            && Mathf.Abs(transform.position.y - Player.PlayerPosition.y) < 1.4)
            MoveIsCorrect = true;
    }
    #endregion

}
