using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] UI ui;
    [SerializeField] new CameraFollow camera;

    public int SumPlatforms { get; set; } = 1;
    static public int PlatformsPassed { get; set; }

    static GameState _gameState;

    private bool _isEndGame;
    enum GameState
    {
        Playing,
        Won,
        Lose
    }
    private void Start()
    {
        _gameState = GameState.Playing;
        _isEndGame = false;
        Debug.Log(SumPlatforms);
        PlatformsPassed = 0;
    }

    private void Update()
    {
        if (_isEndGame || _gameState == GameState.Playing) return;

        _isEndGame = true;

        if (_gameState == GameState.Won)
            ui.OpenWonMenu();
        else if (_gameState == GameState.Lose)
            ui.OpenLoseMenu();
    }

    static public void Losing()
    {
        PlayerControls.IsPlaying = false;
        _gameState = GameState.Lose;
    }   
    static public void Winning()
    {
        PlayerControls.IsPlaying = false;
        _gameState = GameState.Won;

        int level = PlayerPrefs.GetInt("level", 1);
        PlayerPrefs.SetInt("level", level + 1);
    }

    public void Restart()
    {
        player.GetComponent<Player>().GoToFirstPosition();
        PlayerControls.transform.position = Vector3.zero;

        camera.ResetPosition();

        _isEndGame = false;
        _gameState = GameState.Playing;

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
