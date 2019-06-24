using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour1 : MonoBehaviour
{
    public GameObject objectFollowed;

    private Rigidbody2D myRigidBody;

    public float moveSpeed;
    private Vector2 mi;

    private Vector2 moveDirection;

    public GameObject deathEffect;
    private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectFollowed.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Weapon") && (collision.gameObject.transform.parent != null))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(deathEffect, gameObject.transform);
            Destroy(gameObject, 0.2f);
            //Destroy(clone, 0.2f);
        }
    }
}
