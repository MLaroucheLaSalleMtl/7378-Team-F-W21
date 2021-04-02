using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullets;
    public Transform shootingPoint;
    [SerializeField] private AudioSource audioShoot;

    public bool autoFire = false;
    public float mouseDown;
    public float shootRate;

    public static PlayerController instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();      
    }


    void Shooting()
    {     
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullets, shootingPoint.position, shootingPoint.rotation);
            mouseDown = shootRate;
            if (audioShoot) audioShoot.PlayOneShot(audioShoot.clip);
        }

        if (autoFire && Input.GetMouseButton(0))
        {
            mouseDown -= Time.deltaTime;
            if (mouseDown <= 0)
            {
                Instantiate(bullets, shootingPoint.position, shootingPoint.rotation);
                mouseDown = shootRate;
                if (audioShoot) audioShoot.PlayOneShot(audioShoot.clip);
            }        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullets")
        {
            PlayerHealth.instance.HurtPlayer(10);
        }
    }

    public void AutoFireShooting()
    {       
        autoFire = true;
    }
}
