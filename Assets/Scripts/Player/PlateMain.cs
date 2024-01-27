using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMain : MonoBehaviour
{
    public PlateBalancer plateBalancer;
    public PlateInventory plateInventory;

    private void Start()
    {
        transform.parent.GetComponent<PlayerMain>().plateMain = this;
    }
}
