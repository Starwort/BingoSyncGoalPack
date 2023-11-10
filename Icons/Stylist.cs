using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class Stylist : ModItem {
        public override string Texture => $"Terraria/Images/NPC_{NPCID.Stylist}";

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(6, Main.npcFrameCount[NPCID.Angler]));
        }
    }
}
