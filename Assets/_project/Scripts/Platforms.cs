using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private AudioSource _audioSourse;

    private bool _isUse;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null && !_isUse)
        {
            _isUse = true;
            GameManager.PlatformsPassed++;
            if (_audioSourse != null)
            {
                _audioSourse.volume = Random.Range(0.5f, 1);
                _audioSourse.Play();
            }
        }
    }

    public void SetIsUse()
    {
        _isUse = false;
    }
}
