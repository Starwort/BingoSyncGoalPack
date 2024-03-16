using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Icons {
    internal class Altars : ModItem {
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationSyncedVertical(2));
        }
    }
}
