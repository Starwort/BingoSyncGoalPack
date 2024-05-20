using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;
using BingoBoardCore.Icons;
using BingoBoardCore.Trackers;
using BingoSyncGoalPack.MonitorHooks;
using Terraria.DataStructures;
using System.Diagnostics;

namespace BingoSyncGoalPack.Content.Goals {
    public class Get2Spears : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Spears);
        public override int difficultyTier => 1;
        public override string modifierText => "2";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            ModContent.GetInstance<Tracker>().obtainedSpears(player), 2
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtainedSpears(Player player) => storage(player, () => new HashSet<int>());

            public override void onAnyObtain(Player player, Item item) {
                if (ItemID.Sets.Spears[item.type]) {
                    obtainedSpears(player).Add(item.type);
                }
            }
        }
    }
    public class Get2Plat : Goal {
        public override Item icon => new(ItemID.PlatinumCoin);
        public override int difficultyTier => 1;
        public override string modifierText => "2";

        class Tracker : PlayerTracker {
            internal bool enabled = false;
            internal static Goal? goal = null;

            public override void PostUpdate() {
                if (enabled) {
                    var platCoins = 0;
                    for (int i = 50; i < 54; i++) {
                        var stack = Player.inventory[i];
                        if (stack.type == ItemID.PlatinumCoin) {
                            platCoins += stack.stack;
                        }
                    }
                    if (platCoins >= 2) {
                        goal!.trigger(Player);
                        enabled = false;
                    }
                }
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
            player.GetModPlayer<Tracker>().enabled = true;
        }
    }
    public class DieToAltar : Goal {
        public override Item icon => ModContent.GetInstance<Icons.Altars>().Item;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Die;

        class AltarTracker : TrackerSystem {
            public override void Load() {
                On_Player.ItemCheck_UseMiningTools_ActuallyUseMiningTool += detectDieToAltar;
            }

            private void detectDieToAltar(On_Player.orig_ItemCheck_UseMiningTools_ActuallyUseMiningTool orig, Player self, Item sItem, out bool canHitWalls, int x, int y) {
                Tile tile = Main.tile[x, y];
                var player = self.GetModPlayer<DeathTracker>();
                if (tile.HasTile && Main.tileHammer[tile.TileType] && sItem.hammer > 0 && tile.TileType == TileID.DemonAltar) {
                    player.aboutToHitAltar = true;
                }
                orig(self, sItem, out canHitWalls, x, y);
                player.aboutToHitAltar = false;
            }
        }

        class DeathTracker : PlayerTracker {
            internal bool aboutToHitAltar = false;
            internal Goal? goal = null;

            public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
                if (aboutToHitAltar) {
                    goal!.trigger(Player);
                }
            }
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<DeathTracker>().goal = this;
        }
    }
    public class Equip5Accessories : Goal {
        public override Item icon => Icons.Misc.Accessories;
        public override int difficultyTier => 1;
        public override string modifierText => "5";
        public override IList<string> synergyTypes => ["ME.15"];
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            ModContent.GetInstance<Tracker>().wornAccessories(player), 5
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> wornAccessories(Player player) => storage(player, () => new HashSet<int>());
            internal static Goal? goal = null;

            public override void onEquipAccessory(Player player, Item acc) {
                var accs = wornAccessories(player);
                accs.Add(acc.type);
                if (accs.Count < 5 && player.whoAmI == Main.myPlayer) {
                    goal!.reportProgress(acc.Name);
                } else if (accs.Count >= 5) {
                    goal!.trigger(player);
                }
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }
    }
    public class GetModifiedWoodSwordBowHammer : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer);
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Craft;
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            ModContent.GetInstance<Tracker>().obtained(player), 3
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtained(Player player) => storage(player, () => new HashSet<int>());
            internal static Goal? goal = null;

            public override void onAnyObtain(Player player, Item item) {
                var items = obtained(player);
                if (item.type == ItemID.WoodenSword && item.prefix != 0) {
                    items.Add(item.type);
                    if (player.whoAmI == Main.myPlayer) {
                        goal!.reportProgress(item.AffixName());
                    }
                }
                if (item.type == ItemID.WoodenBow && item.prefix != 0) {
                    items.Add(item.type);
                    if (player.whoAmI == Main.myPlayer) {
                        goal!.reportProgress(item.AffixName());
                    }
                }
                if (item.type == ItemID.WoodenHammer && item.prefix != 0) {
                    items.Add(item.type);
                    if (player.whoAmI == Main.myPlayer) {
                        goal!.reportProgress(item.AffixName());
                    }
                }
                if (items.Count == 3) {
                    goal!.trigger(player);
                }
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }
    }
    public class ExplodeVillagerEnemySelf : Goal {
        public override Item icon => new(ItemID.ExplosiveBunny);
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Die;
        public override string modifierText => "3";
        internal static HashSet<string> killed = new();
        public override string? progressText() => Util.progressTextFor(
            killed, 3
        );
    }
    public class GetCookedMarshmallow : Goal {
        public override Item icon => new(ItemID.CookedMarshmallow);
        public override int difficultyTier => 1;

        class Tracker : ObtainedItemTracker {
            internal static Goal? goal = null;

            public override void onAnyObtain(Player player, Item item) {
                if (item.type == ItemID.CookedMarshmallow) {
                    goal!.trigger(player);
                }
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }
    }
    public class NoChopTrees : Goal {
        public override Item icon => VanillaIcons.Achievement.Timber;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode != BingoMode.Lockout;
        public override void onGameStart(Player player) {
            trigger(player);
        }
        public override IList<string> synergyTypes => ["ME.1"];
    }
    public class OpponentChopTrees : Goal {
        public override Item icon => VanillaIcons.Achievement.Timber;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
        public override IList<string> synergyTypes => ["ME.1"];
    }
}
