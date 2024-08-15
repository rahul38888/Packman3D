using UnityEngine;
using UnityEngine.AI;

public abstract class GhostProfile
{
    protected NavMeshAgent nav;
    private Color color;

    public GhostProfile(NavMeshAgent nav, Color color)
    {
        this.nav = nav;
        this.color = color;
    }

    public abstract void move();

    public void DrawDebugPath()
    {
        var path = nav.path;
        Vector3 start = path.corners[0];
        start.y += .01f;

        for (int i = 1; i < path.corners.Length; i++)
        {
            Vector3 end = path.corners[i];
            end.y += .01f;
            Debug.DrawLine(start, end, color);
            start = end;
        }
    }
}
