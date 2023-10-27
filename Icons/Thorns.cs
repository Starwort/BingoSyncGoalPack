using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class Thorns : ModItem {
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationSyncedVertical(4));
        }
    }
}
