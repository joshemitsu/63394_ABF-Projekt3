using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private float[,] path_ = new float[,]{ 
        { 0.06f, 1.1f },
        { 15.98f, 1.1f },
        { 15.98f, -3.84f },
        { 18.53f, -8.97f },
        { 16.02f, -9.62f },
        { 16.02f, -19.96f },
        { 18.75f, -21.61f },
        { 18.75f, -24.45f },
        { 15.85f, -26.89f },
        { 15.85f, -30.3f },
        { 0f, -30.3f }
    };

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

    IEnumerator MoveFromTo(Vector3 from, Vector3 to, float speed)
    {
        float step = (speed / (from - to).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            transform.position = Vector3.Lerp(from, to, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        transform.position = to;
    }

    /*
    private IEnumerator Move()
    {
        int targetNode = startNode;
        while(true)
        {
            Debug.Log("targetnode index: " + targetNode);
            Debug.Log("targetNode x: " + path[targetNode, 0]);
            Debug.Log("targetNode z: " + path[targetNode, 1]);
            Vector3 targetPos = new Vector3(path[targetNode, 0], 0, path[targetNode, 1]);
            while (Vector3.Distance(transform.position, targetPos) < 0.05)
            {
                //Debug.Log("now entering first while");
                transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
            }

            Debug.Log("left second while");
            if(targetNode < 9)
            {
                targetNode++;
            }
            else
            {
                targetNode = 0;
            }


            print("Reached the target.");

            yield return new WaitForSeconds(3f);

            print("MyCoroutine is now finished.");
        }
    }
    */

}
