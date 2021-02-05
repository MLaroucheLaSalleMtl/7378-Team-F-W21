using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMove : MonoBehaviour
{
    private Vector2 move = new Vector2();

    [Range(1f,8f)][SerializeField] private float speedX = 4f;
    [Range(1f,8f)][Tooltip("Should be 1.4f")][SerializeField] private float speedY = 4f;
    [Range(.1f, .3f)] [Tooltip("Increase slippery")] [SerializeField] private float smoothing = 0.1f;

    private Rigidbody2D rigid;
    private Vector3 zeroVelocity = Vector3.zero;
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
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, pos,ref zeroVelocity,smoothing);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movement();    
    }
}
