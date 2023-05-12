
using UnityEngine;

public class projectiles : MonoBehaviour
{
    [SerializeField] private float speed;
    public float direction;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;
    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movemntSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movemntSpeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
   
    }
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

   
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);

    }





}