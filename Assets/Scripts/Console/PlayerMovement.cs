using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerMain _playerMain;

    [Header("Move the player")]
    Vector3 _direction;
    [SerializeField]
    float _speed;

    [Header("Move the camera")]
    private float x;
    private float y;
    public float sensitivity = -10f;
    private Vector3 rotate;

    [SerializeField]
    List<AudioClip> clipsStep = new List<AudioClip>();
    bool waitNewStep;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(_speed == 0)
        {
            _speed = 5;
        }
        _playerMain = GetComponent<PlayerMain>();
        _playerMain.playerMovement = this;
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        MoveCamera();
        if((_direction.x != 0 || _direction.z != 0) && !waitNewStep)
        {
            StartCoroutine(StepSFX());
        }
    }

    public void Move(Vector3 newDirection)
    {
        _direction = newDirection;
    }

    void MoveCamera()
    {
        this.y = Input.GetAxis("Mouse X");
        this.x = Input.GetAxis("Mouse Y");
        this.rotate = new Vector3(0, this.y * this.sensitivity, 0);
        this.transform.eulerAngles = this.transform.eulerAngles - this.rotate;
        this.rotate = new Vector3(this.x, 0, 0);
        _playerMain.playercam.MoveCameY(rotate);
    }

    public void ConsoleChangeSpeed(float speed)
    {
        _speed = speed;
    }

    IEnumerator StepSFX()
    {
        waitNewStep = true;
        SFXManager.Instance.NewSFXPlay(clipsStep[Random.Range(0, clipsStep.Count)]);
        yield return new WaitForSeconds(1.2f);
        waitNewStep = false;
    }
}
