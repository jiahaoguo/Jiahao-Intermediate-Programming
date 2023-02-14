
using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent nav;
    float moveTimer = 0;
    float moveTimerTotal = 1;

    public int attack;
    public float moveSpeed;
    public float health;
    float totalHealth;

    [SerializeField]
    Animator anim;
    [SerializeField]
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("enemyTarget").transform;
        totalHealth = health;

    }

    // Update is called once per frame
    void Update()
    {

        nav.SetDestination(target.position);
        nav.speed = moveSpeed;

        if (health <= 0)
        {
            target.gameObject.GetComponent<Health>().enemyNum += 1;
            Destroy(this.gameObject);
        }

        if(health < totalHealth * 3/5)
        {
            if (anim != null) {
                anim.SetTrigger("Hurt");
                Debug.Log("hurt");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == target.GetComponent<Collider>())
        {
            target.gameObject.GetComponent<Health>().currentHealth -= attack;
            
            Destroy(this.gameObject);
        }
    }
}
