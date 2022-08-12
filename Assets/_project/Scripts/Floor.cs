using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public void SetFloor(GameObject prefFloor)
    {
        GameObject floor = Instantiate(prefFloor);

        floor.name = gameObject.name;

        floor.transform.localScale = Vector3.one;
        floor.transform.parent = transform.parent;
        floor.transform.localPosition = gameObject.transform.localPosition;
        Destroy(gameObject);
    }
}
