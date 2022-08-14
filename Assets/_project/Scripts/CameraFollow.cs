using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 Difference;
    
    private float _bottomPositionY;

    private void Start()
    {
        ResetPosition();
    }

    private void Update()
    {
        if (_bottomPositionY > Player.position.y)
            _bottomPositionY = Player.position.y;

        transform.position = new Vector3(Difference.x, _bottomPositionY + Difference.y, Difference.z);
    }

    public void ResetPosition()
    {
        _bottomPositionY = Player.position.y;
    }
}
