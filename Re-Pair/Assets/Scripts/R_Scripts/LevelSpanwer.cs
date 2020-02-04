using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpanwer : MonoBehaviour
{
    [Header("List of Chunks")]
    [SerializeField] private List<Transform> m_levelChunkList = new List<Transform>();

    [SerializeField] private Transform m_originalTransform;


    [Header("Level Spawn Position and Rotation")]
    [SerializeField] private Transform m_levelSpawnLocation;
    [SerializeField] private Transform m_levelRotation;

    [Header("Level Attributes")]
    [SerializeField] private Vector3 m_levelScale;
    [SerializeField] private bool m_bHasDualGate = false;
    [SerializeField] private bool m_bHasColletables = true;
    [SerializeField] private bool m_bLevelRotates = false;
    [SerializeField] private Renderer[] m_arr_geoMaterials;
    [SerializeField] private GameObject[] m_arr_gameObjetcs;

    private int m_gameObjectArraySize;

    [Header("Obstacle Attributes")]
    [SerializeField] private bool m_bObstaclesOnOff = true;
    [SerializeField] private bool m_bObstacleSpin = false;
    [SerializeField] private Transform[] m_arr_obstaclePositions;


    [Header("Player Attributes")]
    [SerializeField] private PlayerOne m_playerOne;
    [SerializeField] private PlayerTwo m_playerTwo;
    [SerializeField] private Transform m_playerOneSpawn;
    [SerializeField] private Transform m_playerTwoSpawn;

    [Header("Debug options")]
    [SerializeField] private bool m_bFinishedThisChunk;
    



    // Start is called before the first frame update
    void Awake()
    {
       m_levelScale = new Vector3(15, 15, 15);
        

        m_arr_geoMaterials = new Renderer[6];
        m_arr_gameObjetcs = new GameObject[m_gameObjectArraySize];

        

        for(int i = 0; i < 6; ++i)
        {
            m_arr_geoMaterials[i] = FindObjectOfType<Geo>().GetComponent<Renderer>();
        }
        for(int i = 0; i < 12; i++)
        {
            m_arr_obstaclePositions[i] = FindObjectOfType<R_RotateSpikeyThingie>().GetComponent<Transform>();
        }

     
    }

    // Update is called once per frame
    void Update()
    {
        LoadChunk();
    }

    private void LoadChunk()
    {
        if(m_bFinishedThisChunk)
        {
           

            m_playerOne.transform.position = m_playerOneSpawn.position;
            m_playerTwo.transform.position = m_playerTwoSpawn.position;
            BuildLevel();
            DeleteLastChunk();
            UpdateList();
        }
    }

    private void DeleteLastChunk()
    {
        Destroy(m_levelChunkList[0]);
    }

   private void UpdateList()
   {
        Transform l_transform = FindObjectOfType<Geo>().GetComponent<Transform>();
        

        m_levelChunkList.Add(l_transform);
   }


    private void BuildLevel()
    {
        Instantiate(m_levelChunkList[0], m_levelSpawnLocation.position, m_levelRotation.rotation);

        SetObstaclePositions();

        SetGeoMaterials();

        SetDualGates();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerOne")
        {
            m_bFinishedThisChunk = true;
            Debug.Log("Is trigger");
        }  
    }
   

    private void OnTriggerExit(Collider other)
    {
        m_bFinishedThisChunk = false;
    }

    void SetObstaclePositions()
    {
      
        Quaternion l_spikeyRotation = Quaternion.Euler(0,0,0);

        if (m_bObstaclesOnOff)
        {
            for (int i = 0; i < 12; ++i)
            {
                float l_positionsX = Random.Range(10, 400);
                float l_positionsY = Random.Range(25, 350);
                float l_positionsZ = Random.Range(10, 400);

                Vector3 l_position = new Vector3(l_positionsX, l_positionsY, l_positionsZ);

                Instantiate(m_arr_obstaclePositions[i], l_position, l_spikeyRotation);
            }

        }
    }

    void SetGeoMaterials()
    {
        for(int i = 0; i < 6; ++i)
        {
            m_arr_geoMaterials[i].material.color = Color.blue;
        }
    }

    void SetDualGates()
    {
        int l_randSeed = Random.Range(0, 100);

        if(l_randSeed >= 75)
        {
            m_bHasDualGate = true;
        }
        else if(l_randSeed <= 74)
        {
            m_bHasDualGate = true;
        }
    }
}
