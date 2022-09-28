using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructables : MonoBehaviour
{
    public float resistance;
    public GameObject explosionPrefab;

    public Sprite normal;
    public Sprite littledmg;
    public Sprite middmg;
    public Sprite heavydmg;

    private AudioSource woodDamage;
    private AudioSource woodDestroy;

    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        woodDamage = GameObject.Find("WoodDamage").GetComponent<AudioSource>();
        woodDestroy = GameObject.Find("WoodDestroy").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bird")
        {  
            int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        
            if (musicPlay == 1) {
            woodDamage.Play();
            }

            if (col.relativeVelocity.magnitude >= 0.2f)
                resistance -= col.relativeVelocity.magnitude;
        }
        if (col.gameObject.tag == "Block")
        {
            if (col.relativeVelocity.magnitude >= 0.2f)
                resistance -= col.relativeVelocity.magnitude;

        }
        if (col.gameObject.tag == "Ground")
        {
            if (col.relativeVelocity.magnitude >= 0.2f)
                resistance -= col.relativeVelocity.magnitude;

        }

    }

    void Update()
    {
        if (resistance == 10)
        {
            //No dmg
            sp.sprite = normal;
        }
        else if (resistance >= 6 && resistance < 10)
        {
            //little dmg
            sp.sprite = littledmg;
        }
        else if (resistance >= 3 && resistance < 6)
        {
            //mid dmg
            sp.sprite = middmg;
        }
        else if (resistance > 0 && resistance < 3)
        {
            //heavely dmgd
            sp.sprite = heavydmg;
        }
        else if (resistance <= 0)
        {
            if (explosionPrefab != null) {
                var go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(go, 3);
            }

            

            Destroy(gameObject);

            int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        
            if (musicPlay == 1) {
            woodDestroy.Play();
            }
        }
    
    }
}
