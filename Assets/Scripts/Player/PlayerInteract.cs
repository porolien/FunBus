using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private RaycastHit raycastHit;
    private PlayerMain _playerMain;
    public GameObject point;
    void Start()
    {
         _playerMain = GetComponent<PlayerMain>();
        _playerMain.playerInteract = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindSelectable();
    }

    void FindSelectable()
    {
        //point.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 20)) { }
        
    }

    public void Interact()
    {
        if(raycastHit.transform != null)
        {
            if (raycastHit.transform.tag == "Selectable")
            {
                Debug.Log("selectable");
                _playerMain.plateMain.plateInventory.TakeObject(raycastHit.transform.gameObject);
            }

            if (raycastHit.transform.tag == "Human")
            {
                if (raycastHit.transform.GetComponent<Customer>().hasADemand)
                {
                    _playerMain.plateMain.plateInventory.PutObject(raycastHit.transform.gameObject);
                }
            }
        }
    }
}
   
