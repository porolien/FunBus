using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectableStatic;

public class Customer : MonoBehaviour
{
    public bool hasADemand;

    SelectableType typeDemand;

    public void CreateDemand()
    {
        typeDemand = CustomerManager.Instance.allIcon[Random.Range(0, CustomerManager.Instance.allIcon.Count)].GetComponent<CustomerIcon>().typeDemand;
    }

    public void DemandFinish(SelectableType typeReceive)
    {
        if(typeReceive == typeDemand)
        {

        }
    }
}
