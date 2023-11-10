using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class IntoOrbit : ModItem {
        public override string Texture => "Terraria/Images/UI/Achievements";
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(
                new(264, 396, 64, 64)
            ));
        }
    }
}
