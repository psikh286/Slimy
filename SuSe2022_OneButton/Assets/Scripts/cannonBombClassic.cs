using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBombClassic : MonoBehaviour
{
    public GameObject prefab;
    public GameObject target;
    public float frequency;


    private void Start()
    {
        StartCoroutine(SpawnBombs());
    }

	private void Update()
	{
        transform.LookAt(target.transform);
        transform.Rotate(0, 180f, 0);
    }


	private IEnumerator SpawnBombs()
	{

        Debug.Log("bomb spawned");
        yield return new WaitForSeconds(frequency);
	}
    
}
