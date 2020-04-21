using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsMov : MonoBehaviour
{
    // Variables
    public float velocity = 0;
    Vector3 startPosition;
    public float amplitud = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = startPosition + new Vector3(0, Mathf.Sin(Time.time * velocity * amplitud), 0);
    }
}
