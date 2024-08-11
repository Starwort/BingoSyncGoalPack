using BingoBoardCore.Common;
using BingoSyncGoalPack.Content.Goals;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.MonitorHooks {
    public class PlayerHooks : ModPlayer {
        public PlayerHooks() : base() {
            reset();
        }

        void trigger<T>() where T : Goal {
            ModContent.GetInstance<T>().trigger(Player);
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

        internal HashSet<int> allObtainedItems = [];
        public override void PostUpdate() {
            var foundTiles = new HashSet<int>();
            for (int i = 0; i < Player.inventory.Length; i++) {
                var item = Player.inventory[i];
                if (item.stack > 0 && !allObtainedItems.Contains(item.type)) {
                    onAnyObtain(item);
                }
                if (item.createTile != -1) {
                    if (i < 50) {
                        foundTiles.Add(item.type);
                    }
                }
            }
            if (foundTiles.Count == 50) {
                trigger<InvFullOfBlocks>();
            }
        }

        internal void onCraftItem(Item item) {
            onAnyObtain(item);
        }

        private void onAnyObtain(Item item) {
            allObtainedItems.Add(item.type);
        }

        internal HashSet<int> usedAccs = [];
        public void onEquipAccessory(Item acc) {
            if (usedAccs.Contains(acc.type)) {
                return;
            }
            usedAccs.Add(acc.type);
            if (usedAccs.Count >= 1) {
                failDisallow<NoEquipAccessories, OpponentEquipAccessories>();
            }
        }

        internal bool achievedHave12Buffs;
        internal bool achievedHave5Debuffs;
        public override void PostUpdateBuffs() {
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
            }
            if (foundBuffs >= 12 && !achievedHave12Buffs) {
                trigger<Have12Buffs>();
                achievedHave12Buffs = true;
            }
            if (foundDebuffs >= 5 && !achievedHave5Debuffs) {
                trigger<Have5Debuffs>();
                achievedHave5Debuffs = true;
            }
        }

        internal string? lastArmourSet;

        internal void updateArmourSet(string set) {
            if (set != lastArmourSet) {
                this.lastArmourSet = set;
                switch (set) {
                    case "cactus":
                        trigger<WearCactusArmour>();
                        break;
                    case "evil":
                        trigger<WearEvilArmour>();
                        break;
                    case "pumpkin":
                        trigger<WearPumpkinArmour>();
                        break;
                    case "fossil":
                        trigger<WearFossilArmour>();
                        break;
                    case "necro":
                        trigger<WearNecroArmour>();
                        break;
                }
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
            achievedHave12Buffs = false;
            achievedHave5Debuffs = false;
            usedAccs.Clear();
        }

        internal void onGameStart() {
            reset();
        }

    }
}
