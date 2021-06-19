using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;

    //�ν����� â���� ���ǵ� ���� ������ �� �ְԲ� �Ϸ��� public���� �����ߴ�
    public float speed = 30;

    //vertical���� horizontal���� �ޱ� ���� �������� ����
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
        //GetAxisRaw():Axis���� ������ ��ȯ�ϴ� �Լ� (������ ���� 0/1...)
         hAxis = Input.GetAxisRaw("Horizontal");
         vAxis = Input.GetAxisRaw("Vertical");

        //normalized�� � �����̵� ������ ���� �̵��ϰԲ� �� ��
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        //LookAt()�� ������ ���͸� ���ؼ� ȸ�������ִ� �Լ�
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
