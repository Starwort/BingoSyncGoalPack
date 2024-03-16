using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoSyncGoalPack.Content.Goals {
    public class NoTraps : Goal {
        public override Item icon => Icons.Buff.Dangersense;
        public override int difficultyTier => 18;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode != BingoMode.Lockout;
        public override IList<string> synergyTypes => new[] {"ME.9", "ME.10", "ME.1"};
        public override void onGameStart(Player player) {
            trigger(player);
        }
    }

    public class OpponentTraps : Goal {
        public override Item icon => Icons.Buff.Dangersense;
        public override int difficultyTier => 18;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
        public override IList<string> synergyTypes => new[] {"ME.9", "ME.10", "ME.1"};
    }

    public class GetLightRedItem : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.LightRedItems);
        public override int difficultyTier => 18;
    }

    public class GetVoidStorage : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.VoidVault,
            ItemID.VoidLens
        );
        public override int difficultyTier => 18;
    }

    public class Have5Minions : Goal {
        public override Item icon => Icons.Misc.SummonStaves;
        public override int difficultyTier => 18;
        public override string modifierText => "5";
        public override IList<string> synergyTypes => new[] {"ME.6.1"};
    }

    public class GetPhaseblade : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Phaseblades);
        public override int difficultyTier => 18;
        public override IList<string> synergyTypes => new[] {"ME.13"};
    }

    public class GetPhoenixBlaster : Goal {
        public override Item icon => new(ItemID.PhoenixBlaster);
        public override int difficultyTier => 18;
    }

    public class Loot3ShadowChests : Goal {
        public override Item icon => new(ItemID.ShadowChest);
        public override int difficultyTier => 18;
        public override string modifierText => "3";
    }
}