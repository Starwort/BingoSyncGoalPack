using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.MonitorHooks {
    public class PlayerHooks : ModPlayer {
        public PlayerHooks() : base() {
            reset();
        }

        void trigger(string goal) {
            triggerGoal(goal, Player);
        }
        void failDisallow(string commonGoalSuffix) {
            untriggerGoal("No" + commonGoalSuffix, Player);
            Player? otherTeamPlayer = null;
            foreach (var player in Main.player) {
                if (player.team != this.Player.team) {
                    if (otherTeamPlayer is not null && otherTeamPlayer.team != player.team) {
                        return; // found at least 2 other teams
                    }
                    otherTeamPlayer = player;
                }
            }
            if (otherTeamPlayer is not null) {
                triggerGoal("Opponent" + commonGoalSuffix, otherTeamPlayer);
            }
        }

        void processHitNPC(NPC target, NPC.HitInfo hit) {
            if (target.type == NPCID.EyeofCthulhu) {
                if (target.life <= 0) {
                    trigger("DownEoC");
                }
            } else if (target.type == NPCID.KingSlime) {
                if (target.life <= 0) {
                    trigger("DownKS");
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            processHitNPC(target, hit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone) {
            processHitNPC(target, hit);
        }

        internal bool achievedGet999OfTile;
        internal bool achievedFillPiggyBank;
        public override void PostUpdate() {
            if (!achievedGet999OfTile) {
                foreach (var item in Player.inventory) {
                    if (item.createTile != -1 && item.stack >= 999) {
                        trigger("Get999OfTile");
                        achievedGet999OfTile = true;
                        break;
                    }
                }
            }
            if (!achievedFillPiggyBank) {
                var wasFull = true;
                foreach (var item in Player.bank.item) {
                    if (item.stack == 0) {
                        wasFull = false;
                        break;
                    }
                }
                if (wasFull) {
                    trigger("FillPiggyBank");
                    achievedFillPiggyBank = true;
                }
            }
        }

        internal bool craftedWoodSword = false;
        internal bool craftedWoodBow = false;
        internal bool craftedWoodHammer = false;
        internal void onCraftItem(Item item) {
            if (!craftedWoodSword && item.type == ItemID.WoodenSword && item.prefix != 0) {
                craftedWoodSword = true;
                if (craftedWoodBow && craftedWoodHammer) {
                    trigger("GetModifiedWoodSwordBowHammer");
                } else {
                    progress("GetModifiedWoodSwordBowHammer", item.AffixName());
                }
            }
            if (!craftedWoodBow && item.type == ItemID.WoodenBow && item.prefix != 0) {
                craftedWoodBow = true;
                if (craftedWoodSword && craftedWoodHammer) {
                    trigger("GetModifiedWoodSwordBowHammer");
                } else {
                    progress("GetModifiedWoodSwordBowHammer", item.AffixName());
                }
            }
            if (!craftedWoodHammer && item.type == ItemID.WoodenHammer && item.prefix != 0) {
                craftedWoodHammer = true;
                if (craftedWoodSword && craftedWoodBow) {
                    trigger("GetModifiedWoodSwordBowHammer");
                } else {
                    progress("GetModifiedWoodSwordBowHammer", item.AffixName());
                }
            }
        }

        internal HashSet<int> usedAccs = new();
        public void onEquipAccessory(Item acc) {
            if (usedAccs.Contains(acc.type)) {
                return;
            }
            usedAccs.Add(acc.type);
            if (usedAccs.Count == 1) {
                failDisallow("EquipAccessories");
            }
            if (usedAccs.Count < 5) {
                progress("Equip5Accessories", acc.Name);
            } else if (usedAccs.Count == 5) {
                trigger("Equip5Accessories");
            }
        }

        internal uint? suffocationStartTime = null;

        public override void PostUpdateBuffs() {
            bool foundSuffocation = false;
            foreach (var buffType in this.Player.buffType) {
                if (buffType == BuffID.Suffocation) {
                    foundSuffocation = true;
                    if (suffocationStartTime is null) {
                        suffocationStartTime = Main.GameUpdateCount;
                    } else {
                        var suffocationDuration = Main.GameUpdateCount - suffocationStartTime;
                        if (suffocationDuration % 60 == 0) {
                            var durInSecs = suffocationDuration / 60;
                            if (durInSecs < 7) {
                                if (this.Player.whoAmI == Main.myPlayer) {
                                    progress("Suffocate7s", (7 - durInSecs).ToString()!);
                                }
                            } else if (durInSecs == 7) {
                                trigger("Suffocate7s");
                            }
                        }
                    }
                }
            }
            if (!foundSuffocation) {
                suffocationStartTime = null;
            }
        }

        public override void OnHurt(Player.HurtInfo info) {
            var source = info.DamageSource;
            PopupText.NewText(new AdvancedPopupRequest() {
                Text = $"Damage: {source.SourceCustomReason} / {source.SourceOtherIndex} / {source.SourceItem}",
                Velocity = -7 * Vector2.UnitY,
                Color = Color.Red,
                DurationInFrames = 60,
            }, this.Player.Center);
        }

        internal string? lastArmourSet;

        internal void updateArmourSet(string set) {
            if (set != lastArmourSet) {
                this.lastArmourSet = set;
                PopupText.NewText(new AdvancedPopupRequest() {
                    Text = $"Armour set: {set}",
                    Velocity = -7 * Vector2.UnitY,
                    Color = Color.White,
                    DurationInFrames = 60,
                }, this.Player.Center);
            }
        }

        internal bool aboutToTouchThorns = false;
        internal bool aboutToHitAltar = false;
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
            if (aboutToTouchThorns) {
                trigger("DieToThorns");
            } else if (aboutToHitAltar) {
                trigger("DieToAltar");
            }
        }

        internal HashSet<int> collectedSpears = new();
        public override bool OnPickup(Item item) {
            if (ItemID.Sets.Spears[item.type]) {
                collectedSpears.Add(item.type);
                if (collectedSpears.Count <= 2) {
                    progress("Get2Spears", item.Name);
                }
                if (collectedSpears.Count == 2) {
                    trigger("Get2Spears");
                }
            }
            if (item.type == ItemID.CopperCoin || item.type == ItemID.SilverCoin || item.type == ItemID.GoldCoin || item.type == ItemID.PlatinumCoin) {
                var foundPlat = 0;
                foreach (var slot in this.Player.inventory) {
                    if (slot.type == ItemID.PlatinumCoin) {
                        foundPlat += slot.stack;
                    }
                }
                if (foundPlat >= 2) {
                    trigger("Get2Plat");
                }
            }
            return true;
        }

        internal void reset() {
            achievedGet999OfTile = false;
            achievedFillPiggyBank = false;
            collectedSpears.Clear();
            usedAccs.Clear();
            craftedWoodSword = false;
            craftedWoodBow = false;
            craftedWoodHammer = false;
        }

        internal void onGameStart() {
            reset();
            trigger("NoChopTrees");
            trigger("NoEquipAccessories");
            trigger("NoPlatforms");
            trigger("NoTorches");
            trigger("NoTraps");
            trigger("NoGrapple");
        }
    }
}
