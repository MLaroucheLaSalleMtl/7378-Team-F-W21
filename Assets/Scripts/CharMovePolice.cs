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

    public bool range;
    public GameObject enemyBullets;
    public Transform enemyShootPoint;
    public float shootCounter;
    public float shootRate;

    public float enemyShootRange;

    public static CharMovePolice instance;
    private void Awake()
    {
        instance = this;
    }
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

        if (range && Vector3.Distance(transform.position, CharacterMove.instance.transform.position) < enemyShootRange)
        {
            shootCounter -= Time.deltaTime;
            if (shootCounter <= 0)
            {
                shootCounter = shootRate;
                Instantiate(enemyBullets, enemyShootPoint.transform.position, enemyShootPoint.transform.rotation);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health -= 10;
        if (Health <= 0)
        {
            //anim.SetBool("enemyDeath", true);
            Point += 1;
            txtPoint.text = preTextPoint + Point.ToString("D2");

            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            PlayerHealth.instance.HurtPlayer();
        }
        //if(collision.tag=="PlayerBullets")
        //{
        //    Health -= 10;
        //    if (Health <= 0)
        //    {
        //        //anim.SetBool("enemyDeath", true);
        //        Point += 1;
        //        txtPoint.text = preTextPoint + Point.ToString("D2");

        //        Destroy(gameObject);
        //    }
        //}
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
    //public void HurtEnemy()
    //{
    //    Health -= 10;
    //    if (Health <= 0)
    //    {
    //        //anim.SetBool("enemyDeath", true);
    //        Point += 1;
    //        txtPoint.text = preTextPoint + Point.ToString("D2");
            
    //        Destroy(gameObject);
    //    }
    //    //else
    //    //{
    //    //    anim.SetBool("enemyDeath", false);
    //    //}
    //}
}
