using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework;
using Terraria;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class FillEquipPage2 : IAnimatedObject {
        public override string Texture => "Terraria/Images/Extra_54";

        Rectangle slice = new(0, 0, 16, 16);

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(slice));
        }

        (int, int)[] frames = new[] {
            (1, 3),
            (2, 5),
            (1, 2),
            (1, 4),
            (1, 1),
        };

        public override void animate(uint frame) {
            (var x, var y) = frames[frame % frames.Length];
            slice.X = x * 34;
            slice.Y = y * 34;
        }
    }
}
