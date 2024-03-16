using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class KillAnglerWithBoulder : Goal {
        public override Item icon => Icons.Npc.Angler;
        public override int difficultyTier => 3;
        public override Item? modifierIcon => new(ItemID.Boulder);
    }
    public class Stack4BarsOnDungeon : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.LowTierBars);
        public override int difficultyTier => 3;
        public override string modifierText => "4";
        public override Item? modifierIcon => Icons.Bestiary.Dungeon;
    }
    public class WearCactusArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.CactusHelmet,
            ItemID.CactusBreastplate,
            ItemID.CactusLeggings
        );
        public override int difficultyTier => 3;
    }
    public class GrowGemTree : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(
            ItemID.GemTreeAmberSeed,
            ItemID.GemTreeAmethystSeed,
            ItemID.GemTreeDiamondSeed,
            ItemID.GemTreeEmeraldSeed,
            ItemID.GemTreeRubySeed,
            ItemID.GemTreeSapphireSeed,
            ItemID.GemTreeTopazSeed
        );
        public override int difficultyTier => 3;
    }
    public class TrashSharkBait : Goal {
        public override Item icon => new(ItemID.SharkBait);
        public override int difficultyTier => 3;
        public override Item? modifierIcon => Icons.Misc.Trash;
    }
    public class FillHouseWithBars : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.AnyBars);
        public override int difficultyTier => 3;
        public override Item? modifierIcon => ModContent.GetInstance<Icons.House>().Item;
    }
    public class GetAllCampfires : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.PreHardmodeCampfires);
        public override int difficultyTier => 3;
        public override string modifierText => "9";
        internal static HashSet<int> collected = new();
        public override string? progressText() => Util.progressTextFor(
            collected, 9
        );
    }
}