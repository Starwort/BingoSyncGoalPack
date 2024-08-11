using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Icons;

namespace BingoSyncGoalPack.Content.Goals {
    public class MakePotions_Magic : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.MagicPowerPotion,
            ItemID.ManaRegenerationPotion
        );
        public override int difficultyTier => 6;
        public override Item? modifierIcon => Icons.Misc.Craft;
        //internal static HashSet<int> obtained = [];
        //public override string? progressText() => Util.progressTextFor(
        //    obtained, 2
        //);
    }
    public class MakePotions_Explore : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.MiningPotion,
            ItemID.ShinePotion,
            ItemID.NightOwlPotion
        );
        public override int difficultyTier => 6;
        public override Item? modifierIcon => Icons.Misc.Craft;
        //internal static HashSet<int> obtained = [];
        //public override string? progressText() => Util.progressTextFor(
        //    obtained, 3
        //);
    }
    public class MakePotions_Water : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.WaterWalkingPotion,
            ItemID.FlipperPotion
        );
        public override int difficultyTier => 6;
        public override Item? modifierIcon => Icons.Misc.Craft;
        //internal static HashSet<int> obtained = [];
        //public override string? progressText() => Util.progressTextFor(
        //    obtained, 2
        //);
    }
    public class MakePotions_Trans : Goal {
        public override Item icon => new(ItemID.GenderChangePotion);
        public override int difficultyTier => 6;
        public override Item? modifierIcon => Icons.Misc.Craft;
    }
    public class FindBiome_SurfaceMushroom : Goal {
        public override Item icon => VanillaIcons.Bestiary.SurfaceMushroom;
        public override int difficultyTier => 6;
    }
    public class FindBiome_EvilOcean : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            VanillaIcons.Bestiary.Corruption,
            VanillaIcons.Bestiary.Crimson
        );
        public override int difficultyTier => 6;
        public override Item? modifierIcon => VanillaIcons.Bestiary.Ocean;
    }
    public class FindBiome_EvilDesert: Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            VanillaIcons.Bestiary.CorruptDesert,
            VanillaIcons.Bestiary.CrimsonDesert
        );
        public override int difficultyTier => 6;
    }
    public class MakePotions_Titan : Goal {
        public override Item icon => new(ItemID.TitanPotion);
        public override int difficultyTier => 6;
        public override Item? modifierIcon => Icons.Misc.Craft;
    }
}