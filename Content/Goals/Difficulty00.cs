using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Content.Goals {
    public class DownEoC : Goal {
        public override Item icon => new(ItemID.EyeofCthulhuTrophy);
        public override int difficultyTier => 0;
        public override IList<string> synergyTypes => new[] {"ME.5.1", "ME.5.2"};
    }
    public class DownKS : Goal {
        public override Item icon => new(ItemID.KingSlimeTrophy);
        public override int difficultyTier => 0;
        public override IList<string> synergyTypes => new[] {"ME.3.1", "ME.3.2"};
    }
    public class EatCookedFish : Goal {
        public override Item icon => new(ItemID.CookedFish);
        public override int difficultyTier => 0;
    }
    public class FillPiggyBank : Goal {
        public override Item icon => new(ItemID.PiggyBank);
        public override int difficultyTier => 0;
        internal static int slotsLeft = 0;
        public override string? progressText() => slotsLeft == 0 ? null : translate(
            "ProgressText.FillPiggyBank",
            slotsLeft.ToString()
        );
    }
    public class Get999OfTile : Goal {
        public override Item icon => Icons.Misc.Tiles;
        public override string modifierText => "999";
        public override int difficultyTier => 0;
        internal static int bestStack = 0;
        public override string? progressText() => bestStack >= 999 ? null : translate(
            "ProgressText.Get999OfTile",
            bestStack.ToString()
        );
    }
    public class PutFoodOnPlate : Goal {
        public override Item icon => new(ItemID.FoodPlatter);
        public override int difficultyTier => 0;
    }
    public class Suffocate7s : Goal {
        public override Item icon => Icons.Buff.Suffocation;
        public override int difficultyTier => 0;
        public override string modifierText => "7s";
    }
    public class DieToThorns : Goal {
        public override Item icon => ModContent.GetInstance<Icons.Thorns>().Item;
        public override int difficultyTier => 0;
        public override Item? modifierIcon => Icons.Misc.Die;
    }
}
