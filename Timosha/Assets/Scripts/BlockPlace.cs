using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlace : MonoBehaviour
{
    Cube_Control cube_Control;
    CameraBackgoundColor cameraBackgoundColor;

    public Transform player;
    public BlockBeamPart[] block;
    public GameObject[] blocks;

    //public GameObject BlockInSpace;
    //public GameObject BlockPart;
    public GameObject blockPrefab;
    public GameObject blockPrefabTemp;
    public GameObject blockPrefabSpace;

    public BlockBeamPart FirstBlock;
    [SerializeField]
    List<BlockBeamPart> spawnBlocks = new List<BlockBeamPart>();
    [SerializeField]
    List<GameObject> BlocksPool = new List<GameObject>(7);
    [SerializeField]
    List<GameObject> BlocksInSpacePool = new List<GameObject>(7);
    [SerializeField]
    List<GameObject> TemporaryPool = new List<GameObject>(7);

    int blockCCountLimit = 6;
    int PoolLimit = 7;
    bool SpaceSky = false;
    bool SolidColor = true;
    int b=0;

    // Value which save last angle Y player's pos before turn
    int playerTurnPosition;
    // For check, what the last value of player's turn pos was
    int[] turnsValues = new int[5] { 180, 270, 0, 90, 360 };

    void Start()
    {
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();

        FirstSevenBlocksSecond();

        ChangeOnUsualBlocksFirstly();
    }


    void FixedUpdate()
    {
        #region SECOND METHOD THROUGH POOL

        if (CameraBackgoundColor.SpaceSky==true && b==0)
        {
            SpaceSky = true;
            SolidColor = false;
            b++;
        }

        if (CameraBackgoundColor.SpaceSky == false && b==1)
        {
            SpaceSky = false;
            SolidColor = true;
            b--;
        }
        
        if (SpaceSky == true)
        {
            ChangeBlockPrefSpace();
        }

        if (SolidColor == true)
        {
            ChangeOnUsualBlocks();
        }

        //Moving of player to negative Z axis direction
        if ((player.eulerAngles.y == 180) 
            && (player.position.z < BlocksPool[BlocksPool.Count-1].transform.position.z))
        {
            SpawnBlocksPoolNegativeZ();
        }

        //Moving of player to positive Z axis direction
        if ((player.eulerAngles.y == 0 || player.transform.eulerAngles.y == 360)
            && player.position.z > BlocksPool[BlocksPool.Count - 1].transform.position.z)
        {
            SpawnBlocksPoolPositiveZ();
        }

        
        //Moving of player to negative X axis direction
        if ((player.eulerAngles.y == 270)
            && player.position.x < BlocksPool[BlocksPool.Count - 1].transform.position.x)
        {
            SpawnBlocksPoolNegativeX();
        }

        //Moving of player to positive X axis direction
        if ((player.transform.eulerAngles.y == 90)
            && player.position.x > BlocksPool[BlocksPool.Count - 1].transform.position.x)
        {
            SpawnBlocksPoolPositiveX();
        }


        if ((cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true))
        {
            SpawnBlockPoolWhenTurn();
        }

        #endregion

        #region FIRST METHOD 
        /*
        //Moving of player to negative Z axis direction
        if ((player.transform.eulerAngles.y == 180) 
            && (player.position.z < spawnBlocks[spawnBlocks.Count - 1].end.position.z))
            //&& (cube_Control.button_was_rights == false || cube_Control.button_was_lefts == false))
        {
            SpawnBlocksNegativeZ();
        }

        //Moving of player to positive Z axis direction
        else if ((player.transform.eulerAngles.y == 0 || player.transform.eulerAngles.y == 360) 
            && (player.position.z > spawnBlocks[spawnBlocks.Count - 1].begin.position.z))
            //&& (cube_Control.button_was_rights == false || cube_Control.button_was_lefts == false))
        {
            SpawnBlocksPositiveZ();
        }


        //Moving of player to negative X axis direction
        if ((player.transform.eulerAngles.y == 270)
            && (player.position.x < spawnBlocks[spawnBlocks.Count - 1].end.position.x))
            //&& (cube_Control.button_was_rights == false || cube_Control.button_was_lefts == false))
        {
            SpawnBlocksNegativeX();
        }

        //Moving of player to positive X axis direction
        else if ((player.transform.eulerAngles.y == 90) 
            && (player.position.x > spawnBlocks[spawnBlocks.Count - 1].begin.position.x))
            //&& (cube_Control.button_was_rights == false || cube_Control.button_was_lefts == false))
        {
            SpawnBlocksPositiveX();
        }

        if (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)
        {
            SpawnBlockWhenTurn();
        }
        */
        #endregion
        
    }

    //First three blocks THROUGH POOL
    void FirstSevenBlocksSecond()
    {
        
        for(int i = 0; i < PoolLimit; i++)
        {
            if (i==0)
            {
                /*
                blockPrefab.transform.position = new Vector3(0, 0, 7f);
                BlocksPool.Insert(0, Instantiate(blockPrefab));
                */
                /////////////////////////////////////////////////
                
                blockPrefabSpace.transform.position = new Vector3(0, 0, 7f);
                BlocksInSpacePool.Insert(0, Instantiate(blockPrefabSpace));

                BlocksInSpacePool[i].SetActive(false);

                /////////////////////////////////////////////////

                //blockPrefabTemp.SetActive(false);
                blockPrefabTemp.transform.position = new Vector3(0, 0, 7f);
                TemporaryPool.Insert(0, Instantiate(blockPrefabTemp));

                //TemporaryPool[i].SetActive(false);
            }
            else
            {
                /*
                blockPrefab.transform.position =
                new Vector3(0, 0, BlocksPool[BlocksPool.Count - 1].transform.position.z - 1.25f);
                BlocksPool.Insert(i, Instantiate(blockPrefab));
                */
                //////////////////////////////////////////////////////////////////////////////////
                blockPrefabSpace.transform.position =
                new Vector3(0, 0, BlocksInSpacePool[BlocksInSpacePool.Count-1].transform.position.z - 1.25f);
                BlocksInSpacePool.Insert(i, Instantiate(blockPrefabSpace));
                BlocksInSpacePool[i].SetActive(false);
                /////////////////////////////////////////////////////////////////////////////////
                blockPrefabTemp.transform.position =
                new Vector3(0, 0, TemporaryPool[TemporaryPool.Count - 1].transform.position.z - 1.25f);
                TemporaryPool.Insert(i, Instantiate(blockPrefabTemp));
                //TemporaryPool[i].transform.position =
                //    new Vector3(0, 0, TemporaryPool[i].transform.position.z - 1.25f);
                //blockPrefabTemp.SetActive(false);
                //TemporaryPool[i].SetActive(false);
            }
        }
        blockPrefab.transform.position = new Vector3(0, 50, 0);
        blockPrefabSpace.transform.position = new Vector3(0, 50, 0);
        blockPrefabTemp.transform.position = new Vector3(0, 50, 0);
    }

    void ChangeOnUsualBlocksFirstly()
    {
        for (int i = 0; i < PoolLimit;)
        {
            /*
            TemporaryPool[i].transform.position =
                BlocksPool[i].transform.position;

            TemporaryPool[i].transform.rotation =
                BlocksPool[i].transform.rotation;

            BlocksPool.RemoveAt(i);
            */
            BlocksPool.Insert(i, TemporaryPool[i]);

            //BlocksInSpacePool[i].SetActive(false);
            TemporaryPool[i].SetActive(true);
            //BlocksPool[i].SetActive(true);

            i++;
            if (i >= PoolLimit)
            {
                SolidColor = false;
                break;
            }
        }
    }

    void ChangeOnUsualBlocks()
    {
        for (int i = 0; i < PoolLimit;)
        {
            TemporaryPool[i].transform.position =
                BlocksPool[i].transform.position;

            TemporaryPool[i].transform.rotation =
                BlocksPool[i].transform.rotation;

            BlocksPool.RemoveAt(i);
            BlocksPool.Insert(i, TemporaryPool[i]);

            BlocksInSpacePool[i].SetActive(false);
            TemporaryPool[i].SetActive(false);
            BlocksPool[i].SetActive(true);

            i++;
            if (i >= PoolLimit)
            {
                SolidColor = false;
                break;
            }
        }
    }

    void ChangeBlockPrefSpace()
    {
        for (int i = 0; i < PoolLimit;)
        {
            BlocksInSpacePool[i].transform.position =
                BlocksPool[i].transform.position;

            BlocksInSpacePool[i].transform.rotation =
                BlocksPool[i].transform.rotation;

            BlocksPool.RemoveAt(i);
            BlocksPool.Insert(i, BlocksInSpacePool[i]);
            TemporaryPool[i].SetActive(false);
            BlocksInSpacePool[i].SetActive(false);
            BlocksPool[i].SetActive(true);
            i++;
            if (i >= PoolLimit)
            {
                SpaceSky = false;
                break;
            }
        }
    }

    #region METHOD THROUGH POOL

    // -Z
    void SpawnBlocksPoolNegativeZ()
    {
        if ((cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false))
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = 
                new Vector3(0, 180, 0);

            poolElement.transform.localPosition = new Vector3(0, 0, 0);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            poolElement.transform.position =
                new Vector3(poolElement.transform.position.x, poolElement.transform.position.y, 
                BlocksPool[BlocksPool.Count-1].transform.position.z -1.25f);
            BlocksPool.Insert(PoolLimit-1, poolElement);
            poolElement.SetActive(true);
        }
    }

    // +Z
    void SpawnBlocksPoolPositiveZ()
    {
        if ((cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false))
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = 
                new Vector3(0, 180, 0);

            poolElement.transform.localPosition = new Vector3(0, 0, 0);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            poolElement.transform.position =
                new Vector3(poolElement.transform.position.x, poolElement.transform.position.y,
                BlocksPool[BlocksPool.Count - 1].transform.position.z + 1.25f);
            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }
    }
    // -X
    void SpawnBlocksPoolNegativeX()
    {
        if ((cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false))
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = new Vector3(0, 180, 0);
            poolElement.transform.localPosition = new Vector3(0, 0, 0);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            poolElement.transform.position =
                new Vector3(BlocksPool[BlocksPool.Count - 1].transform.position.x - 1.25f, poolElement.transform.position.y,
                poolElement.transform.position.z);
            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }
    }

    // +X
    void SpawnBlocksPoolPositiveX()
    {
        if ((cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false))
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = new Vector3(0, 180, 0);
            poolElement.transform.localPosition = new Vector3(0, 0, 0);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            poolElement.transform.position =
                new Vector3(BlocksPool[BlocksPool.Count - 1].transform.position.x + 1.25f, poolElement.transform.position.y,
                poolElement.transform.position.z);
            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    // Spawn blocks in turning time
    // [0]-180, [1]-270, [2]-0, [3]-90, [4]-360
    void SpawnBlockPoolWhenTurn()
    {
        //Any turn from negative Z axis

        if ((playerTurnPosition == turnsValues[0])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.z < BlocksPool[BlocksPool.Count - 1].transform.position.z))
        {
            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = new Vector3(0, 180, 0);
            poolElement.transform.localPosition =
                new Vector3(0, 0, 1.25f);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }

        //Any turn from negative X axis
        if ((playerTurnPosition == turnsValues[1])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.x < BlocksPool[BlocksPool.Count - 1].transform.position.x)
            /*|| (player.position.z > BlocksPool[BlocksPool.Count - 1].transform.position.z)*/)
        {
            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = new Vector3(0, 180, 0);
            poolElement.transform.localPosition =
                new Vector3(0, 0, 1.25f);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }

        //Any turn from positive Z axis
        else if ((playerTurnPosition == turnsValues[2] || playerTurnPosition == turnsValues[4])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.z > BlocksPool[BlocksPool.Count - 1].transform.position.z))
        {
            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);            
            poolElement.transform.localEulerAngles = new Vector3(0, 180, 0);
            poolElement.transform.localPosition =
                new Vector3(0, 0, 1.25f);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }

        //Any turn from positive X axis
        else if ((playerTurnPosition == turnsValues[3])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.x > BlocksPool[BlocksPool.Count - 1].transform.position.x))
        {
            BlocksPool[0].SetActive(false);
            GameObject poolElement = BlocksPool[0];
            BlocksPool.RemoveAt(0);

            poolElement.transform.SetParent(player);
            poolElement.transform.localEulerAngles = new Vector3(0, 180, 0);
            poolElement.transform.localPosition =
                new Vector3(0, 0, 1.25f);
            poolElement.transform.SetParent(null);
            poolElement.transform.localScale = new Vector3(1, 1, 1);

            BlocksPool.Insert(PoolLimit - 1, poolElement);
            poolElement.SetActive(true);
        }
    }

    #endregion

    #region USUAL METHOD
    /*
    //First three blocks
    void FirstThreeBlocks()
    {
        if (spawnBlocks.Count == 0)
        {
            BlockBeamPart newBlock = Instantiate(block[0]);
            newBlock.transform.position = new Vector3(0, 0, 2.5f);
            spawnBlocks.Add(newBlock);
        }

        else
        {
            BlockBeamPart newBlock = Instantiate(block[0]);
            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= 4)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }*/

    /*
    void SecondThreeBlocks()
    {
        if (spawnBlocks.Count == 0)
        {
            BlockBeamPart newBlock = Instantiate(block[0]);
            newBlock.transform.eulerAngles = new Vector3(0, 90, 0);
            newBlock.transform.position = new Vector3(2.5f, 0, 0);
            spawnBlocks.Add(newBlock);
        }

        else
        {
            BlockBeamPart newBlock = Instantiate(block[0]);

            newBlock.transform.eulerAngles = new Vector3(0, 90, 0);
            newBlock.transform.position = new Vector3(0, 0, 0);
            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.position = new Vector3(newBlock.transform.position.x-0.57f, 0, 0);
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= 4)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }
    */

    // -Z
    void SpawnBlocksNegativeZ()
    {
        if (cube_Control.button_was_lefts == true || cube_Control.button_was_rights == true)
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z);
            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        else if ((cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false))
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);
            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.SetParent(null);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= blockCCountLimit)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }

    // -Z 2
    void SpawnBlocksPrefabsNegativeZ()
    {
        if (cube_Control.button_was_lefts == true || cube_Control.button_was_rights == true)
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z);
            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        else if ((cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false))
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);
            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.SetParent(null);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= blockCCountLimit)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }
    // +Z
    void SpawnBlocksPositiveZ()
    {
        if (cube_Control.button_was_lefts == true || cube_Control.button_was_rights == true)
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 0, 0);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].begin.position - newBlock.end.localPosition;
            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z);
            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        else if (cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false)
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);
            newBlock.transform.localEulerAngles = new Vector3(0, 0, 0);
            newBlock.transform.SetParent(null);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].begin.position - newBlock.end.localPosition;
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= blockCCountLimit)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }
    // -X
    void SpawnBlocksNegativeX()
    {
        if (cube_Control.button_was_lefts == true || cube_Control.button_was_rights == true)
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z+0.57f);

            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }
        else if (cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false)
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition = 
                new Vector3(0, 0, 0); 

            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);
            newBlock.transform.SetParent(null);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.localPosition =
                new Vector3(newBlock.transform.position.x - 0.57f, 0,
                spawnBlocks[spawnBlocks.Count - 1].transform.position.z);

            //newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }            

        if (spawnBlocks.Count >= blockCCountLimit)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }

    // +X
    void SpawnBlocksPositiveX()
    {
        if (cube_Control.button_was_lefts == true || cube_Control.button_was_rights == true)
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 0, 0);

            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z+0.68f);

            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        else if (cube_Control.button_was_lefts == false || cube_Control.button_was_rights == false)
        {
            playerTurnPosition = (int)player.transform.eulerAngles.y;

            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition = 
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 0, 0);
            newBlock.transform.SetParent(null);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].begin.position - newBlock.end.localPosition;
            newBlock.transform.localPosition = new Vector3(newBlock.transform.position.x + 0.68f, 0, 
                spawnBlocks[spawnBlocks.Count - 1].transform.position.z);

            //newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= blockCCountLimit)
        {
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    // Spawn blocks in turning time
    void SpawnBlocksPoolWhenTurn()
    {
        //Any turn from negative Z axis
        if ((playerTurnPosition == turnsValues[0])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.z < spawnBlocks[spawnBlocks.Count - 1].end.position.z))
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);
            //
            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].end.position - newBlock.begin.localPosition;
            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z);
            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        //Any turn from negative X axis
        if ((playerTurnPosition == turnsValues[1])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.x < spawnBlocks[spawnBlocks.Count - 1].end.position.x))
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 180, 0);

            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z + 1.0f);

            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        //Any turn from positive Z axis
        else if ((playerTurnPosition == turnsValues[2] || playerTurnPosition == turnsValues[4])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.z > spawnBlocks[spawnBlocks.Count - 1].begin.position.z))
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);
            //
            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 0, 0);

            newBlock.transform.position =
                spawnBlocks[spawnBlocks.Count - 1].begin.position - newBlock.end.localPosition;
            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z);
            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        //Any turn from positive X axis
        else if ((playerTurnPosition == turnsValues[3])
            /*&& (cube_Control.button_was_rights == true || cube_Control.button_was_lefts == true)*/
            && (player.position.x > spawnBlocks[spawnBlocks.Count - 1].begin.position.x))
        {
            BlockBeamPart newBlock = Instantiate(block[0], player);

            newBlock.transform.localPosition =
                new Vector3(0, 0, 0);

            newBlock.transform.localEulerAngles = new Vector3(0, 0, 0);

            newBlock.transform.localPosition = new Vector3(0, 0, newBlock.transform.localPosition.z + 1.0f);

            newBlock.transform.SetParent(null);
            newBlock.transform.localScale = new Vector3(1, 1, 1);
            spawnBlocks.Add(newBlock);
        }

        if (spawnBlocks.Count >= blockCCountLimit)
        {            
            Destroy(spawnBlocks[0].gameObject);
            spawnBlocks.RemoveAt(0);
        }
        /*
        Destroy(spawnBlocks[spawnBlocks.Count - (spawnBlocks.Count - 1)].gameObject);
        spawnBlocks.RemoveAt(spawnBlocks.Count - (spawnBlocks.Count - 1));
        */
    }

    #endregion
}
