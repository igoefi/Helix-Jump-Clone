using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Material _goodMaterial; 
    private Material _badMaterial;
    public void SetFloor(GameObject prefFloor)
    {
        GameObject floor = Instantiate(prefFloor);

        floor.name = gameObject.name;

        floor.transform.localScale = Vector3.one;
        floor.transform.parent = transform.parent;
        floor.transform.localPosition = gameObject.transform.localPosition;

        floor.GetComponent<SectorsTexture>().SetMaterials(_goodMaterial, _badMaterial);
        Destroy(gameObject);
    }
    public void SetMaterial(Material goodMaterial, Material badMaterial)
    {
        _goodMaterial = goodMaterial;
        _badMaterial = badMaterial;
    }
}
