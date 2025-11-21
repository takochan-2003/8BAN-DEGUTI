using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    private FadeManager fadeManager;
    bool isClick = false;
    bool isLeftClick = false;
    bool isRightClick = false;
    Vector3 targetPosition = new Vector3(0.0f,0.0f,22.5f);
    Vector3 targetRightPosition = new Vector3(12.0f, 0.0f, 22.5f);
    Vector3 targetLeftPosition = new Vector3(-12.0f, 0.0f, 22.5f);
    public float walkSpeed = 2.0f;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        fadeManager = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 22.5f){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);
        }
        else
        {
            if (isClick == false)
            {
                if (isLeftClick == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        fadeManager.StartFadeOut();
                        isLeftClick = true;
                        isClick = true;
                    }
                }
            }
            if (isLeftClick == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetLeftPosition, walkSpeed * Time.deltaTime);
            }


            if (isClick == false)
            {
                if (isRightClick == false)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        fadeManager.StartFadeOut();
                        isRightClick = true;
                        isClick = true;
                    }
                }
            }
            if (isRightClick == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetRightPosition, walkSpeed * Time.deltaTime);
            }
            
        }
        
        if(transform.position == targetLeftPosition || transform.position == targetRightPosition)
        {
            isClick = false;
            isLeftClick = false;
            isRightClick = false;
            transform.position = new Vector3(0.0f, 0.0f, -20.0f);
            fadeManager.StartFadeIn();
        }

    }

}
