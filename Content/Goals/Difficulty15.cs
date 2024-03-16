using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class GetTragicUmbrella : Goal {
        public override Item icon => new(ItemID.TragicUmbrella);
        public override int difficultyTier => 15;
    }

    public class GetQuadShotgun : Goal {
        public override Item icon => new(ItemID.QuadBarrelShotgun);
        public override int difficultyTier => 15;
    }

    public class UseFogboundDye : Goal {
        public override Item icon => new(ItemID.FogboundDye);
        public override int difficultyTier => 15;
    }

    public class Get5GoldGraves : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.GoldGraves);
        public override int difficultyTier => 15;
        public override string modifierText => "5";
    }

    public class KillWithCoffin : Goal {
        public override Item icon => new(ItemID.CoffinMinecart);
        public override int difficultyTier => 15;
        public override Item? modifierIcon => Icons.Achievement.VehicularManslaughter;
    }

    public class ExcavateWithShovel : Goal {
        public override Item icon => new(ItemID.GravediggerShovel);
        public override int difficultyTier => 15;
        public override string modifierText => "500";
    }

    public class MakeEvilOrbDrop : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.BandofStarpower,
            ItemID.PanicNecklace
        );
        public override int difficultyTier => 15;
        public override Item? modifierIcon => Icons.Misc.Craft;
    }

    public class KillGraveyardMobs : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            Icons.Npc.MaggotZombie,
            Icons.Npc.Ghost,
            Icons.Npc.Raven
        );
        public override int difficultyTier => 15;
        public override string modifierText => "3";
    }
}