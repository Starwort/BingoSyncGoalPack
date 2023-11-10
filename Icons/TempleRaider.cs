using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class TempleRaider : ModItem {
        public override string Texture => "Terraria/Images/UI/Achievements";
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(
                new(376, 198, 64, 64)
            ));
        }
    }
}
