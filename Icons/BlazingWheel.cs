using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class BlazingWheel : ModItem {
        public override string Texture => $"Terraria/Images/NPC_{NPCID.BlazingWheel}";
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(
                3, Main.npcFrameCount[NPCID.BlazingWheel]
            ));
        }
    }
}
