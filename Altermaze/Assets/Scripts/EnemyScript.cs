using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Instance de décès
    public GameObject explosionEffect;
    GameObject clone;

    //Stats
    public float maxHealth;
    float currentHealth;
    public int speed;
    public float damage;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(explosionEffect, gameObject.transform);
            //Destroy(clone, 0.2f);
            Destroy(gameObject, 0.2f);
        }
    }
}
