using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class DeadMenTellNoTales : ModItem {
        public override string Texture => "Terraria/Images/UI/Achievements";
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(
                new(462, 792, 64, 64)
            ));
        }
    }
}
