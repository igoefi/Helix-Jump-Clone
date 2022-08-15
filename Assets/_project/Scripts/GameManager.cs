using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] UI ui;
    [SerializeField] new CameraFollow camera;

    public int SumPlatforms { get; set; } = 1;
    static public int PlatformsPassed { get; set; }

    static public GameStates GameState { get; private set; }

    private bool _isEndGame;
    public enum GameStates
    {
        Playing,
        Won,
        Lose
    }

    private void Start()
    {
        GameState = GameStates.Playing;
        _isEndGame = false;
        Debug.Log(SumPlatforms);
        PlatformsPassed = 0;
    }

    private void Update()
    {
        if (_isEndGame || GameState == GameStates.Playing) return;

        _isEndGame = true;

        if (GameState == GameStates.Won)
            ui.OpenWonMenu();
        else if (GameState == GameStates.Lose)
            ui.OpenLoseMenu();
    }

    static public void Losing()
    {
        PlayerControls.IsPlaying = false;
        GameState = GameStates.Lose;
    }   
    static public void Winning()
    {
        PlayerControls.IsPlaying = false;
        GameState = GameStates.Won;

        int level = PlayerPrefs.GetInt("level", 1);
        PlayerPrefs.SetInt("level", level + 1);
    }

    public void Restart()
    {
        player.GetComponent<Player>().GoToFirstPosition();
        PlayerControls.transform.position = Vector3.zero;

        camera.ResetPosition();

        _isEndGame = false;
        GameState = GameStates.Playing;

        PlayerControls.ResetRotation();

        PlatformsPassed = 0;
        DeUsePlatforms();

        PlayerControls.IsPlaying = true;

    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DeUsePlatforms()
    {
        foreach (Transform child in transform)
        {
            Platforms platform = child.GetComponent<Platforms>();
            if (platform != null)
            {
                platform.SetIsUse();
            }
        }
    }
}
