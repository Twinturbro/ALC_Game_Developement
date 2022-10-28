using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int key;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddKey(int amount)
    {
        key += amount;// adds keys to inventory
        Debug.Log(" You have " + key + " key(s)");
    }
}


