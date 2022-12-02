using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTouch : MonoBehaviour
{
    //[SerializeField] private bool triggerActive = false;
    //public HungerBar hungerBar;
    //public int maxHunger = 3;
    //public int currentHunger;
    void Start()
    {
        //currentHunger = 0;
        //hungerBar.SetMaxHunger(maxHunger);
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        triggerActive = true;
    //    }
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        triggerActive = false;
    //    }
    //}

    //private void Update()
    //{
    //    if (triggerActive && Input.GetKeyDown(KeyCode.E))
    //    {
    //        SomeCoolAction();
    //    }
    //}

    //public void SomeCoolAction()
    //{
    //    Destroy(gameObject);
    //    AddHunger(1);
    //}

    //void AddHunger(int hunger)
    //{
    //    Debug.Log(currentHunger);
    //    currentHunger += hunger;
    //    hungerBar.SetHunger(currentHunger);
    //    if (currentHunger == maxHunger)
    //    {
    //        //RestartLevel();
    //    }
    //}
}