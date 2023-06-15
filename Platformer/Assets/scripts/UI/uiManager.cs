using UnityEngine;

public class uiManager : MonoBehaviour
{

   [SerializeField] private GameObject gameOverScreen;
   [SerializeField]private AudioClip gameOverSound;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        soundManager.instance.PlaySound(gameOverSound);
    }

}
 
