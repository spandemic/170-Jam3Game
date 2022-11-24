using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHunger = 5;
    public int currentHunger;

    public HungerBar hungerBar;
    public float speed = .1f;

    void Start()
    {
        currentHunger = 0;
        hungerBar.SetMaxHunger(maxHunger);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddHunger(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SubtractHunger(1);
        }

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;

    }

    void AddHunger(int hunger)
    {
        currentHunger += hunger;
        hungerBar.SetHunger(currentHunger);
    }

    void SubtractHunger(int hunger)
    {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }
}



