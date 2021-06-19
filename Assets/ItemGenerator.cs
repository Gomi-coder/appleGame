using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject BamsongiPrefab;

    float span = 1.0f;
    float delta = 0;
    float speed = -0.03f;

    int ratio = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }


    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this.ratio)
            {
                item = Instantiate(BamsongiPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }

            float z = Random.Range(60, 670);
            float x = Random.Range(70, 1000);

            item.transform.position = new Vector3(x, 3, z);
            item.GetComponent<apple>().dropSpeed = this.speed;
            this.span = span - 1.0f;
        }
    }
}
