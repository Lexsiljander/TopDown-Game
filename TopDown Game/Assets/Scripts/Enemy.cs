using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    //The amount of damage that needs to be negated from the player's currentHealth value
    [SerializeField]
    private int damageAmount;
    //The collider of whatever gameObject has this script on it
    private Collider2D col;

    public int currentHealth;
    public int maxHealth;

    public int scoreValue = 1;

   

    //I use OnEnable to set these variables so if you want to use this script on a melee weapon or projectile gameObject, you can still ensure the variables are correct when those items are enabled during their use
    private void OnEnable()
    {
        //A reference to the collider of whatever gameObject would apply damage; for the sake of the tutorial, this is on the red square, but in most games this script would be on a projectile that is fired or a melee weapon as the hitboxes are active.
        col = GetComponent<Collider2D>();
        //A quick line that ensures whatever gameObject has this script also has it's collider set to trigger so the logic that causes damage can flow if you forget to set it as a trigger collider in the inspector
        col.isTrigger = true;
    }

    //This method is called when this object enters the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        //Quick reference to the player so the game is better optimized
        GameObject player = GameObject.FindWithTag("Player");
        //Quick reference to the Health script on the player for optimization
        PlayerController health = player.GetComponent<PlayerController>();
        //Checks to see if this gameObject is in fact colliding with the player
        if (collision.gameObject == player)
        {
           
            //This method negates the player's health by the damage amount; we set the damage amount through this script in the inspector
            health.Damage(damageAmount);
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

       
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < 0)
        {
            ScoreManager.instance.ChangeScore(scoreValue);
            Destroy(gameObject);

          
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }
   
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
