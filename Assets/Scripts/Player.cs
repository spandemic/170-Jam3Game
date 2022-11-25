using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddHunger(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SubtractHunger(1);
        }
        */

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("edible"))
        {
            Destroy(collision.gameObject);
            AddHunger(1);
        }
    }

    void AddHunger(int hunger)
    {
        currentHunger += hunger;
        hungerBar.SetHunger(currentHunger);
        if(currentHunger == maxHunger)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SubtractHunger(int hunger)
    {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }
}



