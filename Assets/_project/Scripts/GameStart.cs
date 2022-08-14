using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] Material[] GoodMaterials;
    [SerializeField] Material[] BadMaterials;
    [SerializeField] Material[] CylinderMaterials;
    [SerializeField] Material[] PlayerMaterials;

    [SerializeField] GameObject[] FloorPrefs;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Cylinder;
    [SerializeField] GameObject Finish;

    [SerializeField] SectorsTexture FirstSectors;

    private Material _goodMaterial;
    private Material _badMaterial;
    private Material _cylinderMaterial;
    private Material _playerMaterial;

    private int _sumPlatforms;

    void Start()
    {
        int level = PlayerPrefs.GetInt("level", 1);

        _goodMaterial = GoodMaterials[level % GoodMaterials.Length];
        _badMaterial = BadMaterials[level % BadMaterials.Length];
        _cylinderMaterial = CylinderMaterials[level % CylinderMaterials.Length];
        _playerMaterial = PlayerMaterials[level % PlayerMaterials.Length];

        CreateLevel();

        SetMaterials();

        Destroy(gameObject.GetComponent<GameStart>());
    }

    private void CreateLevel()
    {

        foreach (Transform child in transform)
        {
            Floor floor = child.gameObject.GetComponent<Floor>();
            if (floor != null)
            {
                _sumPlatforms++;

                System.Random rand = new();
                int randFloorIndex = rand.Next(0, FloorPrefs.Length);

                floor.SetMaterial(_goodMaterial, _badMaterial);
                floor.SetFloor(FloorPrefs[randFloorIndex]);

            }
        }

        GetComponent<GameManager>().SumPlatforms += _sumPlatforms;
    }


    private void SetMaterials()
    {
        FirstSectors.SetMaterials(_goodMaterial, _badMaterial);
        SetMaterialInMesh(Player, _playerMaterial);
        SetMaterialInMesh(Finish, _goodMaterial);
        SetMaterialInMesh(Cylinder, _cylinderMaterial);
    }

    private void SetMaterialInMesh(GameObject Object, Material material)
    {
        if (Object != null)
            Object.GetComponent<MeshRenderer>().material = material;
    }
}
