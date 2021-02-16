using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager
{
    #region Properties

    public static Enum_Menus CurrentMenu { get; private set; } 

    #endregion

    #region Methods

    #endregion
    public static void GoToMenu(Enum_Menus menu)
    {
        switch (menu)
        {
            case Enum_Menus.Menu_PrepareForBattle:
                SceneManager.LoadScene("PrepareForBattle");
                CurrentMenu = Enum_Menus.Menu_PrepareForBattle;
                break;

            case Enum_Menus.Menu_Battle:
                SceneManager.LoadScene("Battle");
                CurrentMenu = Enum_Menus.Menu_Battle;
                break;
        }
    }
}
