using BingoGoalPackBingoSyncGoals.Icons;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Content {
    internal class IconRegistry : ModSystem {
        public override void Load() {
            Achievement.registerItems();
            Bestiary.registerItems();
            Buff.registerItems();
            Npc.registerItems();
        }

        public override void PostSetupContent() {
            Sets.load();
        }
    }
}
