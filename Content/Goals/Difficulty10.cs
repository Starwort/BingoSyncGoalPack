using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class MakePiano : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.CraftablePianos);
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Craft;
    }

    public class ThrowBonesAtTargetDummy : Goal {
        public override Item icon => new(ItemID.Bone);
        public override int difficultyTier => 10;
        public override Item? modifierIcon => new(ItemID.TargetDummy);
        public override string modifierText => "35";
    }

    public class DownSkele : Goal {
        public override Item icon => new(ItemID.SkeletronTrophy);
        public override int difficultyTier => 10;
        public override IList<string> synergyTypes => new[] {"ME.7.1", "ME.7.2"};
    }

    public class NoEquipAccessories : Goal {
        public override Item icon => Icons.Misc.Accessories;
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override IList<string> synergyTypes => new[] {"ME.1", "ME.15"};
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode != BingoMode.Lockout;
        public override void onGameStart(Player player) {
            trigger(player);
        }
    }

    public class OpponentEquipAccessories : Goal {
        public override Item icon => Icons.Misc.Accessories;
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override IList<string> synergyTypes => new[] {"ME.1", "ME.15"};
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
    }

    public class NoPlatforms : Goal {
        public override Item icon => Icons.Misc.Platforms;
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override IList<string> synergyTypes => new[] {"ME.1"};
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode != BingoMode.Lockout;
        public override void onGameStart(Player player) {
            trigger(player);
        }
    }

    public class OpponentPlatforms : Goal {
        public override Item icon => Icons.Misc.Platforms;
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override IList<string> synergyTypes => new[] {"ME.1"};
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
    }

    public class GetAnnouncementBox : Goal {
        public override Item icon => new(ItemID.AnnouncementBox);
        public override int difficultyTier => 10;
    }

    public class TrashDungeonWeapon : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.DungeonWeapons);
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Trash;
    }

    public class TrashWaterBolt : Goal {
        public override Item icon => new(ItemID.WaterBolt);
        public override int difficultyTier => 10;
        public override Item? modifierIcon => Icons.Misc.Trash;
    }
}