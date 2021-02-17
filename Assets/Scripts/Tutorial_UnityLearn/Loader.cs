using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] Manager_Game gameManager;
    private void Awake()
    {
        if (Manager_Game.instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
