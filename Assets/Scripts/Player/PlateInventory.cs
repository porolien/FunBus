using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInventory : MonoBehaviour
{
    [SerializeField]
    List<Transform> probsPositions = new List<Transform>();

    [SerializeField]
    List<Transform> transformUse = new List<Transform>();

    public List<GameObject> probs = new List<GameObject>();

    int _numberOfProbs;

    int _probsSelected;

    [SerializeField]
    int _maxOfProbs;

    Material _lastMaterial;

    [SerializeField]
    Material _glowMaterial;

    GameObject _lastSelectedProbs;

    private void Start()
    {
        GetComponent<PlateMain>().plateInventory = this;
    }
    public void TakeObject(GameObject newProbs)
    {
        if(_numberOfProbs < _maxOfProbs)
        {
            GameObject _newProbs = Instantiate(newProbs);
            probs.Add(_newProbs);
            Transform placeOfNewObject = probsPositions[0];
            if (transformUse.Count > 0)
            {
                foreach (Transform allTransform in probsPositions)
                {
                    bool useThisTransform = true;
                    foreach (Transform useTransform in transformUse)
                    {
                        if (allTransform.position == useTransform.position)
                        {
                            useThisTransform = false;
                        }
                    }
                    if (useThisTransform)
                    {
                        placeOfNewObject = allTransform;
                    }
                }
                transformUse.Add(placeOfNewObject);
            }
            else
            {
                transformUse.Add(placeOfNewObject);
            }
            
            _newProbs.transform.parent = placeOfNewObject;
            _newProbs.transform.position = new Vector3 (_newProbs.transform.parent.position.x, _newProbs.transform.parent.position.y + (_newProbs.transform.localScale.y/2), _newProbs.transform.parent.position.z) ;
            _numberOfProbs++;
        }
        else
        {
            Debug.Log("Too much Probs");
        }
        
    }

    public void PutObject(GameObject _newProbs)
    {
        probs.Remove(_newProbs);
        _numberOfProbs--;
    }

    public void SelectASelectable(int _theSelectable)
    {
        if(_numberOfProbs != 0)
        {
            if(_numberOfProbs == 1)
            {
                
            }
            else
            {
                _probsSelected += _theSelectable;
                if (_probsSelected > _numberOfProbs - 1)
                {
                    _probsSelected = 0;
                }
                else if (_probsSelected < 0)
                {
                    _probsSelected = _numberOfProbs - 1;
                }

                if(_lastSelectedProbs != null)
                {
                    _lastSelectedProbs.GetComponent<MeshRenderer>().material = _lastMaterial;
                }

                ProbsSelected();
            }
        }
    }

    void ProbsSelected()
    {
        _lastMaterial = probs[_probsSelected].GetComponent<MeshRenderer>().material;
        probs[_probsSelected].GetComponent<MeshRenderer>().material = _glowMaterial;
        _lastSelectedProbs = probs[_probsSelected];
    }

    public void DropSelectedProbs()
    {
        if (probs[_probsSelected] != null){
            transformUse.Remove(probs[_probsSelected].transform.parent);
            GameObject objet = probs[_probsSelected];
            probs.Remove(probs[_probsSelected]);
            Destroy(objet);
            _numberOfProbs--;
        }

    }
}
