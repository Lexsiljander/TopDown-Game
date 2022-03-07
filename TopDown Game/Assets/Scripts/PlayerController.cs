using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;

    public Animator animator;

    //The maximum number of health points the player can have
    [SerializeField]
    private int maxHealthPoints;
    //The current number of health points on the player after damage is applied
    public int currentHealthPoints;
    // Start is called before the first frame update

    //Bool that manages if the player can receive more damage

    public bool hit;

    public HealthBar healthBar;



    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;

    void Start()
    {
        currentHealthPoints = maxHealthPoints;

        healthBar.SetHealth(currentHealthPoints);

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Run"))
        {
            moveSpeed = 10f;
           
        }
        if (Input.GetButtonUp("Run"))
        {
            moveSpeed = 5f;
           
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Arena");

        }

        if (transform.position.y >= upperLimit)
        {
            transform.position = new Vector3(transform.position.x, upperLimit, 0);
        }
        else if (transform.position.y <= lowerLimit)
        {
            transform.position = new Vector3(transform.position.x, lowerLimit, 0);
        }

        if (transform.position.x >= rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, 0);
        }
        else if (transform.position.x <= leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, 0);
        }



    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //Player looks at cursor location
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


    }
    //This method is called by any script that would need to handle damage; for this tutorial it is called by the DamageField script
    public void Damage(int amount)
    {
        //First checks to see if the player is currently in an invulnerable state; if not it runs the following logic.
        if (!hit)
        {
            //First sets invulnerable to true
            hit = true;
            //Reduces currentHealthPoints by the amount value that was set by whatever script called this method, for this tutorial in the OnTriggerEnter2D() method
            currentHealthPoints -= amount;
            healthBar.SetHealth(currentHealthPoints);
            StartCoroutine(Recovery());
            //If currentHealthPoints is below zero, player is dead, and then we handle all the logic to manage the dead state
            if (currentHealthPoints <= 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Recovery()
    {


        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);

        GetComponent<SpriteRenderer>().color = Color.white;
        hit = false;
           
    }
   
}
