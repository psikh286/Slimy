using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBombClassic : MonoBehaviour
{
    public GameObject prefab;
    public GameObject target;
    public Transform firePoint;
    public float frequency;
    public float delay;
    Animator animator;


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(SpawnBombs());
    }

	private void Update()
	{
        transform.LookAt(target.transform);
        transform.Rotate(0, 180f, 0);
    }


	private IEnumerator SpawnBombs()
	{
        yield return new WaitForSeconds(4f);
        while (true)
		{            
            yield return new WaitForSeconds(frequency);
            animator.SetTrigger("Fire");
            yield return new WaitForSeconds(delay);
            Instantiate(prefab, firePoint.position, Quaternion.identity);
        }        
	}    
}
