using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private bool isMoving = false;
    private int targetNode = 0;

    public PathNode[] path;
    public int startNode;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        targetNode = startNode;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToPathNodeCoroutine(path[targetNode].transform));
        }
    }

    IEnumerator MoveToPathNodeCoroutine(Transform target)
    {
        isMoving = true;
        Vector3 targetPos = target.position - new Vector3(0, 0.6f, 0);

        transform.LookAt(targetPos);

        while(transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            yield return null;
        }

        if (targetNode < 10)
        {
            targetNode++;
        }
        else
        {
            targetNode = 0;
        }

        isMoving = false;
    }
}
