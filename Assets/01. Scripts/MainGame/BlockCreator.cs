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
        if ( _intervalDistance <= distance )
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

    //for test
    public float _intervalDistance = 10.0f;


    GameObject CreateBlock()
    {
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;

        int randValue = Random.Range(0, 1000);
        if( randValue < 200 )
        {
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 1.8f);
        }

        //GameObject.Destroy(blockObject, 6.0f);


        return blockObject;
    }
}
