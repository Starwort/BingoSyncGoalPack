using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Icons;

namespace BingoSyncGoalPack.Content.Goals {
    public class DownEoCHell : Goal {
        public override Item icon => new(ItemID.EyeofCthulhuTrophy);
        public override int difficultyTier => 17;
        public override Item? modifierIcon => VanillaIcons.Bestiary.Hell;
        public override IList<string> synergyTypes => new[] {"ME.5.1"};
    }

    public class DownWoF : Goal {
        public override Item icon => new(ItemID.WallofFleshTrophy);
        public override int difficultyTier => 17;
        public override IList<string> synergyTypes => new[] {"ME.8.1", "ME.8.2"};
    }

    public class DownSkeleJungle : Goal {
        public override Item icon => new(ItemID.SkeletronTrophy);
        public override int difficultyTier => 17;
        public override Item? modifierIcon => VanillaIcons.Bestiary.Jungle;
        public override IList<string> synergyTypes => new[] {"ME.7.1"};
    }

    public class DownQBLowMaxLife : Goal {
        public override Item icon => new(ItemID.QueenBeeTrophy);
        public override int difficultyTier => 17;
        public override Item? modifierIcon => VanillaIcons.Achievement.HeartBreaker;
        public override IList<string> synergyTypes => new[] {"ME.6.1"};
    }

    public class DownEoCQB : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.EyeofCthulhuTrophy,
            ItemID.QueenBeeTrophy
        );
        public override int difficultyTier => 17;
        public override Item? modifierIcon => IconAnimationSystem.registerCycleAnimation(
            ItemID.QueenBeeTrophy,
            ItemID.EyeofCthulhuTrophy
        );
        public override IList<string> synergyTypes => new[] {"ME.5.1", "ME.6.1"};
    }

    public class DownEvilBossUpsideDown : Goal {
        public override Item icon => Icons.Misc.EvilBoss;
        public override int difficultyTier => 17;
        public override Item? modifierIcon => new(ItemID.GravitationPotion);
        public override IList<string> synergyTypes => new[] {"ME.4.1"};
    }
}