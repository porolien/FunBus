using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInventory : MonoBehaviour
{
    [SerializeField]
    List<Transform> probsPositions = new List<Transform>();
    
    public List<GameObject> probs = new List<GameObject>();

    int _numberOfProbs;

    [SerializeField]
    int _maxOfProbs;

    private void Start()
    {
        GetComponent<PlateMain>().plateInventory = this;
    }
    public void TakeObject(GameObject _newProbs)
    {
        if(_numberOfProbs < _maxOfProbs)
        {
            probs.Add(_newProbs);
            _newProbs.transform.parent = probsPositions[_numberOfProbs];
            _newProbs.transform.position = new Vector3 (_newProbs.transform.parent.position.x, _newProbs.transform.parent.position.y + (_newProbs.transform.localScale.y/2), _newProbs.transform.parent.position.z) ;
            _numberOfProbs++;
        }
        else
        {
            Debug.Log("Too much Probs");
        }
        
    }

    void PutObject(GameObject _newProbs)
    {
        probs.Remove(_newProbs);
        _numberOfProbs--;
    }
}
