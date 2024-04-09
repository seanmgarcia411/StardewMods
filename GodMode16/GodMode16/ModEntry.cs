using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace GodMode16
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicking += this.PleaseNoDie;
        }

        /*********
        ** Private methods
        *********/
        /// <summary>Raised as soon as the mod is loaded. Keeps the player from being kill.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void PleaseNoDie(object sender, UpdateTickingEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            if (Game1.player.health < Game1.player.maxHealth)
            {
                Game1.player.health = Game1.player.maxHealth;
            }
        }
    }
}