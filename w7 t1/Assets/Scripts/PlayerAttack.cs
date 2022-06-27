using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform lr;
    [SerializeField] private Transform pointA;
    private void Start()
    {
        
    }
    public void SetUpLine()
    {
        Vector3 points = new Vector3(transform.position.x-pointA.position.x, transform.position.y - pointA.position.y, transform.position.z - pointA.position.z+100);

        lr.GetComponent<LineRenderer>().SetPosition(1, points);
        StartCoroutine (TurnOff());
    }
    public IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.05f);
        lr.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lr.gameObject.SetActive(true);
            SetUpLine();
            
        }
    }

}
