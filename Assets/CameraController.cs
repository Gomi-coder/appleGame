using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //ī�޶� ���� ���
	public Transform target;

    //��ġ ������
     public Vector3 offset;

    void Update()
    {
        transform.position = target.position + offset;
    }
}