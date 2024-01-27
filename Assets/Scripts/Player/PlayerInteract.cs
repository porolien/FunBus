using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private RaycastHit raycastHit;
    private PlayerMain _playerMain;
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
        }
        
    }
}
   
