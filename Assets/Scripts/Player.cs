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

        if (collision.gameObject.CompareTag("toxic"))
        {
            Destroy(collision.gameObject);
            restartLevel();
        }
    }

    void AddHunger(int hunger)
    {
        currentHunger += hunger;
        hungerBar.SetHunger(currentHunger);
        if(currentHunger == maxHunger)
        {
            restartLevel(); 
        }
    }

    void SubtractHunger(int hunger)
    {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



