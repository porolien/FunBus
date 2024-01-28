using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectableStatic;

public class Customer : MonoBehaviour
{
    public bool hasADemand;

    SelectableType typeDemand;

    CustomerIcon actualIcon;

    public ParticleSystem Wrong;
    public ParticleSystem Correct;
    public void CreateDemand()
    {
        actualIcon = Instantiate(CustomerManager.Instance.allIcon[Random.Range(0, CustomerManager.Instance.allIcon.Count)].GetComponent<CustomerIcon>());
        typeDemand = actualIcon.typeDemand;
        actualIcon.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        hasADemand = true;
    }

    public void DemandFinish(SelectableType typeReceive)
    {
        if (hasADemand)
        {
            if (typeReceive == typeDemand)
            {
                //Correct.Play();
            }
            else
            {
                CustomerManager.Instance.PlayerMistake();
                //Wrong.Play();
            }
            CustomerManager.Instance.customerWithoutDemand.Add(this);
            hasADemand = false;
            Destroy(actualIcon.gameObject);
        }
    }
}
