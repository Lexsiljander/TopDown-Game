using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyFollow : MonoBehaviour
{

    public float speed;
    //public Transform target;
   // public float minimunDistance;

    public GameObject projectile;
    public float timeBetweenShots;
        private float nextShotTime;

    [SerializeField]
    Transform player;

    public float stoppingDistance;
    public float retreatDistance;

    

    //public AIPath aiPath;
    // Start is called before the first frame update
    void Start()
    {
       
        //This makes sure that even prefabs can find the player
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }


        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }


        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
           
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }
}
