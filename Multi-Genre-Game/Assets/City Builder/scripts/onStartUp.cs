using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onStartUp : MonoBehaviour
{
    public GameObject myprefab;
    // Start is called before the first frame update
    void Start()
    {
        int screenHeight = 1;
        int screenWidth = 1;

        float startHeight = 4.5f;
        float startWidth = -9.5f;

        int[,] treeSpawn = new int[10,20];
        //randomly genereate where tree goes
        for (int i=0; i<10; i++)
        {
            for(int j=0; j < 20; j++)
            {
                treeSpawn[i, j] = Random.Range(1, 3);
            }
        }

      

        for (int i = 0; i < 10; i++)
        {
            startHeight -= screenHeight;
            startWidth = -9.5f;
            for (int j = 0; j < 20; j++)
            {
                if(treeSpawn[i, j] ==2)
                {
                    Instantiate(myprefab, new Vector3(startWidth, startHeight, 0), Quaternion.identity);


                   
                    startWidth += screenWidth;
                }
                else
                {
                    
                    startWidth += screenWidth;
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
