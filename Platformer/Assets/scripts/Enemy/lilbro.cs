using UnityEngine;

public class lilbro : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        //attackwhen player on range
        if (PlayerInsight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
            }
        }
    }
     private bool PlayerInsight()
     {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range, boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
     }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right*range, boxCollider.bounds.size);
    }
}
