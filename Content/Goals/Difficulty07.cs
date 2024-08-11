using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Icons;

namespace BingoSyncGoalPack.Content.Goals {
    public class DeadMenTellNoTales : Goal {
        public override Item icon => VanillaIcons.Achievement.DeadMenTellNoTales;
        public override int difficultyTier => 7;
        public override IList<string> synergyTypes => ["ME.9"];
    }
    public class Get5WoodArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.WoodHelmet,
            ItemID.WoodBreastplate,
            ItemID.WoodGreaves,
            ItemID.RichMahoganyHelmet,
            ItemID.RichMahoganyBreastplate,
            ItemID.RichMahoganyGreaves,
            ItemID.EbonwoodHelmet,
            ItemID.EbonwoodBreastplate,
            ItemID.EbonwoodGreaves,
            ItemID.ShadewoodHelmet,
            ItemID.ShadewoodBreastplate,
            ItemID.ShadewoodGreaves,
            ItemID.PearlwoodHelmet,
            ItemID.PearlwoodBreastplate,
            ItemID.PearlwoodGreaves,
            ItemID.BorealWoodHelmet,
            ItemID.BorealWoodBreastplate,
            ItemID.BorealWoodGreaves,
            ItemID.PalmWoodHelmet,
            ItemID.PalmWoodBreastplate,
            ItemID.PalmWoodGreaves,
            ItemID.AshWoodHelmet,
            ItemID.AshWoodBreastplate,
            ItemID.AshWoodGreaves,
            ItemID.SpookyHelmet,
            ItemID.SpookyBreastplate,
            ItemID.SpookyLeggings
        );
        public override int difficultyTier => 7;
        public override string modifierText => "5";
        public override IList<string> synergyTypes => ["ME.14"];
        //internal static HashSet<int> armours = [];
        //public override string? progressText() => Util.progressTextFor(
        //    armours, 5
        //);
    }
    public class WearPumpkinArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.PumpkinHelmet,
            ItemID.PumpkinBreastplate,
            ItemID.PumpkinLeggings
        );
        public override int difficultyTier => 7;
    }
    public class WearFossilArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.FossilHelm,
            ItemID.FossilShirt,
            ItemID.FossilPants
        );
        public override int difficultyTier => 7;
    }
    public class GetSummons : Goal {
        public override Item icon => Icons.Misc.SummonStaves;
        public override int difficultyTier => 7;
        public override string modifierText => "7";
        //internal static HashSet<int> obtained = [];
        //public override string? progressText() => Util.progressTextFor(
        //    obtained, 7
        //);
    }
    public class Get100Gel : Goal {
        public override Item icon => new(ItemID.Gel);
        public override int difficultyTier => 7;
        public override string modifierText => "100";
        //internal static int gelHeld = 0;
        //public override string? progressText() => translate(
        //    "ProgressText.GenericCounter",
        //    gelHeld.ToString(),
        //    modifierText
        //);
    }
    public class StackHighTierBars : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.CrimtaneBar,
            ItemID.MeteoriteBar,
            ItemID.HellstoneBar,
            ItemID.DemoniteBar,
            ItemID.MeteoriteBar,
            ItemID.HellstoneBar
        );
        public override int difficultyTier => 7;
        public override Item? modifierIcon => VanillaIcons.Bestiary.Snow;
    }
    public class Get4GrassSeeds : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.GrassSeeds);
        public override int difficultyTier => 7;
        public override string modifierText => "4";
        //internal static HashSet<int> obtained = [];
        //public override string? progressText() => Util.progressTextFor(
        //    obtained,
        //    4
        //);
    }
}