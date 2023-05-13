using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MovetoNewRoom(nextRoom);
            else
                cam.MovetoNewRoom(previousRoom);
        }
    }
}
