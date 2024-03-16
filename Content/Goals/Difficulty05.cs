using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class BreakLivingTreeLeaves : Goal {
        public override Item icon => ModContent.GetInstance<Icons.LivingLeaf>().Item;
        public override int difficultyTier => 5;
        public override Item? modifierIcon => Icons.Misc.Mine;
    }
    public class EatGrubSoup : Goal {
        public override Item icon => new(ItemID.GrubSoup);
        public override int difficultyTier => 5;
    }
    public class Get4CritterContainers : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.CritterCages);
        public override int difficultyTier => 5;
        public override string modifierText => "4";
        internal static HashSet<int> obtainedCritterContainers = new();
        public override string? progressText() => Util.progressTextFor(
            obtainedCritterContainers,
            4
        );
    }
    public class GetLemonadeOrAppleJuice : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(ItemID.Lemonade, ItemID.AppleJuice);
        public override int difficultyTier => 5;
        public override Item? modifierIcon => Icons.Misc.Craft;
    }
    public class VanityWinnerSet : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.PlaguebringerHelmet,
            ItemID.PlaguebringerChestplate,
            ItemID.PlaguebringerGreaves,
            ItemID.RoninHat,
            ItemID.RoninShirt,
            ItemID.RoninPants,
            ItemID.TimelessTravelerHood,
            ItemID.TimelessTravelerRobe,
            ItemID.TimelessTravelerBottom,
            ItemID.FloretProtectorHelmet,
            ItemID.FloretProtectorChestplate,
            ItemID.FloretProtectorLegs,
            ItemID.CapricornMask,
            ItemID.CapricornChestplate,
            ItemID.CapricornLegs,
            ItemID.CapricornTail,
            ItemID.TVHeadMask,
            ItemID.TVHeadSuit,
            ItemID.TVHeadPants
        );
        public override int difficultyTier => 5;
    }
    public class Get4Shrooms : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.Mushrooms);
        public override int difficultyTier => 5;
        public override string modifierText => "4";
        internal static HashSet<int> obtainedShrooms = new();
        public override string? progressText() => Util.progressTextFor(
            obtainedShrooms,
            4
        );
    }
    public class Get3Watches : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.Watches);
        public override int difficultyTier => 5;
        public override string modifierText => "3";
        internal static HashSet<int> obtainedWatches = new();
        public override string? progressText() => Util.progressTextFor(
            obtainedWatches,
            3
        );
    }
    public class GetTrash : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.FishingTrash);
        public override int difficultyTier => 5;
        public override string modifierText => "3";
        internal static HashSet<int> obtainedTrash = new();
        public override string? progressText() => Util.progressTextFor(
            obtainedTrash,
            3
        );
    }
}