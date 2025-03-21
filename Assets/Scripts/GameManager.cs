using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //----------TODO----------//
    //Setup a main menu and end game screen and connect them through the game manager
    public static GameManager instance;

    //Make public intiger for the players Lives to be called on by the light manager function
    public int playerLives = 3;

    //Awake is a built-in function that runs when the project loads.
    //This is our Setter?
    void Awake()
    {
        //If there is already a GameManager, destroy this one. If there isn't,
        //then this is the GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); //DontDestroyOnLoad make an object persistant
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives == 0)
        {
            gameOver();
        }
    }

    void startGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    void gameOver()
    {
        SceneManager.LoadScene("EndGame");
    }
}
