using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    static public bool IsPlaying;
    static public new Transform transform;

    [SerializeField] float Speed;

    private Vector3 _lastMousePosition;

    private void Start()
    {
        transform = GetComponent<Transform>();
        IsPlaying = true;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _lastMousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0) && IsPlaying)
        {
            Vector3 delta = (Input.mousePosition - _lastMousePosition) * Speed;
            transform.Rotate(0, -delta.x, 0);
        }
        _lastMousePosition = Input.mousePosition;
    }
    
    static public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
