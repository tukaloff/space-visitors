using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDisplacement : MonoBehaviour
{
    public GameObject objectToDisplacement;
    public int countObjects;
    public float circleRadius;
    public Vector2 circleCenter = new Vector2(0, 0);

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = 360f / countObjects;
        var objectPosition = new Vector3();
        objectPosition.z = objectToDisplacement.transform.position.z;
        for (int i = 0; i < countObjects; i++)
        {
            objectPosition.x = circleCenter.x + circleRadius * Mathf.Sin(angle * i * Mathf.Deg2Rad);
            objectPosition.y = circleCenter.y + circleRadius * Mathf.Cos(angle * i * Mathf.Deg2Rad);
            Instantiate(objectToDisplacement, objectPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
