using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationSector : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
    }
}
