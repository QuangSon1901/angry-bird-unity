using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHP : MonoBehaviour
{
    public float resistance;
    public GameObject explosionPrefab;

    public Sprite normal;
    public Sprite littledmg;
    public Sprite middmg;
    public Sprite heavydmg;

    private AudioSource pigDestroy;
    private Animator anim;

    SpriteRenderer sp;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
        sp = GetComponent<SpriteRenderer>();
        pigDestroy = GameObject.Find("PigDestroy").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bird")
        {  
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
        if (resistance == 8)
        {
            //No dmg
            sp.sprite = normal;
        }
        else if (resistance >= 5 && resistance < 8)
        {
            //little dmg
        anim.enabled = false;
            sp.sprite = littledmg;
        }
        else if (resistance >= 2 && resistance < 5)
        {
            //mid dmg
        anim.enabled = false;
            sp.sprite = middmg;
        }
        else if (resistance > 0 && resistance < 2)
        {
            //heavely dmgd
        anim.enabled = false;
            sp.sprite = heavydmg;
        }
        else if (resistance <= 0)
        {
        anim.enabled = false;
            if (explosionPrefab != null) {
                var go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(go, 3);
            }

            

            Destroy(gameObject);
            int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        
            if (musicPlay == 1) {
            pigDestroy.Play();
            }
        }
    
    }
}
