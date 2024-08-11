using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;
using BingoBoardCore.Icons;
using BingoBoardCore.Trackers;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework;

namespace BingoSyncGoalPack.Content.Goals {
    public class CompleteFishingQuest : Goal {
        public override Item icon => VanillaIcons.Achievement.ServantInTraining;
        public override int difficultyTier => 2;
        public override string modifierText => "1";
        public override IList<string> synergyTypes => ["ME.11"];

        class Tracker : PlayerTracker {
            internal Goal? goal = null;

            public void onFishingQuestComplete() {
                if (goal is null) {
                    return;
                }
                goal.trigger(Player);
                goal = null;
            }

            public override void Load() {
                On_AchievementsHelper.HandleAnglerService += onFishingQuestComplete;
            }

            private static void onFishingQuestComplete(On_AchievementsHelper.orig_HandleAnglerService orig) {
                Main.LocalPlayer.GetModPlayer<Tracker>().onFishingQuestComplete();
                orig();
            }
        }

        public override void onGameStart(Player player) {
            Main.LocalPlayer.GetModPlayer<Tracker>().goal = this;
        }

        public override void onGameEnd(Player player) {
            Main.LocalPlayer.GetModPlayer<Tracker>().goal = null;
        }
    }
    public class Get3FrogLegs : Goal {
        public override Item icon => new(ItemID.SauteedFrogLegs);
        public override int difficultyTier => 2;
        public override string modifierText => "3";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().crafted, 3
        );

        class Tracker : ObtainedItemTracker {
            internal int crafted = 0;
            internal static Goal? goal = null;

            public override void onCraftItem(Item item) {
                if (item.type != ItemID.SauteedFrogLegs) {
                    return;
                }
                crafted++;
                if (crafted < 3) {
                    goal?.reportProgress(Player, crafted.ToString());
                } else {
                    goal?.trigger(Player);
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
    public class GetRockLobster : Goal {
        public override Item icon => new(ItemID.RockLobster);
        public override int difficultyTier => 2;

        class Tracker : ObtainedItemTracker {
            internal static Goal? goal = null;

            public override void onAnyObtain(Item item) {
                if (item.type == ItemID.RockLobster) {
                    goal?.trigger(Player);
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
    public class PlaceAllSandcastles : Goal {
        public override Item icon => new(ItemID.SandcastleBucket);
        public override int difficultyTier => 2;
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().placedVariants.Count, 4
        );

        class Tracker : PlayerTracker {
            internal static Goal? goal = null;
            internal HashSet<int> placedVariants = [];

            internal void onPlaceCastle(int sheetX) {
                var variant = sheetX / 3;
                var oldCount = placedVariants.Count;
                placedVariants.Add(variant);
                if (placedVariants.Count == 4) {
                    goal?.trigger(Player);
                } else if (placedVariants.Count != oldCount) {
                    goal?.reportProgress(Player, placedVariants.Count.ToString());
                }
            }
        }

        class PlacementTracker : GlobalTile {
            public override void PlaceInWorld(int i, int j, int type, Item item) {
                if (item.type != ItemID.SandcastleBucket) {
                    return;
                }
                var placedTile = Main.tile[i, j];
                if (!placedTile.HasTile || placedTile.TileType != TileID.Sandcastles) {
                    Main.NewText("WARN: placed sandcastle does not appear to exist!", Color.OrangeRed);
                    return;
                }
                Main.LocalPlayer.GetModPlayer<Tracker>().onPlaceCastle(placedTile.TileFrameX);
            }
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().placedVariants.Clear();
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class PlantAllHerbs : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.HerbSeeds);
        public override string modifierText => "7";
        public override int difficultyTier => 2;
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().planted, 7
        );

        class Tracker : PlayerTracker {
            internal HashSet<int> planted = [];
            internal static Goal? goal = null;

            internal void onPlant(Item item) {
                planted.Add(item.type);
                switch (planted.Count) {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        goal?.reportProgress(Player, item.Name, planted.Count.ToString());
                        break;
                    case 7:
                        goal?.trigger(Player);
                        break;
                }
            }
        }

        class PlacementTracker : GlobalTile {
            public override void PlaceInWorld(int i, int j, int type, Item item) {
                if (!Sets.HerbSeeds.Contains(item.type)) {
                    return;
                }
                var placedTile = Main.tile[i, j];
                if (!placedTile.HasTile) {
                    Main.NewText("WARN: placed herb does not appear to exist!", Color.OrangeRed);
                    return;
                }
                Main.LocalPlayer.GetModPlayer<Tracker>().onPlant(item);
            }
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().planted.Clear();
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class InvFullOfBlocks : Goal {
        public override Item icon => new(ItemID.FoodPlatter);
        public override int difficultyTier => 2;
        public override string? progressTextFor(Player player) => translate(
            "ProgressText.InvFullOfBlocks",
            player.GetModPlayer<Tracker>().uniqueBlocks.Count.ToString()
        );

        class Tracker : PlayerTracker {
            internal HashSet<int> uniqueBlocks = [];
            internal Goal? goal = null;

            public override void PostUpdate() {
                if (goal is null) {
                    return;
                }
                uniqueBlocks.Clear();
                for (int i = 0; i < 50; i++) {
                    if (Sets.Tiles.Contains(Player.inventory[i].type)) {
                        uniqueBlocks.Add(Player.inventory[i].type);
                    }
                }
                if (uniqueBlocks.Count == 50) {
                    goal.trigger(Player);
                    goal = null;
                }
            }
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().goal = this;
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }
    public class Have12Buffs : Goal {
        public override Item icon => Icons.Buff.Any;
        public override int difficultyTier => 2;
        public override string modifierText => "12";
        public override string? progressTextFor(Player player) => translate(
            "ProgressText.GenericCounter",
            player.GetModPlayer<Tracker>().activeBuffs.ToString(),
            modifierText
        );

        class Tracker : PlayerTracker {
            internal int activeBuffs = 0;
            internal Goal? goal = null;

            public override void PostUpdateBuffs() {
                if (goal is null) {
                    return;
                }
                activeBuffs = 0;
                foreach (var time in Player.buffTime) {
                    if (time != 0) {
                        activeBuffs++;
                    }
                }
                if (activeBuffs >= 12) {
                    goal.trigger(Player);
                    goal = null;
                }
            }
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().goal = this;
        }

        public override void onGameEnd(Player player) {
            player.GetModPlayer<Tracker>().goal = null;
        }
    }
    public class No5Villagers : Goal {
        public override Item icon => ModContent.GetInstance<Icons.House>().Item;
        public override int difficultyTier => 2;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => !isSharedWorld && mode != BingoMode.Lockout;
        //internal static int currentHousedNpcs = 0;
        //public override string? progressText() => translate(
        //    "ProgressText.No5Villagers",
        //    currentHousedNpcs.ToString()
        //);
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
        //internal static int currentHousedNpcs = 0;
        //public override string? progressText() => translate(
        //    "ProgressText.No5Villagers",
        //    currentHousedNpcs.ToString()
        //);
    }
}
