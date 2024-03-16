using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class Get2Crates : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Crates);
        public override int difficultyTier => 13;
        public override string modifierText => "2";
    }

    public class Stinky : Goal {
        public override Item icon => Icons.Buff.Stinky;
        public override int difficultyTier => 13;
    }

    public class Loot6GoldChests : Goal { // may be difficult to implement well
        // current idea: track a list of all gold chests opened by the player (by
        // position) and a separate list of gold chests placed by the player.
        // only track a chest as new if it wasn't placed by the player
        public override Item icon => new(ItemID.GoldChest);
        public override int difficultyTier => 13;
        public override string modifierText => "6";
    }

    public class Get4Yoyos : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Yoyos);
        public override int difficultyTier => 13;
        public override string modifierText => "4";
    }

    public class Complete2FishingQuests : Goal {
        public override Item icon => Icons.Misc.QuestFish;
        public override int difficultyTier => 13;
        public override string modifierText => "2";
        public override IList<string> synergyTypes => new[] { "ME.11" };
    }

    public class DieToDG : Goal {
        public override Item icon => Icons.Npc.DungeonGuardian;
        public override int difficultyTier => 13;
    }

    public class KillVillagerwithDG : Goal {
        public override Item icon => Icons.Npc.AnyTown;
        public override int difficultyTier => 13;
        public override Item? modifierIcon => Icons.Npc.DungeonGuardian;
    }

    public class DrinkFlask : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Flasks);
        public override int difficultyTier => 13;
    }
}