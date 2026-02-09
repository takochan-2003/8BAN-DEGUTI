using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    // àŸïœÇÃêî
    public static int MAX_UNUSUAL = 7;
    public bool [] unusualType = new bool [MAX_UNUSUAL];

    // Start is called before the first frame update
    void Start()
    {
        unusualType[0] = true;
        unusualType[1] = true;
        unusualType[2] = true;
        unusualType[3] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetMaxUnusual()
    {
        return MAX_UNUSUAL;
    }
}
