using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public HungerBar hungerBar;
    public int maxHunger = 3;
    public int currentHunger;
    public float speed = .0005f;
    public Transform cam;
    public float playerActivateDistance;
    public GameObject level1Blocks;
    public GameObject level2Blocks;
    public GameObject level3Blocks;
    public GameObject winObject;
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private Collider triggered;
    void Start()
    {
        currentHunger = 0;
        hungerBar.SetMaxHunger(maxHunger);
        level1Blocks.SetActive(true);
        level2Blocks.SetActive(false);
        level3Blocks.SetActive(false);
        winObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            if(triggered != null)
            {
                SomeCoolAction(triggered);
            }
            
            
        }

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("edible"))
        {
            triggerActive = true;
            triggered = collision;
        }
        if (collision.CompareTag("toxic"))
        {
            triggerActive = true;
            triggered = collision;
        }
        if (collision.gameObject.CompareTag("level1Goal"))
        {
            transform.position = new Vector3(3.81f, 2.1f, 4.07f);
            level1Blocks.SetActive(false);
            level2Blocks.SetActive(true);
            hungerBar.SetHunger(0);
            currentHunger = 0;
        }
        if (collision.gameObject.CompareTag("level2Goal"))
        {
            transform.position = new Vector3(3.81f, 2.1f, 4.07f);
            level2Blocks.SetActive(false);
            level3Blocks.SetActive(true);
            hungerBar.SetHunger(0);
            currentHunger = 0;
        }
        if (collision.gameObject.CompareTag("level3Goal"))
        {
            transform.position = new Vector3(3.81f, 2.1f, 4.07f);
            level2Blocks.SetActive(false);
            level3Blocks.SetActive(true);
            hungerBar.SetHunger(0);
            currentHunger = 0;
            winObject.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("edible"))
        {
            triggerActive = false;
        }
    }

    public void SomeCoolAction(Collider collision)
    {
        if(collision.CompareTag("edible"))
        {
            Destroy(collision.gameObject);
            AddHunger(1);
        }
        if (collision.CompareTag("toxic"))
        {
            RestartLevel();
            
        }
        triggered = null;
    }

    void AddHunger(int hunger)
    {
        currentHunger += hunger;
        hungerBar.SetHunger(currentHunger);
        if (currentHunger == maxHunger)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



