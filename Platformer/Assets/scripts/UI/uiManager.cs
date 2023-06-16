using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    [Header("Game over")]
   [SerializeField] private GameObject gameOverScreen;
   [SerializeField]private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }
    #region gameover
    //game overscreen activation
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        soundManager.instance.PlaySound(gameOverSound);
    }
   
    //game over functions
     public void Restart()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();

      #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
      #endif
    }
    #endregion


    #region
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    #endregion
}

