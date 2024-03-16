using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Icons;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class FillEquipPage2 : Goal {
        public override Item icon => ModContent.GetInstance<Icons.FillEquipPage2>().Item;
        public override int difficultyTier => 16;
    }

    public class Get5Toilets : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Toilets);
        public override int difficultyTier => 16;
        public override string modifierText => "5";
    }

    public class GetBINGO : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.AlphabetStatueB,
            ItemID.AlphabetStatueI,
            ItemID.AlphabetStatueN,
            ItemID.AlphabetStatueG,
            ItemID.AlphabetStatueO
        );
        public override int difficultyTier => 16;
    }

    public class KillWithSandgun : Goal {
        public override Item icon => new(ItemID.Sandgun);
        public override int difficultyTier => 16;
    }

    public class Get99Anvils : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Anvils);
        public override int difficultyTier => 16;
        public override string modifierText => "99";
    }

    public class GetTongued : Goal {
        public override Item icon => Icons.Buff.TheTongue;
        public override int difficultyTier => 16;
        public override IList<string> synergyTypes => new[] {"ME.8.1"};
    }

    public class Hellevator : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            VanillaIcons.Achievement.IntoOrbit.type,
            VanillaIcons.Achievement.RockBottom.type
        );
        public override int difficultyTier => 16;
    }
}