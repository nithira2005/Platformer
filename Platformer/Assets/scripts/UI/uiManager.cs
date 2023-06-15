using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{

   [SerializeField] private GameObject gameOverScreen;
   [SerializeField]private AudioClip gameOverSound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

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
    }
}
 
