using BingoSyncGoalPack.Icons;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Content {
    internal class IconRegistry : ModSystem {
        public override void Load() {
            Buff.registerItems();
            Npc.registerItems();
        }

        public override void PostSetupContent() {
            Sets.load();
        }
    }
}
