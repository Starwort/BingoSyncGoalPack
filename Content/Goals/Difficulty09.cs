using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class HaveMaxHealth : Goal {
        public override Item icon => new(ItemID.LifeCrystal);
        public override int difficultyTier => 9;
    }
    public class HaveMaxMana : Goal {
        public override Item icon => new(ItemID.ManaCrystal);
        public override int difficultyTier => 9;
        public override string modifierText => "200";
    }
    public class UseFairy : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(ItemID.FairyCritterPink, ItemID.FairyCritterGreen, ItemID.FairyCritterBlue);
        public override int difficultyTier => 9;
    }
    public class DownArmy : Goal {
        public override Item icon => new(ItemID.GoblinBattleStandard);
        public override int difficultyTier => 9;
        public override Item? modifierIcon => Icons.Misc.Kill;
    }
    public class UsePoisonDart : Goal {
        public override Item icon => new(ItemID.PoisonDart);
        public override int difficultyTier => 9;
        public override Item? modifierIcon => IconAnimationSystem.registerCycleAnimation(Icons.Misc.Blowpipe, Icons.Misc.Blowgun);
    }
    public class Get5Minecarts : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Minecarts);
        public override int difficultyTier => 9;
        public override string modifierText => "5";
    }
    public class DownKSMelee : Goal {
        public override Item icon => new(ItemID.KingSlimeTrophy);
        public override int difficultyTier => 9;
        public override Item? modifierIcon => Icons.Misc.SwordOrSpear;
        public override IList<string> synergyTypes => new[] {"ME.3.2"};
    }
    public class GetTorchGodsFavour : Goal {
        public override Item icon => new(ItemID.TorchGodsFavor);
        public override int difficultyTier => 9;
    }
}