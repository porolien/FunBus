using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    PlayerMain _playerMain;
    private void Start()
    {
        _playerMain = GetComponent<PlayerMain>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Human")
        {
            if(_playerMain.plateMain.plateInventory._numberOfProbs > 0)
            {
                _playerMain.plateMain.plateBalancer.Balancing();
            }
        }
    }
}
