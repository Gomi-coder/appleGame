using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;

    //인스펙터 창에서 스피드 직접 설정할 수 있게끔 하려고 public으로 선언했다
    public float speed = 30;

    //vertical값과 horizontal값을 받기 위한 전역변수 설정
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
        //GetAxisRaw():Axis값을 정수로 반환하는 함수 (누르는 순간 0/1...)
         hAxis = Input.GetAxisRaw("Horizontal");
         vAxis = Input.GetAxisRaw("Vertical");

        //normalized는 어떤 방향이든 동일한 값을 이동하게끔 해 줌
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        //LookAt()은 지정된 벡터를 향해서 회전시켜주는 함수
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
