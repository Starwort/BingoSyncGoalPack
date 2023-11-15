using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class BestiaryIcon : ModItem {
        public override string Texture => "Terraria/Images/UI/Bestiary/Icon_Tags_Shadow";
        public static Item forest = null!; // not used, but might as well include
        public static Item ocean = null!;
        public static Item crimson = null!;
        public static Item crimsonDesert = null!;
        public static Item corrupt = null!;
        public static Item corruptDesert = null!;
        public static Item mushroom = null!;
        public static Item bag = null!;
        public static Item dungeon = null!;
        public static Item temple = null!;
        public static Item island = null!;

        internal (int, int) iconPosition;

        public override string Name => $"BestiaryIcon/{iconPosition.Item1}-{iconPosition.Item2}";

        public BestiaryIcon() {
            iconPosition = (0, 0);
            forest = this.Item;
        }

        public BestiaryIcon((int, int) position) {
            iconPosition = position;
        }

        public override void SetStaticDefaults() {
            (var x, var y) = iconPosition;
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(
                new(x * 30, y * 30, 30, 30)
            ));
        }

        public static void registerItems() {
            Item add(int x, int y) {
                BestiaryIcon icon = new((x, y));
                ModContent.GetInstance<BingoGoalPackBingoSyncGoals>().AddContent(
                    icon
                );
                return icon.Item;
            }
            ocean = add(12, 1);
            crimson = add(12, 0);
            crimsonDesert = add(14, 0);
            corrupt = add(7, 0);
            corruptDesert = add(9, 0);
            mushroom = add(8, 1);
            bag = add(13, 3);
            dungeon = add(0, 2);
            temple = add(15, 1);
            island = add(10, 1);
        }
    }
}
