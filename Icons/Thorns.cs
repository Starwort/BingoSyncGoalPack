using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class Thorns : ModItem {
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(animationPeriod, 4));
        }
    }
}
