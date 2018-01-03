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
    public GameObject Coin01_Prefabs;
    public GameObject Coin02_Prefabs;
    GameObject _prevBlockObject;

    //for test
    public float _intervalDistance = 10.0f;


    GameObject CreateBlock()
    {
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;

        /*
        GameObject coin01_Object = GameObject.Instantiate(CoinPrefabs);
        coin01_Object.transform.position = new Vector2(transform.position.x, 2.5f);

        GameObject coin02_Object = GameObject.Instantiate(CoinPrefabs);
        coin02_Object.transform.position = new Vector2(transform.position.x, 5.0f);
        */
        int selectCoin = Random.Range(0, 1000);
        GameObject coin01_Object;
        GameObject coin02_Object;
        if (selectCoin < 500)
        {
            coin01_Object = GameObject.Instantiate(Coin01_Prefabs);
            coin02_Object = GameObject.Instantiate(Coin02_Prefabs);
        }
        else
        {
            coin01_Object = GameObject.Instantiate(Coin02_Prefabs);
            coin02_Object = GameObject.Instantiate(Coin01_Prefabs);
        }

        coin01_Object.transform.position = new Vector2(transform.position.x, 2.5f);
        int randValue = Random.Range(0, 1000);
        if( randValue < 200 )
        {
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 2.5f);
            coin01_Object.transform.position = transform.position;
        }
        coin02_Object.transform.position = new Vector2(transform.position.x, 5.0f);

        return blockObject;
    }
}
