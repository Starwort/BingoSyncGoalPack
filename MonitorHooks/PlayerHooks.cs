using Microsoft.Xna.Framework;
using System.Collections.Generic;
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

        int fishingQuestsComplete;
        internal void onFishingQuestComplete() {
            fishingQuestsComplete++;
            switch (fishingQuestsComplete) {
                case 1:
                    trigger("CompleteFishingQuest");
                    progress("Complete2FishingQuests");
                    progress("Complete3FishingQuests", "1");
                    break;
                case 2:
                    trigger("Complete2FishingQuests");
                    progress("Complete3FishingQuests", "2");
                    break;
                case 3:
                    trigger("Complete3FishingQuests");
                    break;
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
        internal bool achievedInvFullOfBlocks;
        internal bool achievedFillPiggyBank;
        public override void PostUpdate() {
            if (!achievedGet999OfTile || !achievedInvFullOfBlocks) {
                var foundTiles = new HashSet<int>();
                for (int i = 0; i < Player.inventory.Length; i++) {
                    var item = Player.inventory[i];
                    if (item.createTile != -1) {
                        if (item.stack >= 999) {
                            trigger("Get999OfTile");
                            achievedGet999OfTile = true;
                            break;
                        }
                        if (i < 50) {
                            foundTiles.Add(item.type);
                        }
                    }
                }
                if (foundTiles.Count == 50) {
                    trigger("InvFullOfBlocks");
                    achievedInvFullOfBlocks = true;
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
            onAnyObtain(item);
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

        internal HashSet<int> collectedSpears = new();
        private void onAnyObtain(Item item) {
            if (ItemID.Sets.Spears[item.type]) {
                collectedSpears.Add(item.type);
                if (collectedSpears.Count <= 2) {
                    progress("Get2Spears", item.Name);
                }
                if (collectedSpears.Count == 2) {
                    trigger("Get2Spears");
                }
            }
            if (item.type == ItemID.CookedMarshmallow) {
                trigger("GetCookedMarshmallow");
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
        internal bool achievedHave12Buffs;
        internal bool achievedHave5Debuffs;
        public override void PostUpdateBuffs() {
            bool foundSuffocation = false;
            var foundBuffs = 0;
            var foundDebuffs = 0;
            foreach (var buffType in this.Player.buffType) {
                if (buffType == 0) {
                    continue;
                }
                foundBuffs++;
                if (Main.debuff[buffType]) {
                    foundDebuffs++;
                }
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
            if (foundBuffs >= 12 && !achievedHave12Buffs) {
                trigger("Have12Buffs");
                achievedHave12Buffs = true;
            }
            if (foundDebuffs >= 5 && !achievedHave5Debuffs) {
                trigger("Have5Debuffs");
                achievedHave5Debuffs = true;
            }
            if (!foundSuffocation) {
                suffocationStartTime = null;
            }
        }

        internal string? lastArmourSet;

        internal void updateArmourSet(string set) {
            if (set != lastArmourSet) {
                this.lastArmourSet = set;
                switch (set) {
                    case "cactus":
                        trigger("WearCactusArmour");
                        break;
                    case "evil":
                        trigger("WearEvilArmour");
                        break;
                    case "pumpkin":
                        trigger("WearPumpkinArmour");
                        break;
                    case "fossil":
                        trigger("WearFossilArmour");
                        break;
                    case "necro":
                        trigger("WearNecroArmour");
                        break;
                }
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

        public override bool OnPickup(Item item) {
            onAnyObtain(item);
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
            achievedInvFullOfBlocks = false;
            achievedFillPiggyBank = false;
            achievedHave12Buffs = false;
            achievedHave5Debuffs = false;
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
