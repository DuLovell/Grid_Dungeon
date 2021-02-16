using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    private float lerpTimeElapsed = 0f;
    private float lerpDuration = 1f;
    Vector2 startLerpValue;
    Vector2 endLerpValue;

    private bool isMoving = false;

    #endregion

    #region Properties

    public static Vector2 PlayerPosition { get; private set; }

    #endregion

    #region Methods

    private void Awake()
    {
        PlayerPosition = transform.position;
        startLerpValue = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && Plate.MoveIsCorrect)
        {
            isMoving = true;
            startLerpValue = transform.position;
            endLerpValue = Plate.PositionForPlayerMove;
        }
        if (isMoving)
            Moving();
    }

    private void Moving()
    {
        if (lerpTimeElapsed < lerpDuration)
        {
            transform.position = Vector2.Lerp(startLerpValue, endLerpValue, lerpTimeElapsed / lerpDuration);  // Патрулирование
            lerpTimeElapsed += Time.fixedDeltaTime;
        }
        else
        {
            PlayerPosition = transform.position;
            isMoving = false;
            lerpTimeElapsed = 0;
        }
    }

    #endregion

}
