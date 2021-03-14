using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject boss;
    private Transform target;
    public Transform bossTrans;
    public GameObject enemyBullets;
    // Start is called before the first frame update
    void Start()
    {
        //boss.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        awake();
    }

    void awake()
    {
        if (Vector2.Distance(bossTrans.position, target.position) < 10)
        {
            //boss.SetActive(true);
            Debug.Log("boss");
            Instantiate(enemyBullets, bossTrans.transform.position, bossTrans.transform.rotation);
        }
        else
        {
            //boss.SetActive(false);
        }
    }
}
