using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class TownNPC : ModItem {
        public override string Texture => $"Terraria/Images/NPC_{npcId}";
        int npcId;

        public override string Name => $"TownNPC/{npcId}";

        public static Item angler = null!;
        public static Item golfer = null!;
        public static Item stylist = null!;

        public TownNPC() {
            this.npcId = NPCID.None;
        }

        public TownNPC(int npcId) {
            this.npcId = npcId;
        }

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(6, Main.npcFrameCount[npcId]));
        }

        public override bool IsLoadingEnabled(Mod mod) => npcId != NPCID.None;

        public static void registerItems() {
            Item add(int id) {
                TownNPC icon = new(id);
                ModContent.GetInstance<BingoGoalPackBingoSyncGoals>().AddContent(
                    icon
                );
                return icon.Item;
            }
            angler = add(NPCID.Angler);
            golfer = add(NPCID.Golfer);
            stylist = add(NPCID.Stylist);
        }
    }
}
