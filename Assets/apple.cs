using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    //열거형 enum사용
    public enum Type { apple, Bamsongi};
    public Type type;
    public int value;

    public float dropSpeed = -0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        transform.Translate(0, this.dropSpeed, 0);
    }
}