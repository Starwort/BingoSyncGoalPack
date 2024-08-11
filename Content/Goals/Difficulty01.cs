using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;
using BingoBoardCore.Icons;
using BingoBoardCore.Trackers;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;

namespace BingoSyncGoalPack.Content.Goals {
    public class Get2Spears : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.Spears);
        public override int difficultyTier => 1;
        public override string modifierText => "2";
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtainedSpears, 2
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtainedSpears = [];
            internal static Goal? goal = null;

            public override void prepare() {
                obtainedSpears.Clear();
            }

            public override void onAnyObtain(Item item) {
                if (ItemID.Sets.Spears[item.type]) {
                    obtainedSpears.Add(item.type);
                    switch (obtainedSpears.Count) {
                        case 1:
                            goal?.reportProgress(Player, item.Name);
                            break;
                        case 2:
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
    public class Get2Plat : Goal {
        public override Item icon => new(ItemID.PlatinumCoin);
        public override int difficultyTier => 1;
        public override string modifierText => "2";

        class Tracker : PlayerTracker {
            internal bool enabled = false;
            internal static Goal? goal = null;

            public override void PostUpdate() {
                if (enabled && goal is not null) {
                    var platCoins = 0;
                    for (int i = 50; i < 54; i++) {
                        var stack = Player.inventory[i];
                        if (stack.type == ItemID.PlatinumCoin) {
                            platCoins += stack.stack;
                        }
                    }
                    if (platCoins >= 2) {
                        goal?.trigger(Player);
                        enabled = false;
                    }
                }
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
            player.GetModPlayer<Tracker>().enabled = true;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
            player.GetModPlayer<Tracker>().enabled = false;
        }
    }
    public class DieToAltar : Goal {
        public override Item icon => ModContent.GetInstance<Icons.Altars>().Item;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Die;

        class Tracker : PlayerTracker {
            internal bool aboutToHitAltar = false;
            internal static Goal? goal = null;

            public override void Load() {
                On_Player.ItemCheck_UseMiningTools_ActuallyUseMiningTool += detectDieToAltar;
            }

            public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
                if (aboutToHitAltar) {
                    goal?.trigger(Player);
                }
            }

            private static void detectDieToAltar(On_Player.orig_ItemCheck_UseMiningTools_ActuallyUseMiningTool orig, Player self, Item sItem, out bool canHitWalls, int x, int y) {
                Tile tile = Main.tile[x, y];
                var player = self.GetModPlayer<Tracker>();
                if (tile.HasTile && Main.tileHammer[tile.TileType] && sItem.hammer > 0 && tile.TileType == TileID.DemonAltar) {
                    player.aboutToHitAltar = true;
                }
                orig(self, sItem, out canHitWalls, x, y);
                player.aboutToHitAltar = false;
            }
        }

        public override void onGameStart(Player player) {
            Tracker.goal = this;
        }

        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class Equip5Accessories : Goal {
        public override Item icon => Icons.Misc.Accessories;
        public override int difficultyTier => 1;
        public override string modifierText => "5";
        public override IList<string> synergyTypes => ["ME.15"];
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().wornAccs, 5
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> wornAccs = [];
            internal static Goal? goal = null;

            public override void onEquipAccessory(Item acc) {
                wornAccs.Add(acc.type);
                if (wornAccs.Count < 5) {
                    goal?.reportProgress(Player, acc.Name);
                } else if (wornAccs.Count >= 5) {
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
    public class GetModifiedWoodSwordBowHammer : Goal {
        public override Item icon => IconAnimationSystem.registerCycleAnimation(ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer);
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Craft;
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().obtained, 3
        );

        class Tracker : ObtainedItemTracker {
            internal HashSet<int> obtained = [];
            internal static Goal? goal = null;

            public override void onAnyObtain(Item item) {
                if (item.type == ItemID.WoodenSword && item.prefix != 0) {
                    obtained.Add(item.type);
                    goal?.reportProgress(Player, item.AffixName());
                }
                if (item.type == ItemID.WoodenBow && item.prefix != 0) {
                    obtained.Add(item.type);
                    goal?.reportProgress(Player, item.AffixName());
                }
                if (item.type == ItemID.WoodenHammer && item.prefix != 0) {
                    obtained.Add(item.type);
                    goal?.reportProgress(Player, item.AffixName());
                }
                if (obtained.Count == 3) {
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
    public class ExplodeVillagerEnemySelf : Goal {
        public override Item icon => new(ItemID.ExplosiveBunny);
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Die;
        public override string modifierText => "3";
        internal static HashSet<string> killed = [];
        public override string? progressTextFor(Player player) => Util.progressTextFor(
            player.GetModPlayer<Tracker>().killed, 3
        );

        class Tracker : PlayerTracker {
            internal HashSet<string> killed = [];
            internal static Goal? goal = null;

            internal void blownUp(string kind) {
                kind = "Progress.ExplodeVillagerEnemySelf." + kind;
                this.killed.Add(kind);
                goal?.reportProgress(Player, kind);
                if (killed.Count == 3) {
                    goal?.trigger(Player);
                }
            }

            public override void OnHitByProjectile(Projectile proj, Player.HurtInfo hurtInfo) {
                if (proj.owner == Player.whoAmI && proj.type == ProjectileID.ExplosiveBunny && Player.dead) {
                    this.blownUp("Self");
                }
            }
        }

        class KillTracker : NpcTracker {
            public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone) {
                if (
                    projectile.type == ProjectileID.ExplosiveBunny
                    && npc.life <= 0
                    && npc.lastInteraction != 255
                    && (!npc.friendly || npc.townNPC)
                ) {
                    Main.player[npc.lastInteraction].GetModPlayer<Tracker>().blownUp(npc.townNPC ? "Villager" : "Enemy");
                }
            }
        }

        public override void onGameStart(Player player) {
            player.GetModPlayer<Tracker>().killed.Clear();
            Tracker.goal = this;
        }
        public override void onGameEnd(Player player) {
            Tracker.goal = null;
        }
    }
    public class GetCookedMarshmallow : Goal {
        public override Item icon => new(ItemID.CookedMarshmallow);
        public override int difficultyTier => 1;

        class Tracker : ObtainedItemTracker {
            internal static Goal? goal = null;

            public override void onAnyObtain(Item item) {
                if (item.type == ItemID.CookedMarshmallow) {
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

        public override void Load() {
            AchievementsHelper.OnTileDestroyed += this.checkGoalFailed;
        }

        private void checkGoalFailed(Player player, ushort tileId) {
            if (TileID.Sets.IsATreeTrunk[tileId]) {
                untrigger(player);
            }
        }
    }
    public class OpponentChopTrees : Goal {
        public override Item icon => VanillaIcons.Achievement.Timber;
        public override int difficultyTier => 1;
        public override Item? modifierIcon => Icons.Misc.Disallow;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => mode == BingoMode.Lockout && numPlayers == 2;
        public override IList<string> synergyTypes => ["ME.1"];

        public override void Load() {
            AchievementsHelper.OnTileDestroyed += this.checkGoalFailed;
        }

        private void checkGoalFailed(Player player, ushort tileId) {
            if (TileID.Sets.IsATreeTrunk[tileId]) {
                foreach (var otherPlayer in Main.player) {
                    if (otherPlayer.active && otherPlayer.team != player.team) {
                        trigger(otherPlayer);
                        return;
                    }
                }
            }
        }
    }
}
