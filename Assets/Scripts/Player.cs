using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHunger = 5;
    public int currentHunger;

    public HungerBar hungerBar;
    public float speed = .01f;
    public Transform cam;
    public float playerActivateDistance;
    bool active = false;
    public GameObject level1Blocks;
    public GameObject level2Blocks;
    public GameObject level3Blocks;
    void Start()
    {
        currentHunger = 0;
        hungerBar.SetMaxHunger(maxHunger);
        level1Blocks.SetActive(true);
        level2Blocks.SetActive(false);
        level3Blocks.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        //Debug.Log(active);
        if(Input.GetKeyDown(KeyCode.E) && active == true)
        {
            Debug.Log("active is true");
            if(hit.transform.CompareTag("edible"))
            {
                Debug.Log("hit");
                Destroy(hit.collider.gameObject);
                AddHunger(1);
            }

            if (hit.transform.CompareTag("toxic"))
            {
                Destroy(hit.collider.gameObject);
                RestartLevel();
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hey");
        }
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;



    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("edible"))
        {
            Debug.Log("in there");
            Destroy(collision.gameObject);
            AddHunger(1);
        }
        if (collision.gameObject.CompareTag("level1Goal"))
        {
            //RestartLevel();
            transform.position = new Vector3(3.81f, 2.1f, 4.07f);
            level1Blocks.SetActive(false);
            level2Blocks.SetActive(true);
        }
        if (collision.gameObject.CompareTag("level2Goal"))
        {
            transform.position = new Vector3(3.81f, 2.1f, 4.07f);
            level2Blocks.SetActive(false);
            level3Blocks.SetActive(true);
        }
        if (collision.gameObject.CompareTag("level3Goal"))
        {
            transform.position = new Vector3(3.81f, 2.1f, 4.07f);
            level2Blocks.SetActive(false);
            level3Blocks.SetActive(true);
        }
    }

    void AddHunger(int hunger)
    {
        currentHunger += hunger;
        hungerBar.SetHunger(currentHunger);
        if(currentHunger == maxHunger)
        {
            RestartLevel(); 
        }
    }

    void SubtractHunger(int hunger)
    {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



