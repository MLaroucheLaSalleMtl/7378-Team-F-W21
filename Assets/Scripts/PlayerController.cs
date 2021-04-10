using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullets;
    public GameObject EnhanceBullets;
    public Transform shootingPoint;
    [SerializeField] private AudioSource audioShoot;
    [SerializeField] private AudioSource audioShootWp2;
    public bool autoFire = false;
    public bool WeaponEnhance = false;
    public bool pause = false;

    public float mouseDown;
    public float shootRate;

    public static PlayerController instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
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
            if(pause != true)
            {
                if (WeaponEnhance == true)
                {
                    Instantiate(EnhanceBullets, shootingPoint.position, shootingPoint.rotation);
                    Debug.Log("enhance");
                    mouseDown = shootRate;
                    if (audioShoot) audioShoot.PlayOneShot(audioShoot.clip);
                    if (audioShootWp2) audioShootWp2.PlayOneShot(audioShootWp2.clip);
                }
                else
                {
                    Instantiate(bullets, shootingPoint.position, shootingPoint.rotation);
                    mouseDown = shootRate;
                    if (audioShoot) audioShoot.PlayOneShot(audioShoot.clip);
                }
            }
           
                

           
        }

        if (autoFire && Input.GetMouseButton(0))
        {
            mouseDown -= Time.deltaTime;
            if (mouseDown <= 0)
            {
                if (WeaponEnhance == true)
                {
                    Instantiate(EnhanceBullets, shootingPoint.position, shootingPoint.rotation);
                    Debug.Log("enhance");
                    mouseDown = shootRate;
                    if (audioShootWp2) audioShootWp2.PlayOneShot(audioShootWp2.clip);
                }
                else
                {
                    Instantiate(bullets, shootingPoint.position, shootingPoint.rotation);
                    mouseDown = shootRate;
                    if (audioShoot) audioShoot.PlayOneShot(audioShoot.clip);
                }
   
                
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
