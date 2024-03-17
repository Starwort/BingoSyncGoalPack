using BingoSyncGoalPack.Content.Goals;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.MonitorHooks {
    internal class GlobalItemHooks : GlobalItem {
        public override string IsArmorSet(Item head, Item body, Item legs) {
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateArmorSet(Player player, string set) {
            player.GetModPlayer<PlayerHooks>().updateArmourSet(set);
        }

        public override void UpdateAccessory(Item item, Player player, bool _) {
            player.GetModPlayer<PlayerHooks>().onEquipAccessory(item);
        }

        public override void OnCreated(Item item, ItemCreationContext context) {
            if (context is RecipeItemCreationContext) {
                Main.LocalPlayer.GetModPlayer<PlayerHooks>().onCraftItem(item);
            }
        }
    }
}
