using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject boss;
    private Transform target;
    public Transform bossTrans;
    public GameObject BossBullet;
    public GameObject Police;
    public GameObject blood;

    public static BossShoot instance;

    public float generateTimer = 0f;
    public float generateCounter = 5f;
    public float healthTimer = 0f;
    public float healthCounter = 10f;

    Vector3 policePosition;


    public HealthBar healthbar;
    [SerializeField] private int Health = 100;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //boss.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(Health);
        generateTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;
        if (Vector2.Distance(bossTrans.position, CharacterMove.instance.transform.position) < 8)
        {
            //boss.SetActive(true);
            Debug.Log("boss");
            //bossTrans.transform.position += Vector3.right * Time.deltaTime; ;
            
            Instantiate(BossBullet, bossTrans.transform.position, bossTrans.transform.rotation);
            if (generateTimer > generateCounter)
            {
                generateTimer = 0;
                policePosition = Vector3.right + bossTrans.transform.position;
                Instantiate(Police, policePosition, bossTrans.transform.rotation);

            }

        }
        if (healthTimer > healthCounter)
        {
            healthTimer = 0;
            Health = 100;
        }
        
    }

   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullets")
        {
            HurtEnemy();
        }
        if (collision.tag == "PlayerBulletsEnhance")
        {
            HurtEnemyEnhance();
        }
    }

    public void HurtEnemy()
    {
        int hurt = Random.Range(0, 10);
        Health = Health - hurt;
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(blood, transform.position, transform.rotation);
            GameManager.instance.BossAddPoint();
        }
    }

    public void HurtEnemyEnhance()
    {
        Health -= 20;
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(blood, transform.position, transform.rotation);
            GameManager.instance.AddPoint();

            
        }
    }
}
