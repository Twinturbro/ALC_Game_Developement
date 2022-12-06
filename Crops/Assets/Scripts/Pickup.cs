using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    [Header ("Pickup Stats")]
    public PickupType type;
    public int healthAmount;
    public int ammoAmount;

    [Header("Bobing Anim")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    private Vector3 startPos;
    private bool bobbingUp;
    private bool bobbingup;

    //public Audioclip pickupSfx;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController Player = other.GetComponent<FPSController>();

            switch (type)
            {
                case PickupType.Health:
                    Player.GiveHealth(healthAmount);
                        break;

                case PickupType.Ammo:
                    Player.GiveAmmo(ammoAmount);
                    break;
            }

            Destroy(gameObject);
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3(0,bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if (transform.position == startPos + offset)
            bobbingup = !bobbingUp;
    }
}