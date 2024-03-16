using BingoBoardCore.AnimationHelpers;
using System.Linq;
using Terraria.ID;
using Terraria;
using BingoSyncGoalPack.Content;
using BingoBoardCore.Icons;

namespace BingoSyncGoalPack.Icons {
    internal class Misc {
        public static readonly Item Die = BingoBoardCore.BingoBoardCore.dieIcon;
        public static readonly Item Disallow = BingoBoardCore.BingoBoardCore.disallowIcon;
        public static readonly Item Craft = new(ItemID.WorkBench);

        public static readonly Item Kill = new(ItemID.CopperShortsword);
        public static readonly Item Mine = new(ItemID.CopperPickaxe);
        public static readonly Item Trash = new(ItemID.TrashCan);
        public static readonly Item Sell = VanillaIcons.Bestiary.ItemSpawn;
        public static readonly Item SwordOrSpear = IconAnimationSystem.registerRandAnimation(
            Sets.Swords.Concat(Sets.Spears).ToArray()
        );

        public static readonly Item Tiles = IconAnimationSystem.registerRandAnimation(Sets.Tiles);
        public static readonly Item Accessories = IconAnimationSystem.registerRandAnimation(Sets.Accessories);
        public static readonly Item EvilBoss = IconAnimationSystem.registerCycleAnimation(ItemID.BrainofCthulhuTrophy, ItemID.EaterofWorldsTrophy);
        public static readonly Item QuestFish = IconAnimationSystem.registerRandAnimation(Sets.QuestFish);
        public static readonly Item Platforms = IconAnimationSystem.registerRandAnimation(Sets.Platforms);
        public static readonly Item SummonStaves = IconAnimationSystem.registerRandAnimation(Sets.SummonStaves);
    }
}
