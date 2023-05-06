using System;
using com.bandags.spacegame.input;

namespace com.bandags.spacegame.ship {
    public interface ISensors : IControlSystem {
        /// <summary>
        /// Represents what the user has selected on the screen
        /// </summary>
        ISelectable Selection { get; set; }
        /// <summary>
        /// Represents what the ship is attacking / being attacked by (Visible by popup window at bottom of the screen)
        /// </summary>
        Ship HostileTarget { get; set; }
    }
}