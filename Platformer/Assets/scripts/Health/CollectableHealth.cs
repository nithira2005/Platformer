using UnityEngine;

public class CollectableHealth : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip collectable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundManager.instance.PlaySound(collectable);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);

        }
    }
}
