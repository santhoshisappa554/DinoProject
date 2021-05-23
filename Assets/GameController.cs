using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerMovement player;
    public Camera camfollow;
    public float camOffsetZ;
    public GameObject[] blocks;
    public float blockArrowPointer = -10;
    public float safeMargin = 20;

    //Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        print("Welcome to Endless runner game");
        print("press space to jump and escape from Obstacles");

        GameObject blocksPrefab = Instantiate(blocks[0]);
        blocksPrefab.transform.position = this.transform.position;



        GameObject blocksPrefab2 = Instantiate(blocks[1]);
        blocksPrefab2.transform.position = blocksPrefab.transform.position + new Vector3(5, 0, 0);
        // camOffset = new Vector3(0, 0, camOffsetZ);
    }

    // Update is called once per frame
    void Update()
    {
        while (player != null && blockArrowPointer < player.transform.position.x + safeMargin)
        {
            int value = Random.Range(0, blocks.Length);
            GameObject blocksPrefab = Instantiate(blocks[value]);
            BlockSize bs = blocksPrefab.GetComponent<BlockSize>();
            blocksPrefab.transform.position = new Vector3(blockArrowPointer + bs.blockSize / 2, 0, 0);
            blockArrowPointer += bs.blockSize;
        }

        if (player != null)
        {
            camfollow.transform.position = new Vector3(player.transform.position.x, camfollow.transform.position.y, camfollow.transform.position.z);
        }

    }

}

