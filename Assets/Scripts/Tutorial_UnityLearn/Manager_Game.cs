using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Game : MonoBehaviour
{
    public static Manager_Game instance = null;

    int level = 3;
    Manager_Board boardScript;

    public int PlayerHealth { get; set; }
    public bool PlayersTurn { get; set; }

    private void Awake()
    { 
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<Manager_Board>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
        PlayersTurn = true;
    }

    public void GameOver()
    {
        enabled = false;
    }
}
