using BingoBoardCore.Common;
using BingoGoalPackBingoSyncGoals.Content.Goals;
using System;
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

        void update<T>(ref T dest, T src) {
            if (Player.whoAmI == Main.myPlayer) {
                dest = src;
            }
        }

        void trigger<T>() where T : Goal {
            ModContent.GetInstance<T>().trigger(Player);
        }
        void progress<T>(params string[] substitutions) where T : Goal {
            if (Player.whoAmI == Main.myPlayer) {
            ModContent.GetInstance<T>().reportProgress(substitutions);
            }
        }
        void badProgress<T>(params string[] substitutions) where T : Goal {
            if (Player.whoAmI == Main.myPlayer) {
                ModContent.GetInstance<T>().reportBadProgress(substitutions);
            }
        }

        void failDisallow<NoGoal, OpponentGoal>()
            where NoGoal: Goal
            where OpponentGoal : Goal
        {
            ModContent.GetInstance<NoGoal>().untrigger(Player);
            foreach (var player in Main.player) {
                if (player.team != this.Player.team) {
                    ModContent.GetInstance<OpponentGoal>().trigger(player);
                    return;
                }
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
                    trigger<DownEoC>();
                }
            } else if (target.type == NPCID.KingSlime) {
                if (target.life <= 0) {
                    trigger<DownKS>();
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            processHitNPC(target, hit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone) {
            processHitNPC(target, hit);
        }

        internal bool achievedFillPiggyBank;
        internal HashSet<int> allObtainedItems = new();
        public override void PostUpdate() {
            var foundTiles = new HashSet<int>();
            var bestTileStack = 0;
            for (int i = 0; i < Player.inventory.Length; i++) {
                var item = Player.inventory[i];
                if (item.stack > 0 && !allObtainedItems.Contains(item.type)) {
                    onAnyObtain(item);
                }
                if (item.createTile != -1) {
                    bestTileStack = Math.Max(item.stack, bestTileStack);
                    if (item.stack >= 999) {
                        trigger<Get999OfTile>();
                    }
                    if (i < 50) {
                        foundTiles.Add(item.type);
                    }
                }
            }
            update(ref Get999OfTile.bestStack, bestTileStack);
            update(
                ref Get999OfTile.bestStackEver,
                Math.Max(Get999OfTile.bestStackEver, bestTileStack)
            );
            if (foundTiles.Count == 50) {
                trigger("InvFullOfBlocks");
            }
            if (!achievedFillPiggyBank) {
                var emptySlots = 0;
                foreach (var item in Player.bank.item) {
                    if (item.stack == 0) {
                        emptySlots++;
                    }
                }
                update(ref FillPiggyBank.slotsLeft, emptySlots);
                if (emptySlots == 0) {
                    trigger<FillPiggyBank>();
                    achievedFillPiggyBank = true;
                }
            }
        }

        internal HashSet<int> modifiedWoodSwordBowHammerItems = new();
        internal void onCraftItem(Item item) {
            onAnyObtain(item);
            if (item.type == ItemID.WoodenSword && item.prefix != 0) {
                modifiedWoodSwordBowHammerItems.Add(item.type);
                progress<GetModifiedWoodSwordBowHammer>(item.AffixName());
            }
            if (item.type == ItemID.WoodenBow && item.prefix != 0) {
                modifiedWoodSwordBowHammerItems.Add(item.type);
                progress<GetModifiedWoodSwordBowHammer>(item.AffixName());
            }
            if (item.type == ItemID.WoodenHammer && item.prefix != 0) {
                modifiedWoodSwordBowHammerItems.Add(item.type);
                progress<GetModifiedWoodSwordBowHammer>(item.AffixName());
            }
            update(
                ref GetModifiedWoodSwordBowHammer.obtained,
                modifiedWoodSwordBowHammerItems
            );
            if (modifiedWoodSwordBowHammerItems.Count == 3) {
                trigger<GetModifiedWoodSwordBowHammer>();
            }
        }

        internal HashSet<int> collectedSpears = new();
        private void onAnyObtain(Item item) {
            allObtainedItems.Add(item.type);
            if (ItemID.Sets.Spears[item.type]) {
                collectedSpears.Add(item.type);
                if (collectedSpears.Count <= 2) {
                    progress<Get2Spears>(item.Name);
                }
                if (collectedSpears.Count == 2) {
                    trigger<Get2Spears>();
                }
                update(ref Get2Spears.collectedSpears, collectedSpears);
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
            if (usedAccs.Count >= 1) {
                failDisallow("EquipAccessories");
            }
            if (usedAccs.Count < 5) {
                progress<Equip5Accessories>(acc.Name);
            } else if (usedAccs.Count >= 5) {
                trigger<Equip5Accessories>();
            }
            update(ref Equip5Accessories.wornAccessories, usedAccs);
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
                                    progress<Suffocate7s>((7 - durInSecs).ToString()!);
                                }
                            } else {
                                trigger<Suffocate7s>();
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
                trigger<DieToThorns>();
            } else if (aboutToHitAltar) {
                trigger<DieToAltar>();
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
                    trigger<Get2Plat>();
                }
            }
            return true;
        }

        internal void reset() {
            allObtainedItems.Clear();
            achievedFillPiggyBank = false;
            achievedHave12Buffs = false;
            achievedHave5Debuffs = false;
            collectedSpears.Clear();
            usedAccs.Clear();
            modifiedWoodSwordBowHammerItems.Clear();
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
