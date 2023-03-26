using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingForCircle : MonoBehaviour
{
    public float radius = 7f;
    public GameObject prefab;
    public GameObject sphere;
    public float moveSpeed;

    private float angleBetweenObjects;
    private float currentAngle = 0f;
    private Vector3 center;

    void Start()
    {
        Circumference();
    }

    void Circumference()
    {
        float circumference = 2 * Mathf.PI * radius;
        angleBetweenObjects = 360f / 10;

        for (int i = 0; i < 10; i++)
        {
            float angle = i * angleBetweenObjects;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            Vector3 spawnPosition = new Vector3(x, y, 0f) + transform.position;

            GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity);
            obj.transform.position = spawnPosition - transform.position;

            transform.position = spawnPosition;
            transform.forward = spawnPosition - transform.position;

            Debug.Log("The circumference of the circle is: " + circumference);

            if(i == 9)
            {
                center = transform.position;
                GameObject obj2 = Instantiate(sphere, center, Quaternion.identity);
                Debug.Log("The center of the circle is: " + center);
            }

            currentAngle += moveSpeed * Time.deltaTime;

            if (currentAngle > 360f)
            {
                currentAngle -= 360f;
            }
        }
    }
}

