using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    principalMenu,
    History,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    gameOver,
    Credits,
    Controls
}

public class GameManager : MonoBehaviour
{
    // Inicializo el singleton en el primer script 
    public static GameManager sharedInstance;

    // Declaración del estado del juego
    public GameState currentGameState = GameState.principalMenu;

    public void Awake()
    {
        // que despierte y enfatizo con el siguiente fragmento
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Función encargado de iniciar la scena menú principal
    public void PrincipalMenu()
    {
        SetGameState(GameState.principalMenu);
    }
    // Función encargado de iniciar la scena historia
    public void History()
    {
        SetGameState(GameState.History);
    }
    // Función encargado de iniciar la scena level1
    public void Level1()
    {
        SetGameState(GameState.Level1);
    }
    // Función encargado de iniciar la scena level2
    public void Level2()
    {
        SetGameState(GameState.Level2);
    }
    // Función encargado de iniciar la scena level3
    public void Level3()
    {
        SetGameState(GameState.Level3);
    }
    // Función encargado de iniciar la scena level4
    public void Level4()
    {
        SetGameState(GameState.Level4);
    }
    // Función encargado de iniciar la scena level5
    public void Level5()
    {
        SetGameState(GameState.Level5);
    }
    public void Credits()
    {
        SetGameState(GameState.Credits);
    }
    public void Controls()
    {
        SetGameState(GameState.Controls);
    }
    // Función encargado de iniciar la scena de final de juego
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void SetGameState(GameState newGameState)
    {
        this.currentGameState = newGameState;

        if (newGameState == GameState.principalMenu)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("PrincipalMenu");
        }
        else if (newGameState == GameState.History)
        {
             //TODO: colocar la logica del historia
            SceneManager.LoadScene("History");
        }
        else if (newGameState == GameState.Level1)
        {
             //TODO: colocar la logica del level 1
            SceneManager.LoadScene("GameLevel1");
        }
        else if (newGameState == GameState.Level2)
        {
            //TODO: colocar la logica del level 2
            SceneManager.LoadScene("GameLevel2");
        }
        else if (newGameState == GameState.Level3)
        {
            //TODO: colocar la logica del level 3
            SceneManager.LoadScene("GameLevel3");
        }
        else if (newGameState == GameState.Level4)
        {
            //TODO: colocar la logica del level 4
            SceneManager.LoadScene("GameLevel4");
        }
        else if (newGameState == GameState.Level5)
        {
            //TODO: colocar la logica del level 5
            SceneManager.LoadScene("GameLevel5");
        }
              else if (newGameState == GameState.Credits)
        {
            //TODO: colocar la logica del level 5
            SceneManager.LoadScene("Credits");
        }
              else if (newGameState == GameState.Controls)
        {
            //TODO: colocar la logica del level 5
            SceneManager.LoadScene("Controls");
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: colocar la logica del gameOver
            SceneManager.LoadScene("GameOver");
        }
    }
}

