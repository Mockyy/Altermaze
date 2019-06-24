using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool isOnfloor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.parent == null)
        {
            isOnfloor = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        else
        {
            isOnfloor = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Killing things
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }*/
}
