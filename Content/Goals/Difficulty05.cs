using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Trackers;

namespace BingoSyncGoalPack.Content.Goals {
    public class BreakLivingTreeLeaves : Goal {
        public override Item icon => ModContent.GetInstance<Icons.LivingLeaf>().Item;
        public override int difficultyTier => 5;
        public override Item? modifierIcon => Icons.Misc.Mine;
    }
    public class EatGrubSoup : Goal {
        public override Item icon => new(ItemID.GrubSoup);
        public override int difficultyTier => 5;
    }
    public class Get4CritterContainers : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.CritterCages);
        public override int difficultyTier => 5;
        public override string modifierText => "4";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtainedCages,
            4
        );

        class Tracker : ObtainedItemTracker {
        internal HashSet<int> obtainedCages = [];
            internal static Goal? goal = null;

            public override void prepare() {
                obtainedCages.Clear();
            }

            public override void onAnyObtain(Item item) {
                if (Sets.CritterCages.Contains(item.type)) {
                    obtainedCages.Add(item.type);
                    switch (obtainedCages.Count) {
                        case 1:
                        case 2:
                        case 3:
                            goal?.reportProgress(Player, obtainedCages.Count.ToString());
                            break;
                        case 4:
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
    public class GetLemonadeOrAppleJuice : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(ItemID.Lemonade, ItemID.AppleJuice);
        public override int difficultyTier => 5;
        public override Item? modifierIcon => Icons.Misc.Craft;
    }
    public class VanityWinnerSet : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(
            ItemID.PlaguebringerHelmet,
            ItemID.PlaguebringerChestplate,
            ItemID.PlaguebringerGreaves,
            ItemID.RoninHat,
            ItemID.RoninShirt,
            ItemID.RoninPants,
            ItemID.TimelessTravelerHood,
            ItemID.TimelessTravelerRobe,
            ItemID.TimelessTravelerBottom,
            ItemID.FloretProtectorHelmet,
            ItemID.FloretProtectorChestplate,
            ItemID.FloretProtectorLegs,
            ItemID.CapricornMask,
            ItemID.CapricornChestplate,
            ItemID.CapricornLegs,
            ItemID.CapricornTail,
            ItemID.TVHeadMask,
            ItemID.TVHeadSuit,
            ItemID.TVHeadPants
        );
        public override int difficultyTier => 5;
    }
    public class Get4Shrooms : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.Mushrooms);
        public override int difficultyTier => 5;
        public override string modifierText => "4";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtainedShrooms,
            4
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtainedShrooms = [];
            internal static Goal? goal = null;

            public override void prepare() {
                obtainedShrooms.Clear();
            }

            public override void onAnyObtain(Item item) {
                if (Sets.Mushrooms.Contains(item.type)) {
                    obtainedShrooms.Add(item.type);
                    switch (obtainedShrooms.Count) {
                        case 1:
                        case 2:
                        case 3:
                            goal?.reportProgress(Player,  obtainedShrooms.Count.ToString());
                            break;
                        case 4:
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
    public class Get3Watches : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.Watches);
        public override int difficultyTier => 5;
        public override string modifierText => "3";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtainedWatches,
            3
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtainedWatches = [];
            internal static Goal? goal = null;

            public override void prepare() {
                obtainedWatches.Clear();
            }

            public override void onAnyObtain(Item item) {
                if (Sets.Watches.Contains(item.type)) {
                    obtainedWatches.Add(item.type);
                    switch (obtainedWatches.Count) {
                        case 1:
                        case 2:
                            goal?.reportProgress(Player, obtainedWatches.Count.ToString());
                            break;
                        case 3:
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
    public class GetTrash : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(Sets.FishingTrash);
        public override int difficultyTier => 5;
        public override string modifierText => "3";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtainedJunk,
            3
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtainedJunk = [];
            internal static Goal? goal = null;

            public override void prepare() {
                obtainedJunk.Clear();
            }

            public override void onAnyObtain(Item item) {
                if (Sets.FishingTrash.Contains(item.type)) {
                    obtainedJunk.Add(item.type);
                    switch (obtainedJunk.Count) {
                        case 1:
                        case 2:
                            goal?.reportProgress(Player, obtainedJunk.Count.ToString());
                            break;
                        case 3:
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