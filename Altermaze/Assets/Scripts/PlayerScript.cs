using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    //Movement
    public float speed;
    private Rigidbody2D rb;
    private Vector2 mv;
    float facing;

    //Weapon
    public GameObject weapon;
    GameObject weaponClone;
    Transform posWeapon;
    public WeaponScript isWeaponOnFloor;

    //HealthBar
    float maxHealth = 10;
    float currentHealth;
    GameObject healthBar;

    void Start()
    {
        //Get rigidBody component
        rb = GetComponent<Rigidbody2D>();

        posWeapon = gameObject.transform.GetChild(0).GetComponent<Transform>();

        healthBar = GameObject.Find("HealthBar");
        currentHealth = maxHealth;

    }

    void Update()
    {
        //Get input and apply speed
        Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mv = mi.normalized * speed;

        float angle = Mathf.Atan2(mv.y, mv.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);

        //rb.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mi.y, mi.x));
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, facing);
    }

    private void FixedUpdate()
    {
        //Move player
        rb.MovePosition(rb.position + mv * Time.fixedDeltaTime);
        //rb.velocity = mv;

        //Rotate player (4 directions)
        if (mv.x > 0)
        {
            facing = 180;
        }
        else if (mv.x < 0)
        {
            facing = 0;
        }
        if (mv.y > 0)
        {
            facing = -90;
        }
        else if (mv.y < 0)
        {
            facing = 90;
        }

        //--Lacher l'arme--//
        if (weapon != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                weapon.transform.parent = null;
            }
        }

        //healthBar.transform.localScale = new Vector3(currentHealth, 1);
    }

    //--Taking damage--//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            print("Touché (coulé lol)");
            //currentHealth -= collision.gameObject.GetComponent<EnemyScript>().damage;
        }
    }

    //--Picking up weapons--//
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Weapon") && (Input.GetKeyDown(KeyCode.E)))
        {
            //Destroy(weapon);  //Detruit l'arme actuelle (irrécupérable) 
            weapon.transform.parent = null; //Rend l'arme actuelle orpheline (elle reste au sol)
            weapon = collision.gameObject;  //La nouvelle arme est celle que l'on vient de ramasser
            weapon.transform.parent = posWeapon; //La nouvelle arme devient enfant du player
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.Euler(0, 0, -facing);
        }
    }
}