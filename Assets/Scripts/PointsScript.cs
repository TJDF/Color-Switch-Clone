using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    [SerializeField] GameObject NextObstacleSpawnPoint;
    [SerializeField] GameObject ChangeColorSpawnPoint;


    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject changeColor;
    [SerializeField] GameObject preDefinedChangeColor;

    [SerializeField] int channgeColorSpawnChance;

    [SerializeField] bool preDefinedColor;
    public void SpawnNextObstacle()
    {
        int n = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[n], NextObstacleSpawnPoint.transform.position, transform.rotation);
    }

    private void Start()
    {
        ChangeColor();
    }


    public void ChangeColor()
    {
        if (!preDefinedColor)
        {
         int randomizer = Random.Range(0, 100);

         if(randomizer <= channgeColorSpawnChance) 
         {
            Instantiate(changeColor, ChangeColorSpawnPoint.transform.position, transform.rotation);
         }
         else
         {
            return;
         }
        }
        else
        {
            Instantiate(preDefinedChangeColor, ChangeColorSpawnPoint.transform.position, transform.rotation);
        }
    }
}
