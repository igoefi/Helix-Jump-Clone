using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject BG;
    [SerializeField] GameObject WonMenu;
    [SerializeField] GameObject LoseMenu;

    [SerializeField] GameManager gameManager;

    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text PlatformText;
    [SerializeField] Image PassedPlatformImage;

    private GameObject _openMenu;


    private void Start()
    {
        if(levelText != null)
            levelText.text = "Level: " + PlayerPrefs.GetInt("level");
    }

    private void Update()
    {
        if(PlatformText != null)
            PlatformText.text = GameManager.PlatformsPassed.ToString();

        if (PassedPlatformImage != null)
        {
            float value = (float)GameManager.PlatformsPassed / gameManager.SumPlatforms;
            PassedPlatformImage.fillAmount = value;
        }
    }

    public void OpenLoseMenu()
    {
        OpenMenu(LoseMenu);
    }

    public void OpenWonMenu()
    {
        OpenMenu(WonMenu);
    }

    public void OpenMenu(GameObject menu)
    {
        BG.SetActive(true);
        menu.SetActive(true);

        _openMenu = menu;
    }

    public void CloseMenu()
    {
        BG.SetActive(false);
        _openMenu.SetActive(false);
    }

    public void Restart()
    {
        gameManager.Restart();
        CloseMenu();
    }
    public void GoToNextLevel()
    {
        gameManager.Nextlevel();
    }

}
