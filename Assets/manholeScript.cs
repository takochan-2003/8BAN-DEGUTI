using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manholeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.0002f, 0, 0.0002f);
    }
}
