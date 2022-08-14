using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private bool _isUse;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null && !_isUse)
        {
            _isUse = true;
            GameManager.PlatformsPassed++;
        }
    }

    public void SetIsUse()
    {
        _isUse = false;
    }
}
