using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoSyncGoalPack.Content.Goals {
    public class GetGemCritterCage : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.GemCritterCages);
        public override int difficultyTier => 8;
    }
    public class Get99Seeds: Goal {
        public override Item icon => new(ItemID.Seed);
        public override int difficultyTier => 8;
        public override string modifierText => "99";
        internal static int obtainedSeeds = 0;
        public override string? progressText() => translate(
            "ProgressText.GenericCounter",
            obtainedSeeds.ToString(),
            modifierText
        );
    }
    public class HelpGolfer : Goal {
        public override Item icon => Icons.Npc.Golfer;
        public override int difficultyTier => 8;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => !isSharedWorld || mode == BingoMode.Lockout;
    }
    public class Get6Arrows : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Arrows);
        public override int difficultyTier => 8;
        public override string modifierText => "6";
        internal HashSet<int> obtained = new();
        public override string? progressText() => Util.progressTextFor(
            obtained,
            6
        );
    }
    public class GetSilverBullets : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.SilverBullet,
            ItemID.TungstenBullet
        );
        public override int difficultyTier => 8;
        internal HashSet<int> obtained = new();
        public override string? progressText() => Util.progressTextFor(
            obtained,
            2
        );
    }
    public class Get8Hooks : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Hooks);
        public override int difficultyTier => 8;
        public override string modifierText => "8";
        internal HashSet<int> obtained = new();
        public override string? progressText() => Util.progressTextFor(
            obtained,
            8
        );
    }
    public class Have5Debuffs : Goal {
        public override Item icon => Icons.Buff.AnyDebuff;
        public override int difficultyTier => 8;
        internal HashSet<int> obtained = new();
        public override string? progressText() => Util.progressTextFor(
            obtained,
            2
        );
    }
}