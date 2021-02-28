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
    [SerializeField] private int Point = 0;
    [SerializeField] private Text txtPoint;
    private const string preTextPoint = "Point: ";
    



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        txtPoint.text = preTextPoint + Point.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(Health);
        if (Vector2.Distance(transform.position, target.position) > awayfrom)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetBool("enemyMove",true);
        }
        else
        {
            anim.SetBool("enemyMove", false);
        }
        enemyRotateAiming();
        if (Health <= 0)
        {
            Destroy(GameObject.Find("Police"));
            Point += 1;
            txtPoint.text = preTextPoint + Point.ToString("D2");
            Debug.Log(Point);
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

    void enemyRotateAiming()
    {
        Vector3 playerPos = target.transform.localPosition;
        Vector3 enemyPos = transform.localPosition;
        if(playerPos.x<enemyPos.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale =  Vector3.one;
        }
    }
}
