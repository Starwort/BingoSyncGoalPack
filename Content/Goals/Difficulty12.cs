using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoSyncGoalPack.Content.Goals {
    public class WearNecroArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.NecroHelmet,
            ItemID.NecroBreastplate,
            ItemID.NecroGreaves
        );
        public override int difficultyTier => 12;
        public override IList<string> synergyTypes => ["ME.14"];
    }

    public class WearHeroHat : Goal {
        public override Item icon => new(ItemID.HerosHat);
        public override int difficultyTier => 12;
    }

    public class LavaBath : Goal {
        public override Item icon => new(ItemID.BottomlessLavaBucket);
        public override int difficultyTier => 12;
        public override string modifierText => "10s";
    }

    public class GetManaFlower : Goal {
        public override Item icon => new(ItemID.ManaFlower);
        public override int difficultyTier => 12;
    }

    public class NoTorches : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Torches);
        public override int difficultyTier => 12;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode != BingoMode.Lockout;
        public override IList<string> synergyTypes => ["ME.1"];
        public override void onGameStart(Player player) {
            trigger(player);
        }
    }

    public class OpponentTorches : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Torches);
        public override int difficultyTier => 12;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
        public override IList<string> synergyTypes => ["ME.1"];
    }

    public class PlaceArt : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Paintings);
        public override int difficultyTier => 12;
    }

    public class DownQB : Goal {
        public override Item icon => new(ItemID.QueenBeeTrophy);
        public override int difficultyTier => 12;
        public override IList<string> synergyTypes => ["ME.6.1", "ME.6.2"];
    }

    public class DownEoCMelee : Goal {
        public override Item icon => new(ItemID.EyeofCthulhuTrophy);
        public override int difficultyTier => 12;
        public override Item? modifierIcon => Icons.Misc.SwordOrSpear;
        public override IList<string> synergyTypes => ["ME.5.2"];
    }
}