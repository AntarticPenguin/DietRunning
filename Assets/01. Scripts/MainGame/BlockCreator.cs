using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if ( false == _isCreate )
            return;

        float distance = transform.position.x - _prevBlockObject.transform.position.x;
        if ( 10 <= distance )
        {
            _prevBlockObject = CreateBlock();
        }
	}


    //State

    bool _isCreate = false;

    public void StartCreate()
    {
        _isCreate = true;

        _prevBlockObject = CreateBlock();
    }


    //Blocks

    public GameObject BlockPrefabs;
    GameObject _prevBlockObject;

    GameObject CreateBlock()
    {
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;

        int randValue = Random.Range(0, 1000);
        if( randValue < 300 )
        {
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 3.0f);
        }

        //GameObject.Destroy(blockObject, 6.0f);


        return blockObject;
    }
}
