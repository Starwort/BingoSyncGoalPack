using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.Trackers;
using Terraria.GameContent.Tile_Entities;
using System;
using Terraria.DataStructures;

namespace BingoSyncGoalPack.Content.Goals {
    public class DownEoC : Goal {
        public override Item icon => new(ItemID.EyeofCthulhuTrophy);
        public override int difficultyTier => 0;
        public override IList<string> synergyTypes => ["ME.5.1", "ME.5.2"];

        class Tracker : PlayerAttackTracker {
            internal static Goal? goal = null;
            protected override void onKill(NPC target, NPC.HitInfo hit) {
                if (target.type == NPCID.EyeofCthulhu) {
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
    public class DownKS : Goal {
        public override Item icon => new(ItemID.KingSlimeTrophy);
        public override int difficultyTier => 0;
        public override IList<string> synergyTypes => ["ME.3.1", "ME.3.2"];

        class Tracker : PlayerAttackTracker {
            internal static Goal? goal = null;
            protected override void onKill(NPC target, NPC.HitInfo hit) {
                if (target.type == NPCID.KingSlime) {
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
    public class EatCookedFish : Goal {
        public override Item icon => new(ItemID.CookedFish);
        public override int difficultyTier => 0;

        class Tracker : ItemTracker {
            internal static Goal? goal = null;

            public override void OnConsumeItem(Item item, Player player) {
                if (item.type == ItemID.CookedFish) {
                    goal?.trigger(player);
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
    public class FillPiggyBank : Goal {
        public override Item icon => new(ItemID.PiggyBank);
        public override int difficultyTier => 0;
        public override string? progressTextFor(Player player) => player.GetModPlayer<Tracker>().progressText();

        class Tracker : PlayerTracker {
            internal static Goal? goal = null;

            int slotsLeft = 0;
            public string? progressText() => goal is null ? null : translate(
                "ProgressText.FillPiggyBank",
                slotsLeft.ToString()
            );

            public override void PostUpdate() {
                if (goal is null) {
                    return;
                }
                slotsLeft = 0;
                foreach (var item in Player.bank.item) {
                    if (item.stack == 0) {
                        slotsLeft++;
                    }
                }
                if (slotsLeft == 0) {
                    goal.trigger(Player);
                    goal = null;
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
    public class Get999OfTile : Goal {
        public override Item icon => Icons.Misc.Tiles;
        public override string modifierText => "999";
        public override int difficultyTier => 0;
        public override string? progressTextFor(Player player) => player.GetModPlayer<Tracker>().progressText();

        class Tracker : PlayerTracker {
            internal static Goal? goal = null;

            int bestStack = 0;
            public string? progressText() => goal is null ? null : translate(
                "ProgressText.Get999OfTile",
                bestStack.ToString()
            );

            public override void PostUpdate() {
                if (goal is null) {
                    return;
                }
                bestStack = 0;
                for (int i = 0; i < Player.inventory.Length; i++) {
                    var item = Player.inventory[i];
                    if (item.createTile != -1) {
                        if (item.stack >= 999) {
                            goal.trigger(Player);
                            goal = null;
                            return;
                        }
                        bestStack = Math.Max(item.stack, bestStack);
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
    public class PutFoodOnPlate : Goal {
        public override Item icon => new(ItemID.FoodPlatter);
        public override int difficultyTier => 0;

        class Tracker : TrackerSystem {
            internal static Goal? goal = null;
            public override void Load() {
                On_TEFoodPlatter.PlaceItemInFrame += onFoodPlace;
            }

            void onFoodPlace(On_TEFoodPlatter.orig_PlaceItemInFrame orig, Player player, int x, int y) {
                goal?.trigger(player);
                orig(player, x, y);
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class Suffocate7s : Goal {
        public override Item icon => Icons.Buff.Suffocation;
        public override int difficultyTier => 0;
        public override string modifierText => "7s";

        class Tracker : PlayerTracker {
            internal static Goal? goal = null;

            internal uint? suffocationStart = null;

            public override void PostUpdateBuffs() {
                if (goal is null) {
                    return;
                }
                foreach (var buff in Player.buffType) {
                    if (buff == BuffID.Suffocation) {
                        if (suffocationStart is null) {
                            suffocationStart = Main.GameUpdateCount;
                        } else {
                            var suffocationDuration = Main.GameUpdateCount - suffocationStart;
                            if (suffocationDuration % 60 == 0) {
                                var durInSecs = suffocationDuration / 60;
                                if (durInSecs < 7) {
                                    if (this.Player.whoAmI == Main.myPlayer) {
                                        goal.reportProgress((7 - durInSecs).ToString()!);
                                    }
                                } else {
                                    goal.trigger(Player);
                                    goal = null;
                                }
                            }
                        }
                        return;
                    }
                }
                suffocationStart = null;
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class DieToThorns : Goal {
        public override Item icon => ModContent.GetInstance<Icons.Thorns>().Item;
        public override int difficultyTier => 0;
        public override Item? modifierIcon => Icons.Misc.Die;

        class Tracker : PlayerTracker {
            internal static Goal? goal = null;
            internal bool aboutToTouchThorns = false;

            public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
                if (aboutToTouchThorns) {
                    goal?.trigger(Player);
                }
            }

            public override void Load() {
                On_Player.ApplyTouchDamage += detectDieToThorns;
            }

            private static void detectDieToThorns(On_Player.orig_ApplyTouchDamage orig, Player self, int tileId, int x, int y) {
                if (tileId == TileID.CorruptThorns || tileId == TileID.CrimsonThorns || tileId == TileID.JungleThorns || tileId == TileID.PlanteraThorns) {
                    self.GetModPlayer<Tracker>().aboutToTouchThorns = true;
                }
                orig(self, tileId, x, y);
                self.GetModPlayer<Tracker>().aboutToTouchThorns = false;
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
