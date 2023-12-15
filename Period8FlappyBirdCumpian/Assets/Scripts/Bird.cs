using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce = 200f;

    bool isDead = false;
    Rigidbody2D rb2d;
    Animator anim;
    public AudioClip Fly;
    public AudioClip Dead;
    public AudioClip scoreSound;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                SoundManager.instance.PlaySound(Fly);
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero; 
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.Instance.BirdDied();
        SoundManager.instance.PlaySound(Dead);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SoundManager.instance.PlaySound(scoreSound);
    }
}
