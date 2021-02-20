using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMovePolice : MonoBehaviour
{
    public float speed;
    public float awayfrom;
    private Transform target;

    [SerializeField] private int Health = 100;
    public HealthBar healthbar;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(Health);
        if (Vector2.Distance(transform.position, target.position) > awayfrom)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Health <= 0)
        {
            Destroy(GameObject.Find("Police"));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health -= 10;
        Debug.Log(Health);
        
 



    }

    public void checksur()
    {

    }
}
