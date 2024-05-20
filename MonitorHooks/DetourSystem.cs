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
            On_AchievementsHelper.HandleSpecialEvent += onDieToDeadMansChest;
        }

        private void onDieToDeadMansChest(On_AchievementsHelper.orig_HandleSpecialEvent orig, Player player, int eventID) {
            if (eventID == AchievementHelperID.Special.DeathByDeadmansChest) {
                ModContent.GetInstance<DeadMenTellNoTales>().trigger(player);
            }
            orig(player, eventID);
        }

    }

}
