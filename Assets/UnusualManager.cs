using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UnusualManager : MonoBehaviour
{
    //àŸïœÇ©Ç«Ç§Ç©
    bool isUnusual;
    bool isUnusualCheck;
    //àŸïœÇÃí âﬂêî
    public int unusualCount;

    public int randomUnusualType;

    bool isClick;

    bool isUnusualStart;
    
    int randomUnusual;
    bool isRandom;

    public GameObject player;

    private ParameterManager parameterManager;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        isUnusual = false;
        isUnusualCheck = false;
        isUnusualStart = false;
        isRandom=false;
        randomUnusual = 0;
        randomUnusualType = 0;
        unusualCount = 0;
        isClick = false;
        playerMove = FindObjectOfType<PlayerMove>();
        parameterManager = FindObjectOfType<ParameterManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //ÉâÉìÉ_ÉÄê∂ê¨
        if (isUnusualStart == true)
        {
            if (player.transform.position.x <= -9&& player.transform.position.x >= -9.5|| player.transform.position.x >= 9&& player.transform.position.x <= 9.5)
            {
                if (isRandom == false)
                {
                    randomUnusualType = Random.Range(0, ParameterManager.MAX_UNUSUAL);
                    randomUnusual = Random.Range(0, 10);
                    isRandom = true;
                }
            }
        }
        //àŸïœÇÃîªíË
        if (player.transform.position.x <= -10 || player.transform.position.x >= 10)
        {
            if(randomUnusual <= 3)
            {
                //àŸïœÇî≠ê∂Ç≥ÇπÇÈ
                isUnusual = true;
            }
            else
            {
                //àŸïœÇî≠ê∂Ç≥ÇπÇ»Ç¢
                isUnusual = false;
            }

            if (isUnusual == true&&isUnusualCheck==false)
            {
                isUnusualCheck = true;
                
            }

        }

        if (player.transform.position.z >= 22.5)
        {
            switch(randomUnusualType)
            {
                case 0:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true && isUnusual == false)
                        {
                            unusualCount += 1;
                            isClick = true;
                            isUnusualStart = true;
                        }
                        if (playerMove.isRightClick == true && isUnusual == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                            isUnusualStart = true;
                        }
                    }
                    break;
                case 1:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true && isUnusual == false)
                        {
                            unusualCount = 0;
                            isClick = true;
                            isUnusualStart = true;
                        }
                        if (playerMove.isRightClick == true && isUnusual == true)
                        {
                            unusualCount += 1;
                            isClick = true;
                            isUnusualStart = true;
                        }
                    }
                    break;
                case 2:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true && isUnusual == false)
                        {
                            unusualCount = 0;
                            isClick = true;
                            isUnusualStart = true;
                        }
                        if (playerMove.isRightClick == true && isUnusual == true)
                        {
                            unusualCount += 1;
                            isClick = true;
                            isUnusualStart = true;
                        }
                    }
                    break;
                case 3:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true && isUnusual == false)
                        {
                            unusualCount = 0;
                            isClick = true;
                            isUnusualStart = true;
                        }
                        if (playerMove.isRightClick == true && isUnusual == true)
                        {
                            unusualCount += 1;
                            isClick = true;
                            isUnusualStart = true;
                        }
                    }
                    break;
            }

            
        }
        else
        {
            isClick = false;
            isRandom = false;
            isUnusualCheck = false;
        }
    }
}
