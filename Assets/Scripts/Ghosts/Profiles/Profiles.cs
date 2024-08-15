using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Ghosts.Profiles
{
    /// <summary>
    /// Follows Pac-Man directly during Chase mode, and heads to the upper-right corner during Scatter mode.
    /// He also has an "angry" mode that is triggered when there are a certain number of dots left in the maze.
    /// </summary>
    class Blinky : GhostProfile
    {
        private Transform target;
        private Vector3 scatterCorner;
        private GameState gameState;

        public Blinky(GhostConfig config): base(config.nav, config.color)
        {
            this.gameState = config.gameState;
            this.target = config.target;
            this.scatterCorner = config.scatterCorner;
        }

        public override void move()
        {
            GhostState state = gameState.GhostsState();
            if (state.Equals(GhostState.CHASE))
            {
                // How to detect hit? Collision?

                nav.SetDestination(target.position);
            }
            else if(state.Equals(GhostState.SCATTER))
            {
                nav.SetDestination(scatterCorner);
            }
        }
    }

    /// <summary>
    /// During Chase mode, his target is a bit complex. His target is relative to both Blinky and Pac-Man, 
    /// where the distance Blinky is from Pinky's target is doubled to get Inky's target. 
    /// He heads to the lower-right corner during Scatter mode.
    /// </summary>
    class Inky : GhostProfile
    {
        private GameState gameState;
        private Transform target;
        private Vector3 scatterCorner;

        private Transform blinky;

        public Inky(GhostConfig config) : base(config.nav, config.color)
        {
            this.gameState = config.gameState;
            this.target = config.target;
            this.scatterCorner = config.scatterCorner;
            this.blinky = config.blinky;
        }

        public override void move()
        {
            GhostState state = gameState.GhostsState();
            if (state.Equals(GhostState.CHASE))
            {
                // How to detect hit? Collision?

                Vector3 transientPos = target.position + target.forward.normalized * 2 * Constants.tileSize;
                Vector3 blinkyToTransientPos = transientPos - blinky.position;
                Vector3 targetPos = blinky.position + blinkyToTransientPos.normalized * blinkyToTransientPos.magnitude * 2;

                nav.SetDestination(targetPos);
            }
            else if (state.Equals(GhostState.SCATTER))
            {
                nav.SetDestination(scatterCorner);
            }
        }
    }

    /// <summary>
    /// Chases towards the spot 2 Pac-Dots in front of Pac-Man. Due to a bug in the original game's coding, 
    /// if Pac-Man faces upwards, Pinky's target will be 2 Pac-Dots in front of and 2 to the left of Pac-Man. 
    /// During Scatter mode, she heads towards the upper-left corner.
    /// </summary>
    class Pinky : GhostProfile
    {
        private GameState gameState;
        private Transform target;
        private Vector3 scatterCorner;

        public Pinky(GhostConfig config) : base(config.nav, config.color)
        {
            this.gameState = config.gameState;
            this.target = config.target;
            this.scatterCorner = config.scatterCorner;
        }

        public override void move()
        {
            GhostState state = gameState.GhostsState();
            if (state.Equals(GhostState.CHASE))
            {
                // How to detect hit? Collision?

                Vector3 targetPos = target.position + target.forward.normalized * 4 * Constants.tileSize;

                nav.SetDestination(targetPos);
            }
            else if (state.Equals(GhostState.SCATTER))
            {
                nav.SetDestination(scatterCorner);
            }
        }
    }

    /// <summary>
    /// Chases directly after Pac-Man, but tries to head to his Scatter corner when within an 8-Dot radius of Pac-Man. 
    /// His Scatter Mode corner is the lower-left.
    /// </summary>
    class Clyde : GhostProfile
    {
        private GameState gameState;
        private Transform target;
        private Vector3 scatterCorner;
        private Transform self;

        public Clyde(GhostConfig config) : base(config.nav, Color.yellow)
        {
            this.gameState = config.gameState;
            this.target = config.target;
            this.scatterCorner = config.scatterCorner;
            this.self = config.self;
        }

        public override void move()
        {
            GhostState state = gameState.GhostsState();
            if (state.Equals(GhostState.CHASE))
            {
                // TODO: How to detect hit? Collision?

                float distance = Vector3.Distance(self.position, target.position);

                Vector3 targetPos = target.position;

                if (distance <= 8 * Constants.tileSize)
                {
                    targetPos = scatterCorner;
                }

                nav.SetDestination(targetPos);
            }
            else if (state.Equals(GhostState.SCATTER))
            {
                nav.SetDestination(scatterCorner);
            }
        }
    }
}
