using System.Collections.Generic;
using UnityEngine;

public class SectorsTexture : MonoBehaviour
{
    private Material _goodMaterial;
    private Material _badMaterial;

    private bool isFullMaterial;

    [SerializeField] bool IsFirst = false;
    private void Start()
    {
        List<Sector> listSectors = new();
        foreach(Transform child in transform)
        {
            listSectors.Add(child.gameObject.GetComponent<Sector>());
        }

        if(!IsFirst)
            SetRandBadSectors(listSectors);

    }
    void Update()
    {
        if (isFullMaterial) Destroy(GetComponent<SectorsTexture>());

        if (_goodMaterial != null && _badMaterial != null)
        {
            isFullMaterial = true;
            foreach (Transform child in transform)
            {
                MeshRenderer meshRend = child.GetComponent<MeshRenderer>();

                if (child.GetComponent<Sector>().IsGood)
                    meshRend.material = _goodMaterial;
                else
                    meshRend.material = _badMaterial;
            }
        }
    }

    public void SetMaterials(Material goodMaterial, Material badMaterial)
    {
        _goodMaterial = goodMaterial;
        _badMaterial = badMaterial;
    }

    private void SetRandBadSectors(List<Sector> list)
    {
        int indexBadSector1 = Random.Range(0, list.Count);
        int indexBadSector2 = Random.Range(0, list.Count);

        if(indexBadSector2 == indexBadSector1)
        {
            if(indexBadSector2 == list.Count - 1)
            {
                indexBadSector2 = 0;
            }
            else
            {
                indexBadSector2++;
            }
        }

        list[indexBadSector1].IsGood = false;
        list[indexBadSector2].IsGood = false;
    }
}
