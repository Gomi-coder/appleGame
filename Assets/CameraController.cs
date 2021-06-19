using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //카메라가 따라갈 대상
	public Transform target;

    //위치 오프셋
     public Vector3 offset;

    void Update()
    {
        transform.position = target.position + offset;
    }
}