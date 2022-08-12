using System.Collections.Generic;
using UnityEngine;

public class SectorsTexture : MonoBehaviour
{
    public Material GoodMaterial { get; set; }
    public Material BadMaterial { get; set; }

    private bool isFullMaterial;
    private void Start()
    {
        List<Sector> listSectors = new();
        foreach(Transform child in transform)
        {
            listSectors.Add(child.gameObject.GetComponent<Sector>());
        }

        SetRandBadSectors(listSectors);

    }
    void Update()
    {
        if (isFullMaterial) return;

        if (GoodMaterial != null && BadMaterial != null)
        {
            isFullMaterial = true;
            foreach (Transform child in transform)
            {
                MeshRenderer meshRend = child.GetComponent<MeshRenderer>();

                if (child.GetComponent<Sector>().IsGood)
                    meshRend.material = GoodMaterial;
                else
                    meshRend.material = BadMaterial;
            }
        }
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
