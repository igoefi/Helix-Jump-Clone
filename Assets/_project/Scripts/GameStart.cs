using System;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] Material[] goodMaterials;
    [SerializeField] Material[] badMaterials;
    [SerializeField] Material[] cylinderMaterials;
    [SerializeField] Material[] playerMaterials;

    [SerializeField] GameObject[] FloorPrefs;

    private Material _goodMaterial;
    private Material _badMaterial;
    private Material _cylinderMaterial;
    private Material _playerMaterial;

    void Start()
    {
        int level = PlayerPrefs.GetInt("level", 1);

        _goodMaterial = goodMaterials[goodMaterials.Length % level];
        _badMaterial = badMaterials[badMaterials.Length % level];
        _cylinderMaterial = cylinderMaterials[cylinderMaterials.Length % level];
        _playerMaterial = playerMaterials[playerMaterials.Length % level];

        CreateLevel();

        SetMaterials();
    }

    private void Update()
    {
        SetFloorMaterials();
    }

    private void CreateLevel()
    {

        foreach (Transform child in transform)
        {
            Floor floor = child.gameObject.GetComponent<Floor>();
            if (floor != null)
            {
                System.Random rand = new();
                int randFloorIndex = rand.Next(0, FloorPrefs.Length);

                floor.SetFloor(FloorPrefs[randFloorIndex]);
            }
        }

    }


    private void SetMaterials()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Floor>() != null || child.GetComponent<SectorsTexture>() != null) return;

            if (child.GetComponent<Player>() != null)
            {
                SetMaterialInMesh(child.gameObject, _playerMaterial);
            }
            else if (child.GetComponent<FinishPlatform>() != null)
            {
                SetMaterialInMesh(child.gameObject, _goodMaterial);
            }
            else
            {
                //цилиндр
                SetMaterialInMesh(child.gameObject, _cylinderMaterial);
            }
        }
    }

    private void SetFloorMaterials()
    {
        foreach (Transform child in transform)
        {
            SectorsTexture floor = child.GetComponent<SectorsTexture>();
            if (floor != null)
            {
                floor.BadMaterial = _badMaterial;
                floor.GoodMaterial = _goodMaterial;
            }
        }
    }

    private void SetMaterialInMesh(GameObject Object, Material material)
    {
        Object.GetComponent<MeshRenderer>().material = material;
    }
}
