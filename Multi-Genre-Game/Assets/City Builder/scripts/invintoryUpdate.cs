using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invintoryUpdate : MonoBehaviour
{
    public static int treesDestroyed = 0;

    public GameObject txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<TextMesh>().text = treesDestroyed.ToString();
    }
}
