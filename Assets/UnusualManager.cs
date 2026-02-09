using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UnusualManager : MonoBehaviour
{

    public bool isClear;

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
    public GameObject kanban;
    public GameObject mistake;
    public GameObject entixyuu;
    public GameObject gomibako;
    public GameObject donatu;
    public GameObject dosei;
    public GameObject bicycle;
    public GameObject manhole;
    public GameObject manhole1;
    public GameObject pot;

    GameObject firstStreetSpawn;
    GameObject[] streetSpawns = new GameObject[8];
    GameObject[] street99Spawns = new GameObject[13];
    GameObject unusualPost;
    GameObject unusualStop;
    GameObject unusualDonatu;
    GameObject unusualDosei;
    GameObject unusualManhole1;
    GameObject unusualPot;

    private MiniGameManager miniGameManager;
    private ParameterManager parameterManager;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        isStreet1Spawn = false;
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
        unusualDonatu = null;
        playerMove = FindObjectOfType<PlayerMove>();
        parameterManager = FindObjectOfType<ParameterManager>();
        miniGameManager = FindObjectOfType<MiniGameManager>();
        Instantiate(utilityPole, new Vector3(0, 5, 25.5f), Quaternion.Euler(0, 90, 0));
        Instantiate(utilityPole, new Vector3(0, 5, -25.5f), Quaternion.Euler(0, 90, 0));
        Instantiate(post, new Vector3(3.7f,-0.8f, 13), Quaternion.Euler(0, 90, 0));
        Instantiate(cone, new Vector3(1.4f, -0.6f, 25.6f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(1.4f, -0.45f, 25.6f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(-3.5f, -0.6f, -1), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(-3.5f, -0.6f, 3.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(-1.5f, -0.6f, 1.25f), Quaternion.Euler(0, 0, 0));
        Instantiate(cone, new Vector3(2.9f, -0.6f, 25.2f), Quaternion.Euler(6, 26, -110));
        Instantiate(kanban, new Vector3(-5f, 0.38f, 26f), Quaternion.Euler(0, 90, 0));
        Instantiate(mistake, new Vector3(0f, 0.75f, 24.73f), Quaternion.Euler(90, 0, -180));
        Instantiate(entixyuu, new Vector3(-3.72f, -0.37f, 10.0f), Quaternion.Euler(0, 0, 0));
        Instantiate(entixyuu, new Vector3(-2.5f, -0.37f, 10.0f), Quaternion.Euler(0, 0, 0));
        Instantiate(entixyuu, new Vector3(-3.1f, 0.7f, 10.0f), Quaternion.Euler(0, 0, 0));
        Instantiate(gomibako, new Vector3(-3f, -0.3f, 14.5f), Quaternion.Euler(0, 90, 0));
        Instantiate(gomibako, new Vector3(-3.4f, -0.3f, 16.5f), Quaternion.Euler(0, 90, 0));
        Instantiate(gomibako, new Vector3(3.6f, -0.3f, 18.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(gomibako, new Vector3(3.0f, -0.3f, -16.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(bicycle, new Vector3(3.8f, -0.55f, 6.0f), Quaternion.Euler(16, 90, 0));
        Instantiate(bicycle, new Vector3(3.0f, -0.82f, 9.0f), Quaternion.Euler(80, 70, 0));
        Instantiate(manhole, new Vector3(-3.42f, -1f, 1.15f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(5f, 1.75f, 19.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(5f, 1.75f, 18.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(5f, 1.75f, 17.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(5f, 1.75f, 16.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(5f, 1.75f, 15.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(-5f, 1.75f, 19.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(-5f, 1.75f, 18.0f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(-5f, 1.75f, 16.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(-2.5f, 1.75f, 27f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(-1.0f, 1.75f, 27f), Quaternion.Euler(0, 0, 0));
        Instantiate(pot, new Vector3(3.0f, 1.75f, 27f), Quaternion.Euler(0, 0, 0));
        streetSpawns[0] = Instantiate(street1, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
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
                    if (unusualCount == 4)
                    {

                        isStreet1Spawn = false;
                        isStreet2Spawn = false;
                        isStreet3Spawn = false;
                        isStreet4Spawn = false;
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
                        if (isStreet5Spawn == false)
                        {
                            streetSpawns[4] = Instantiate(street5, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
                            isStreet5Spawn = true;
                        }
                    }
                    if (unusualCount == 5)
                    {

                        isStreet1Spawn = false;
                        isStreet2Spawn = false;
                        isStreet3Spawn = false;
                        isStreet4Spawn = false;
                        isStreet5Spawn = false;
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
                        if (isStreet6Spawn == false)
                        {
                            streetSpawns[5] = Instantiate(street6, new Vector3(-2.5f, 0.2f, 26.4f), Quaternion.Euler(90, 180, 0));
                            isStreet6Spawn = true;
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

                    if (unusualDonatu != null)
                    {
                        Destroy(unusualDonatu);
                    }

                    if (unusualDosei != null)
                    {
                        Destroy(unusualDosei);
                    }

                    if (unusualManhole1 != null)
                    {
                        Destroy(unusualManhole1);
                    }

                    if (unusualPot != null)
                    {
                        Destroy(unusualPot);
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

                    if (unusualDonatu != null)
                    {
                        Destroy(unusualDonatu);
                    }

                    if (unusualDosei != null)
                    {
                        Destroy(unusualDosei);
                    }

                    if (unusualManhole1 != null)
                    {
                        Destroy(unusualManhole1);
                    }

                    if (unusualPot != null)
                    {
                        Destroy(unusualPot);
                    }

                }

                //àŸïœ3
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

                    if (unusualDonatu != null)
                    {
                       Destroy(unusualDonatu);
                    }

                    if (unusualDosei != null)
                    {
                        Destroy(unusualDosei);
                    }

                    if (unusualManhole1 != null)
                    {
                        Destroy(unusualManhole1);
                    }

                    if (unusualPot != null)
                    {
                        Destroy(unusualPot);
                    }

                }

                //àŸïœ4
                if (randomUnusualType == 4)
                {
                    if (unusualDonatu == null)
                    {
                        unusualDonatu=Instantiate(donatu, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0, 0, 0));
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

                    if (unusualPost != null)
                    {
                        Destroy(unusualPost);
                    }

                    if (unusualDosei != null)
                    {
                        Destroy(unusualDosei);
                    }

                    if (unusualManhole1 != null)
                    {
                        Destroy(unusualManhole1);
                    }

                    if (unusualPot != null)
                    {
                        Destroy(unusualPot);
                    }

                }

                //àŸïœ5
                if (randomUnusualType == 5)
                {

                    if (unusualDosei == null)
                    {
                        unusualDosei = Instantiate(dosei, new Vector3(0.0f, 300.0f, 0.0f), Quaternion.Euler(0, 0, 180));
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

                    if (unusualPost != null)
                    {
                        Destroy(unusualPost);
                    }

                    if (unusualDonatu != null)
                    {
                        Destroy(unusualDonatu);
                    }

                    if(unusualManhole1 != null)
                    {
                        Destroy(unusualManhole1);
                    }

                    if (unusualPot != null)
                    {
                        Destroy(unusualPot);
                    }

                }

                //àŸïœ6
                if (randomUnusualType == 6)
                {

                    if (unusualManhole1 == null)
                    {
                        unusualManhole1 = Instantiate(manhole1, new Vector3(-3.42f, -0.95f, 1.15f), Quaternion.Euler(0, 0, 0));
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

                    if (unusualPost != null)
                    {
                        Destroy(unusualPost);
                    }

                    if (unusualDonatu != null)
                    {
                        Destroy(unusualDonatu);
                    }

                    if (unusualDosei != null)
                    {
                        Destroy(unusualDosei);
                    }

                    if (unusualPot != null)
                    {
                        Destroy(unusualPot);
                    }

                }

                //àŸïœ7
                if (randomUnusualType == 7)
                {

                    if (unusualPot == null)
                    {
                        unusualPot = Instantiate(pot, new Vector3(-4.0f, 1.75f, 27f), Quaternion.Euler(0, 0, 0));
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

                    if (unusualPost != null)
                    {
                        Destroy(unusualPost);
                    }

                    if (unusualDonatu != null)
                    {
                        Destroy(unusualDonatu);
                    }

                    if (unusualManhole1 != null)
                    {
                        Destroy(unusualManhole1);
                    }

                    if (unusualDosei != null)
                    {
                        Destroy(unusualDosei);
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

                if (unusualDonatu != null)
                {
                    Destroy(unusualDonatu);
                }

                if (unusualDosei != null)
                {
                    Destroy(unusualDosei);
                }

                if (unusualManhole1 != null)
                {
                    Destroy(unusualManhole1);
                }

                if (unusualPot != null)
                {
                    Destroy(unusualPot);
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
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                                isUnusualStart = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                                isUnusualStart = true;
                            }
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
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
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
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
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
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
                        }
                        
                    }
                    break;
                case 4:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
                        }

                    }
                    break;
                case 5:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
                        }

                    }
                    break;
                case 6:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
                        }

                    }

                    if (player.transform.position.x < -5 && player.transform.position.x > -5.5f || player.transform.position.x > 5 && player.transform.position.x < 5.5f)
                    {
                        if (unusualManhole1 != null)
                        {
                            Destroy(unusualManhole1);
                        }
                    }

                    break;
                case 7:
                    if (isClick == false)
                    {
                        if (playerMove.isLeftClick == true)
                        {
                            unusualCount = 0;
                            isClick = true;
                        }
                        if (playerMove.isRightClick == true)
                        {
                            if (miniGameManager.IsGameOver == true)
                            {
                                unusualCount = 0;
                                isClick = true;
                            }
                            else
                            {
                                unusualCount += 1;
                                isClick = true;
                            }
                        }

                    }
                    break;
            }

            if (unusualCount == 6)
            {
                if (player.transform.position.x <= -7 || player.transform.position.x >= 7)
                {
                    isClear = true;
                }
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
