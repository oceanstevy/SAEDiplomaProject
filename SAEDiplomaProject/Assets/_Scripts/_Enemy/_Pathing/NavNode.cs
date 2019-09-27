using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavNode
{
    public readonly List<NavNode> Neighbours = new List<NavNode>();

    #region PrivateVariables
    private Vector3 Position;
    private bool Walkable;
    private float GroundCost;
    private float HeuristicCost;
    private NavNode Previous;
    #endregion PrivateVariables
    #region Properties
    public float CompleteCost { get { return GroundCost + HeuristicCost; } }
    #endregion Properties

    public NavNode(Vector3 Pos, bool Walk)
    {
        Position = Pos;
        Walkable = Walk;
    }
}
