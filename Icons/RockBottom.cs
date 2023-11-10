using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class RockBottom : ModItem {
        public override string Texture => "Terraria/Images/UI/Achievements";
        public override void SetDefaults() {
            // there's actually a mistake in the vanilla texture where some of
            // the right border is overwritten with the art for the achievement!
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(
                new(330, 396, 64, 64)
            ));
        }
    }
}
