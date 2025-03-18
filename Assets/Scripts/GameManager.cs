using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        
    }
}
