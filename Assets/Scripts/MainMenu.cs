using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //UI Elements
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        optionsButton.onClick.AddListener(OpenOptions);
        quitButton.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    void OpenOptions()
    {
       // Open Options menu (Not implemented yet)
       Debug.Log("Options menu not implemented");
    }
    
    //Quit
    void QuitGame()
    {
        Application.Quit();
    }

}