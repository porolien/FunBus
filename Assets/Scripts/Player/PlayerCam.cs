using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private void Start()
    {
        transform.parent.GetComponent<PlayerMain>().playercam = this;
    }
    public void MoveCameY(Vector3 _rotate)
    {
        this.transform.eulerAngles = this.transform.eulerAngles - _rotate;
    }
}
