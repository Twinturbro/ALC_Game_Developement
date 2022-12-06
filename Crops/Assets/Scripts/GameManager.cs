using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasFlag;
    public bool placedFlag;

    // Start is called before the first frame update
    void Start()
    {
        hasFlag = false;
        placedFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(placedFlag)
        {
            WinGame();
        }
    }

    public void PlaceFlag()
    {
        if(hasFlag)
        {
                placedFlag = true;
            Debug.Log("The Flag has been placed game won!");
        }
    }

    public void WinGame()
    {
        Debug.Log("your team wins!");
        Time.timeScale = 0;
    }
}
