using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header("patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform RightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement perameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void MoveInDirection(int _direction)
    {
        //face right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        //moving direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
