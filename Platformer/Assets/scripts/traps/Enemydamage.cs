using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    [SerializeField] protected private float damage;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        collision.GetComponent<Health>().TakeDamage(damage);
    }
}
