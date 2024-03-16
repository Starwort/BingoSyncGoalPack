using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class Get2Pylons : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Pylons);
        public override int difficultyTier => 14;
        public override string modifierText => "2";
        public override IList<string> synergyTypes => new[] {"ME.12"};
    }

    public class KillClothier : Goal {
        public override Item icon => Icons.Npc.Clothier;
        public override int difficultyTier => 14;
        public override Item? modifierIcon => Icons.Misc.Kill;
    }

    public class Get40Def : Goal {
        public override Item icon => ModContent.GetInstance<Icons.DefenceShield>().Item;
        public override int difficultyTier => 14;
        public override string modifierText => "40";
    }

    public class PetDog : Goal {
        public override Item icon => Icons.Npc.Dog;
        public override int difficultyTier => 14;
    }

    public class GetMoss : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.GlowingMosses);
        public override int difficultyTier => 14;
    }

    public class GetFountain : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Fountains);
        public override int difficultyTier => 14;
    }

    public class UpgradeSkull : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.ObsidianSkullUpgrades);
        public override int difficultyTier => 14;
    }
}