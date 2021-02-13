using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMove : MonoBehaviour
{

    private Vector2 move = new Vector2();

    [Range(1f, 8f)] [SerializeField] private float speedX = 4f;
    [Range(1f, 8f)] [Tooltip("Should be 1.4f")] [SerializeField] private float speedY = 4f;
    [Range(.1f, .3f)] [Tooltip("Increase slippery")] [SerializeField] private float smoothing = 0.1f;

    private Rigidbody2D rigid;
    private Vector3 zeroVelocity = Vector3.zero;

    public Transform aiming;

    public Animator anim;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>(); // read controller input

    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Movement()
    {
        Vector3 pos = new Vector3();
        pos.x = move.x * speedX;
        pos.y = move.y * speedY;
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, pos, ref zeroVelocity, smoothing);

    }

    // Update is called once per frame
    void Update()
    {
        rotateAiming();

        if(move != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    void rotateAiming()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            aiming.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale =  Vector3.one;
            aiming.localScale =  Vector3.one;
        }

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x,mousePos.y-screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        aiming.rotation = Quaternion.Euler(0,0,angle);
    }

    void FixedUpdate()
    {
        Movement();
    }
}
