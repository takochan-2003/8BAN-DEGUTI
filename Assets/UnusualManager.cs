using System.Collections;
using System.Collections.Generic;
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

    public bool isClick;

    bool isUnusualStart;
    
    public int randomUnusual;
    bool isRandom;

    bool isStreet1Spawn;
    bool isStreet2Spawn;
    bool isStreet3Spawn;
    bool isStreet4Spawn;
    bool isStreet5Spawn;
    bool isStreet6Spawn;
    bool isStreet7Spawn;
    bool isStreet8Spawn;
    bool isStreet99Spawn;

    public GameObject player;

    public GameObject utilityPole;
    public GameObject post;
    public GameObject cone;
    public GameObject street1;
    public GameObject street2;
    public GameObject street3;
    public GameObject street4;
    public GameObject street5;
    public GameObject street6;
    public GameObject street7;
    public GameObject street8;
    public GameObject street99;
    public GameObject stop;

    GameObject firstStreetSpawn;
    GameObject[] streetSpawns = new GameObject[8];
    GameObject[] street99Spawns = new GameObject[13];
    GameObject unusualPost;
    GameObject unusualStop;

    private ParameterManager parameterManager;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        isStreet1Spawn = true;
        isStreet2Spawn = false;
        isStreet3Spawn = false;
        isStreet4Spawn = false;
        isStreet5Spawn = false;
        isStreet6Spawn = false;
        isStreet7Spawn = false;
        isStreet8Spawn = false;
        isStreet99Spawn = false;
        player = GameObject.Find("Player");
        isUnusual = false;
        isUnusualCheck = false;
        isUnusualStart = false;
        isRandom=false;
        randomUnusual = 0;
        randomUnusualType = 0;
        unusualCount = 0;
        isClick = false;
        for(int i=0;i<8;i++)
        {
            streetSpawns[i] = null;
        }
        for (int i = 0; i < 13; i++)
        {
            street99Spawns[i] = null;
        }
        unusualPost = null;
        unusualStop = null;
        playerMove = FindObjectOfType<PlayerMove>();
        parameterManager = FindObjectOfType<ParameterManager>();
        Instantiate(utilityPole, new Vector3(0, 5, 25.5f), Quaternion.Euler(0, 90, 0));
        Instantiate(post, new Vector3(3.7f,-0.8f, 13), Quaternion.Euler(0, 90, 0));
        Instantiate(cone, new Vector3(1.4f, -0.6f, 25.6f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(1.4f, -0.45f, 25.6f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(-3.5f, -0.6f, -1), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(-3.5f, -0.6f, 3.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(-1.5f, -0.6f, 1.25f), Quaternion.Euler(0, 0, 0));
        firstStreetSpawn=Instantiate(street1, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //ÉâÉìÉ_ÉÄê∂ê¨
        if (isUnusualStart == true)
        {
            if (player.transform.position.x <= -10&& player.transform.position.x >= -11|| player.transform.position.x >= 10&& player.transform.position.x <= 11)
            {
                if (isRandom == false)
                {
                    if (unusualCount == 0)
                    {
                        
                        isStreet2Spawn = false;
                        isStreet3Spawn = false;
                        isStreet4Spawn = false;
                        isStreet5Spawn = false;
                        isStreet6Spawn = false;
                        isStreet7Spawn = false;
                        isStreet8Spawn = false;
                        isStreet99Spawn = false;
                        Destroy(firstStreetSpawn);
                        Destroy(streetSpawns[1]);
                        Destroy(streetSpawns[2]);
                        Destroy(streetSpawns[3]);
                        Destroy(streetSpawns[4]);
                        Destroy(streetSpawns[5]);
                        Destroy(streetSpawns[6]);
                        Destroy(streetSpawns[7]);
                        if (isStreet1Spawn == false)
                        {
                            streetSpawns[0]= Instantiate(street1, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
                            isStreet1Spawn = true;
                        }
                    }
                    if (unusualCount == 1)
                    {
                        
                        isStreet1Spawn = false;
                        isStreet3Spawn = false;
                        isStreet4Spawn = false;
                        isStreet5Spawn = false;
                        isStreet6Spawn = false;
                        isStreet7Spawn = false;
                        isStreet8Spawn = false;
                        isStreet99Spawn = false;
                        Destroy(firstStreetSpawn);
                        Destroy(streetSpawns[0]);
                        Destroy(streetSpawns[2]);
                        Destroy(streetSpawns[3]);
                        Destroy(streetSpawns[4]);
                        Destroy(streetSpawns[5]);
                        Destroy(streetSpawns[6]);
                        Destroy(streetSpawns[7]);
                        if (isStreet2Spawn == false)
                        {
                            streetSpawns[1]=Instantiate(street2, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
                            isStreet2Spawn = true;
                        }
                    }
                    if (unusualCount == 2)
                    {
                        
                        isStreet1Spawn = false;
                        isStreet2Spawn = false;
                        isStreet4Spawn = false;
                        isStreet5Spawn = false;
                        isStreet6Spawn = false;
                        isStreet7Spawn = false;
                        isStreet8Spawn = false;
                        isStreet99Spawn = false;
                        Destroy(firstStreetSpawn);
                        Destroy(streetSpawns[0]);
                        Destroy(streetSpawns[1]);
                        Destroy(streetSpawns[3]);
                        Destroy(streetSpawns[4]);
                        Destroy(streetSpawns[5]);
                        Destroy(streetSpawns[6]);
                        Destroy(streetSpawns[7]);
                        if (isStreet3Spawn == false)
                        {
                            streetSpawns[2] = Instantiate(street3, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
                            isStreet3Spawn = true;
                        }
                    }
                    if (unusualCount == 3)
                    {
                        
                        isStreet1Spawn = false;
                        isStreet2Spawn = false;
                        isStreet3Spawn = false;
                        isStreet5Spawn = false;
                        isStreet6Spawn = false;
                        isStreet7Spawn = false;
                        isStreet8Spawn = false;
                        isStreet99Spawn = false;
                        Destroy(firstStreetSpawn);
                        Destroy(streetSpawns[0]);
                        Destroy(streetSpawns[1]);
                        Destroy(streetSpawns[2]);
                        Destroy(streetSpawns[4]);
                        Destroy(streetSpawns[5]);
                        Destroy(streetSpawns[6]);
                        Destroy(streetSpawns[7]);
                        if (isStreet4Spawn == false)
                        {
                            streetSpawns[3]=Instantiate(street4, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
                            isStreet4Spawn = true;
                        }
                    }
                    randomUnusual = Random.Range(0, 10);
                    isRandom = true;
                }
            }
        }
        //àŸïœÇÃîªíË
        //8äÑÇÃämó¶Ç≈àŸïœÇî≠ê∂
        //2äÑÇÃämó¶Ç≈àŸïœÇî≠ê∂Ç≥ÇπÇ»Ç¢
        if (player.transform.position.x <= -11.5 || player.transform.position.x >= 11.5)
        {
            if(randomUnusual >= 2 && isUnusualCheck == false)
            {
                //àŸïœÇî≠ê∂Ç≥ÇπÇÈ
                isUnusual = true;
                randomUnusualType = Random.Range(1, ParameterManager.MAX_UNUSUAL);
                isUnusualCheck = true;

                //àŸïœ1
                if(randomUnusualType == 1)
                {

                    if(unusualStop == null)
                    {
                        unusualStop = Instantiate(stop, new Vector3(0f, -0.95f, 17.5f), Quaternion.Euler(0, 180, 0));
                    }

                    if (street99Spawns[0] != null)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            Destroy(street99Spawns[i]);
                        }
                    }

                    if (unusualPost != null)
                    {
                        Destroy(unusualPost);
                    }
                }

                //àŸïœ2
                if (randomUnusualType == 2)
                {
                    if (street99Spawns[0] == null)
                    {
                        street99Spawns[0] = Instantiate(street99, new Vector3(6.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[1] = Instantiate(street99, new Vector3(7.5f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[2] = Instantiate(street99, new Vector3(9.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[3] = Instantiate(street99, new Vector3(10.5f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[4] = Instantiate(street99, new Vector3(12.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[5] = Instantiate(street99, new Vector3(13.5f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[6] = Instantiate(street99, new Vector3(15.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[7] = Instantiate(street99, new Vector3(16.5f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[8] = Instantiate(street99, new Vector3(18.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[9] = Instantiate(street99, new Vector3(19.5f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[10] = Instantiate(street99, new Vector3(21.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[11] = Instantiate(street99, new Vector3(22.5f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                        street99Spawns[12] = Instantiate(street99, new Vector3(24.0f, 0.2f, 20.02f), Quaternion.Euler(90, 180, 180));
                    }

                    if (unusualStop != null)
                    {
                        Destroy(unusualStop);
                    }

                    if (unusualPost != null)
                    {
                        Destroy(unusualPost);
                    }
                }

                //àŸïœ2
                if (randomUnusualType == 3)
                {
                    if (unusualPost == null) { 
                        unusualPost = Instantiate(post, new Vector3(0f, 11.7f, 25.5f), Quaternion.Euler(0, 0, 0));
                    }

                    if (unusualStop != null)
                    {
                        Destroy(unusualStop);
                    }

                    if (street99Spawns[0] != null)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            Destroy(street99Spawns[i]);
                        }
                    }
                }
            }
            if (randomUnusual <= 1)
            {
                //àŸïœÇî≠ê∂Ç≥ÇπÇ»Ç¢
                isUnusual = false;
                randomUnusualType = 0;

                if (unusualStop != null)
                {
                    Destroy(unusualStop);
                }

                if (street99Spawns[0] != null)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        Destroy(street99Spawns[i]);
                    }
                }

                if (unusualPost != null)
                {
                    Destroy(unusualPost);
                }
            }

        }

        if (player.transform.position.z >= 22.5f)
        {
            
            switch (randomUnusualType)
            {
                case 0:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount += 1;
                            isClick = true;
                            isUnusualStart = true;
                        }
                        if (playerMove.isRightClick == true)
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
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            unusualCount += 1;
                            isClick = true;
                        }
                    }
                    break;
                case 2:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            unusualCount += 1;
                            isClick = true;
                        }
                    }
                    break;
                case 3:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            unusualCount += 1;
                            isClick = true;
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
