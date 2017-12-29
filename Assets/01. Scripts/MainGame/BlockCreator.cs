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
        if (false == _isCreate)
            return;

		if(_createInterval <= _createDuration)
        {
            _createDuration = 0.0f;
            CreateBlock();
        }
        _createDuration += Time.deltaTime;
	}

    //State

    bool _isCreate = false;

    public void StartCreate()
    {
        _isCreate = true;
    }

    //Blocks

    public GameObject BlockPrefabs;

    float _createInterval = 1.5f;
    float _createDuration = 0.0f;

    void CreateBlock()
    {
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;
        GameObject.Destroy(blockObject, 6.0f);
    }
}
