using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class Get2Spears : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Spears);
        public override int difficultyTier => 1;
        public override string modifierText => "2";
        internal static HashSet<int> collectedSpears = new();
        public override string? progressText() => Util.progressTextFor(
            collectedSpears, 2
        );
    }
    public class Get2Plat : Goal {
        public override Item icon => new(ItemID.PlatinumCoin);
        public override int difficultyTier => 1;
        public override string modifierText => "2";
        internal static int availableMoney = 0;
        public override string? progressText() =>  translate(
            "ProgressText.Get2Plat",
            (availableMoney % 100).ToString(), // copper
            (availableMoney / 100 % 100).ToString(), // silver
            (availableMoney / 100_00 % 100).ToString(), // gold
            (availableMoney / 100_00_00).ToString() // plat
        );
    }
    public class DieToAltar : Goal {
        public override Item icon => ModContent.GetInstance<Icons.Altars>().Item;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Die;
    }
    public class Equip5Accessories : Goal {
        public override Item icon => Icons.Misc.Accessories;
        public override int difficultyTier => 1;
        public override string modifierText => "5";
        public override IList<string> synergyTypes => new[] {"ME.15"};
        internal static HashSet<int> wornAccessories = new();
        public override string? progressText() => Util.progressTextFor(
            wornAccessories, 5
        );
    }
    public class GetModifiedWoodSwordBowHammer : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer);
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Craft;
        internal static HashSet<int> obtained = new();
        public override string? progressText() => Util.progressTextFor(
            obtained, 3
        );
    }
    public class ExplodeVillagerEnemySelf : Goal {
        public override Item icon => new(ItemID.ExplosiveBunny);
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Die;
        public override string modifierText => "3";
        internal static HashSet<string> killed = new();
        public override string? progressText() => Util.progressTextFor(
            killed, 3
        );
    }
    public class GetCookedMarshmallow : Goal {
        public override Item icon => new(ItemID.CookedMarshmallow);
        public override int difficultyTier => 1;
    }
    public class NoChopTrees : Goal {
        public override Item icon => Icons.Achievement.Timber;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode != BingoMode.Lockout;
        public override void onGameStart(Player player) {
            trigger(player);
        }
        public override IList<string> synergyTypes => new[] {"ME.1"};
    }
    public class OpponentChopTrees : Goal {
        public override Item icon => Icons.Achievement.Timber;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
        public override IList<string> synergyTypes => new[] {"ME.1"};
    }
}
