using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;

    public float speed = 30;

    float hAxis;
    float vAxis;

    Vector3 moveVec;

    public AudioClip appleSE;
    public AudioClip BamsongiSE;
    AudioSource aud;

    GameObject director;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update() 
    {
         hAxis = Input.GetAxisRaw("Horizontal");
         vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        transform.LookAt(transform.position + moveVec);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "apple")
        {
            this.director.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);
            Destroy(other.gameObject);
        }
        else
        {
            this.director.GetComponent<GameDirector>().GetBamsongi();
            this.aud.PlayOneShot(this.BamsongiSE);
            Destroy(other.gameObject);
        }
    }
}
