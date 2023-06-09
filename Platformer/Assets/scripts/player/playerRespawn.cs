using UnityEngine;

public class playerRespawn : MonoBehaviour
{

    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private uiManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<uiManager>();
    }


    public void CheckRespawn()
    {
        if (currentCheckpoint == null)
        {
            //Show game overscreen
            uiManager.GameOver();
            return;
        }
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        //move the cam
        Camera.main.GetComponent<CameraController>().MovetoNewRoom(currentCheckpoint.parent); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            soundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }


}

