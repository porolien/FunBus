using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    private static CustomerManager _instance = null;

    public static CustomerManager Instance => _instance;

    public List<Customer> customer = new List<Customer>();
    public List<Customer> customerWithoutDemand = new List<Customer>();

    public List<GameObject> allIcon = new List<GameObject>();

    public PlayerMain playerMain;

    float errorNumber;

    public AudioClip bubbleBegin;
    public AudioClip bubbleEnd;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
       foreach(var hum in GameObject.FindGameObjectsWithTag("Human"))
        {
            Customer newCustomer = hum.GetComponent<Customer>();
            customer.Add(newCustomer);
            customerWithoutDemand.Add(newCustomer);
        }
        InvokeRepeating("StartDemand", 5, 10);
    }

    void StartDemand()
    {
        if(customerWithoutDemand.Count != 0)
        {
            int randomCustomer = Random.Range(0, customerWithoutDemand.Count);
            customerWithoutDemand[randomCustomer].CreateDemand();
            customerWithoutDemand.Remove(customerWithoutDemand[randomCustomer]);
        }
    }

    public void PlayerMistake()
    {
        errorNumber++;
        if(errorNumber >= 5) 
        {
            Debug.Log("GameOver");
        }
    }
}
