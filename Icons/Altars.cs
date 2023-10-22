using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class Altars : ModItem {
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(animationPeriod, 2));
        }
    }
}
