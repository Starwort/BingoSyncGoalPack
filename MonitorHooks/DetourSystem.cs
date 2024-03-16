using BingoSyncGoalPack.Content.Goals;
using BingoSyncGoalPack.MonitorHooks;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Systems {
    internal class DetourSystem : ModSystem {
        public override void Load() {
            On_TEFoodPlatter.PlaceItemInFrame += detectFoodPlace;
            On_Player.ItemCheck_UseMiningTools_ActuallyUseMiningTool += detectDieToAltar;
            On_Player.ApplyTouchDamage += detectDieToThorns;
            On_AchievementsHelper.HandleSpecialEvent += onDieToDeadMansChest;
            On_AchievementsHelper.HandleAnglerService += onFishingQuestComplete;
        }

        private void onFishingQuestComplete(On_AchievementsHelper.orig_HandleAnglerService orig) {
            Main.LocalPlayer.GetModPlayer<PlayerHooks>().onFishingQuestComplete();
            orig();
        }

        private void onDieToDeadMansChest(On_AchievementsHelper.orig_HandleSpecialEvent orig, Player player, int eventID) {
            if (eventID == AchievementHelperID.Special.DeathByDeadmansChest) {
                ModContent.GetInstance<DeadMenTellNoTales>().trigger(player);
            }
            orig(player, eventID);
        }

        private void detectDieToThorns(On_Player.orig_ApplyTouchDamage orig, Player self, int tileId, int x, int y) {
            if (tileId == TileID.CorruptThorns || tileId == TileID.CrimsonThorns || tileId == TileID.JungleThorns || tileId == TileID.PlanteraThorns) {
                self.GetModPlayer<PlayerHooks>().aboutToTouchThorns = true;
            }
            orig(self, tileId, x, y);
            self.GetModPlayer<PlayerHooks>().aboutToTouchThorns = false;
        }

        private void detectDieToAltar(On_Player.orig_ItemCheck_UseMiningTools_ActuallyUseMiningTool orig, Player self, Item sItem, out bool canHitWalls, int x, int y) {
            Tile tile = Main.tile[x, y];
            if (tile.HasTile && Main.tileHammer[tile.TileType] && sItem.hammer > 0 && tile.TileType == TileID.DemonAltar) {
                self.GetModPlayer<PlayerHooks>().aboutToHitAltar = true;
            }
            orig(self, sItem, out canHitWalls, x, y);
            self.GetModPlayer<PlayerHooks>().aboutToHitAltar = false;
        }

        private static void detectFoodPlace(On_TEFoodPlatter.orig_PlaceItemInFrame orig, Player player, int x, int y) {
            ModContent.GetInstance<PutFoodOnPlate>().trigger(player);
            orig(player, x, y);
        }
    }

}
