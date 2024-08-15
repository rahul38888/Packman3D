using UnityEngine;
using UnityEngine.AI;

public class GhostConfig
{
    public GameState gameState;
    public GhostType type;
    public NavMeshAgent nav;
    public Transform target;
    public Vector3 scatterCorner;
    public Transform blinky;
    public Transform self;
    public Color color;
}
