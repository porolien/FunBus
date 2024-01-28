using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectableStatic;

public class CustomerIcon : MonoBehaviour
{
    public SelectableType typeDemand;

    private void FixedUpdate()
    {
        transform.LookAt(CustomerManager.Instance.playerMain.transform.position);
    }
}
