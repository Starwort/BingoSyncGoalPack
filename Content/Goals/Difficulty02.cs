using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoSyncGoalPack.Content.Goals {
    public class CompleteFishingQuest : Goal {
        public override Item icon => Icons.Misc.QuestFish;
        public override int difficultyTier => 2;
        public override string modifierText => "1";
        public override IList<string> synergyTypes => new[] {"ME.11"};
    }
    public class Get3FrogLegs : Goal {
        public override Item icon => new(ItemID.SauteedFrogLegs);
        public override int difficultyTier => 2;
        public override string modifierText => "3";
    }
    public class GetRockLobster : Goal {
        public override Item icon => new(ItemID.RockLobster);
        public override int difficultyTier => 2;
    }
    public class PlaceAllSandcastles : Goal {
        public override Item icon => new(ItemID.SandcastleBucket);
        public override int difficultyTier => 2;
    }
    public class PlantAllHerbs : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.HerbSeeds);
        public override string modifierText => "7";
        public override int difficultyTier => 2;
        internal static HashSet<int> planted = new();
        public override string? progressText() => Util.progressTextFor(
            planted, 7
        );
    }
    public class InvFullOfBlocks : Goal {
        public override Item icon => new(ItemID.FoodPlatter);
        public override int difficultyTier => 2;
        internal static int uniqueBlocks = 0;
        public override string? progressText() => translate(
            "ProgressText.InvFullOfBlocks",
            uniqueBlocks.ToString()
        );
    }
    public class Have12Buffs : Goal {
        public override Item icon => Icons.Buff.Any;
        public override int difficultyTier => 2;
        public override string modifierText => "12";
        internal static int activeBuffs = 0;
        public override string? progressText() => translate(
            "ProgressText.GenericCounter",
            activeBuffs.ToString(),
            modifierText
        );
    }
    public class No5Villagers : Goal {
        public override Item icon => ModContent.GetInstance<Icons.House>().Item;
        public override int difficultyTier => 2;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => !isSharedWorld && mode != BingoMode.Lockout;
        internal static int currentHousedNpcs = 0;
        public override string? progressText() => translate(
            "ProgressText.No5Villagers",
            currentHousedNpcs.ToString()
        );
        public override void onGameStart(Player player) {
            trigger(player);
        }
    }
    public class Opponent5Villagers : Goal {
        public override Item icon => ModContent.GetInstance<Icons.House>().Item;
        public override int difficultyTier => 2;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => !isSharedWorld && mode == BingoMode.Lockout && numPlayers == 2;
        internal static int currentHousedNpcs = 0;
        public override string? progressText() => translate(
            "ProgressText.No5Villagers",
            currentHousedNpcs.ToString()
        );
        public override void onGameStart(Player player) {
            trigger(player);
        }
    }
}
