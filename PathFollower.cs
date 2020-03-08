using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    //Transform array to get position of each and every node
    public Transform[] path;
    //Indicates currentNode in examination
    int currentNode = 0;
    public float speed = 2f;

    void Update()
    {
        //Function to draw lines between each pair of nodes in editor mode
        DrawLine();

        //Calculation of direction in which player will move
        Vector3 dir = path[currentNode].position - transform.position;

        if(transform.position == path[currentNode].position)
        {
            //To check if any further nodes are available or not
            CheckNode();
        }

        else
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        Debug.Log(currentNode);
    }

    void CheckNode()
    {
        //If nodes are available then increment currentNode by one
        if (currentNode < path.Length - 1)
            currentNode++;

        //If nodes are not available then do nothing and return
        else
            return;
    }

    void DrawLine()
    {
        for (int i = 0; i < path.Length; i++)
            if (i < path.Length - 1)
                Debug.DrawLine(path[i].position, path[i + 1].position, Color.green);
    }
}
