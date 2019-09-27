using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGrid : MonoBehaviour
{
    public static NavGrid Get { get; private set; }
    public LayerMask GroundLayer;
    NavNode[,] AllNodes;

    private void Awake()
    {
        if(Get == null)
        {
            Get = this;
        }
        else
        {
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateGrid()
    {
        RaycastHit Hit;

        AllNodes = new NavNode[101, 101];
    }
}
