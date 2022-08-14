using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationSector : MonoBehaviour
{
    void Start()
    {
        System.Random rand = new();
        transform.Rotate(new Vector3(0, rand.Next(0, 360), 0));
        Destroy(GetComponent<RandomRotationSector>());
    }
}
