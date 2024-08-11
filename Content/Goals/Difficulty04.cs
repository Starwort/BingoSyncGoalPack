using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Trackers;

namespace BingoSyncGoalPack.Content.Goals {
    public class DownEvilBoss : Goal {
        public override Item icon => Icons.Misc.EvilBoss;
        public override int difficultyTier => 4;
        public override IList<string> synergyTypes => ["ME.4.1", "ME.4.2"];
    }
    public class WearEvilArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.CrimsonHelmet,
            ItemID.CrimsonScalemail,
            ItemID.CrimsonGreaves,
            ItemID.ShadowHelmet,
            ItemID.ShadowScalemail,
            ItemID.ShadowGreaves
        );
        public override int difficultyTier => 4;
        public override IList<string> synergyTypes => ["ME.14"];
    }
    public class KillEvilCritter : Goal {
        public override Item icon => ModContent.GetInstance<Icons.EvilCritter>().Item;
        public override int difficultyTier => 4;
        public override Item? modifierIcon => Icons.Misc.Kill;
    }
    public class Sell100Hellstone : Goal {
        public override Item icon => new(ItemID.Hellstone);
        public override int difficultyTier => 4;
        public override Item? modifierIcon => Icons.Misc.Sell;
        public override string modifierText => "100";
        public override string? progressTextFor(Player player) => translate(
            "ProgressText.GenericCounter",
            player.GetModPlayer<Tracker>().sold.ToString(),
            "100"
        );

        class Tracker : PlayerTracker {
            internal int sold = 0;
            internal static Goal? goal = null;
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().sold = 0;
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class SellFlamingMace : Goal {
        public override Item icon => new(ItemID.FlamingMace);
        public override int difficultyTier => 4;
        public override Item? modifierIcon => Icons.Misc.Sell;
    }
}