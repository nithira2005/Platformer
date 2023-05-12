
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private playermovement playermovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playermovement = GetComponent<playermovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playermovement.canAttack())
            Attack();

            cooldownTimer += Time.deltaTime;

    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
  

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<projectiles>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}

