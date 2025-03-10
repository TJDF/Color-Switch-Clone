using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    [SerializeField]  float rotationSpeed;
    [SerializeField] bool randomizeSpinDirection;

    private void Start()
    {
        if (randomizeSpinDirection)
        {
            SpinDirectionRandomizer();
        }

        m = 1;
    }

    int m;
    void SpinDirectionRandomizer()
    {
        int n = Random.Range(0, 2);

        if (n == 1)
        {
            m = 1;
        }
        else
        {
            m = -1;
        }
    }

    private void Update()
    {
        Spin();
    }


    void Spin()
    {
        this.transform.Rotate(new Vector3(0, 0, rotationSpeed * m) * 1 * Time.deltaTime);
    }
}
