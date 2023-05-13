using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MovetoNewRoom(nextRoom);
            else
                cam.MovetoNewRoom(previousRoom);
        }
    }
   private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }
}
