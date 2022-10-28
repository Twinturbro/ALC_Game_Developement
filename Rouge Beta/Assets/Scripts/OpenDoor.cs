using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameManager gm;//game manager script
    public float doorDelay = 0.5f;// how long the door takes to open

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();//Ging game manager object then reference scipt component
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gm.key >= 1)
        {
            Destroy(gameObject, doorDelay);
            gm.key--;
            Debug.Log("Keys = " + gm.key);
            Debug.Log("Door is open!");
        }
        else
        {
            Debug.Log("Door is Locked. You need a key");
        }
    }
}
