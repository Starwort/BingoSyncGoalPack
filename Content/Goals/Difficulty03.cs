using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Icons;
using BingoBoardCore.Trackers;

namespace BingoSyncGoalPack.Content.Goals {
    public class KillAnglerWithBoulder : Goal {
        public override Item icon => Icons.Npc.Angler;
        public override int difficultyTier => 3;
        public override Item? modifierIcon => new(ItemID.Boulder);
    }
    public class Stack4BarsOnDungeon : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.LowTierBars);
        public override int difficultyTier => 3;
        public override string modifierText => "4";
        public override Item? modifierIcon => VanillaIcons.Bestiary.Dungeon;
    }
    public class WearCactusArmour : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.CactusHelmet,
            ItemID.CactusBreastplate,
            ItemID.CactusLeggings
        );
        public override int difficultyTier => 3;
    }
    public class GrowGemTree : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(
            ItemID.GemTreeAmberSeed,
            ItemID.GemTreeAmethystSeed,
            ItemID.GemTreeDiamondSeed,
            ItemID.GemTreeEmeraldSeed,
            ItemID.GemTreeRubySeed,
            ItemID.GemTreeSapphireSeed,
            ItemID.GemTreeTopazSeed
        );
        public override int difficultyTier => 3;
    }
    public class TrashSharkBait : Goal {
        public override Item icon => new(ItemID.SharkBait);
        public override int difficultyTier => 3;
        public override Item? modifierIcon => Icons.Misc.Trash;
    }
    public class FillHouseWithBars : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.AnyBars);
        public override int difficultyTier => 3;
        public override Item? modifierIcon => ModContent.GetInstance<Icons.House>().Item;
    }
    public class GetAllCampfires : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.PreHardmodeCampfires);
        public override int difficultyTier => 3;
        public override string modifierText => "9";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtainedCampfires, 9
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtainedCampfires = [];
            internal static Goal? goal = null;

            public override void prepare() {
                obtainedCampfires.Clear();
            }

            public override void onAnyObtain(Item item) {
                if (Sets.PreHardmodeCampfires.Contains(item.type)) {
                    obtainedCampfires.Add(item.type);
                    switch (obtainedCampfires.Count) {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            goal?.reportProgress(Player, item.Name, obtainedCampfires.Count.ToString());
                            break;
                        case 9:
                            goal?.trigger(Player);
                            break;
                    }
                }
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
}