using System;
using Assets.Scripts.Ghosts.Profiles;
using UnityEngine;
using UnityEngine.AI;


public class ProfileFactory
{
    public static GhostProfile GetProfile(GhostConfig config)
    {
        switch (config.type)
        {
            case GhostType.BLINKY:
                return new Blinky(config);
            case GhostType.INKY:
                return new Inky(config);
            case GhostType.PINKY:
                return new Pinky(config);
            case GhostType.CLYDE:
                Clyde clyde = new Clyde(config);
                return clyde;
        }

        throw new InvalidOperationException("Not a valid ghost type: " + config.type);
    }
}
