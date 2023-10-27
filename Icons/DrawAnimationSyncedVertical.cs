using Terraria;
using Terraria.DataStructures;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class DrawAnimationSyncedVertical : DrawAnimationVertical {
        public DrawAnimationSyncedVertical(int frameCount) : base(animationPeriod, frameCount) { }

        public override void Update() {
            Frame = (int)(Main.GameUpdateCount / animationPeriod);
            Frame %= FrameCount;
        }
    }
}
