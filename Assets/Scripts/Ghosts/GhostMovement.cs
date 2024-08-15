using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] public GameState gameState;
    [SerializeField] public GhostType ghostType;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Vector3 scatterCorner;
    [SerializeField] public Transform target;
    [SerializeField] public Transform blinky;
    public bool debuggingOn = true;
    public Color debugLineColor;

    NavMeshAgent nav;

    GhostProfile profile;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Transform self = GetComponent<Transform>();

        GhostConfig config = new GhostConfig();
        config.gameState = gameState;
        config.nav = nav;
        config.type = ghostType;
        config.target = target;
        config.scatterCorner = scatterCorner;
        config.blinky = blinky;
        config.color = debugLineColor;
        config.self = self;

        profile = ProfileFactory.GetProfile(config);
    }

    void Update()
    {
        if (debuggingOn)
        {
            profile.DrawDebugPath();
        }
        profile.move();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = debugLineColor;
        Gizmos.DrawWireCube(scatterCorner, Vector3.one * 2);
    }
}

