using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageToGive;

    public GameObject enviormentDmg;

    public GameObject effect;

    private void Start()
    {
        StartCoroutine(Despawn());
    }
   void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "Enemy")
        {
           
            //other.gameObject.GetComponent<Enemy>().HurtEnemy(damageToGive);
        }
        CheckForDestructibles();
        Instantiate(effect, transform.position, Quaternion.identity);
        GameObject a = Instantiate(enviormentDmg, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Explosion");
    }


    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void CheckForDestructibles()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);
        foreach(Collider2D c in colliders)
        {
            if(c.GetComponent<Enemy>())
            {
                c.GetComponent<Enemy>().HurtEnemy(damageToGive);
            }
        }

       
    }
    

}
