using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class BestiaryIcon : ModItem {
        public override string Texture => "Terraria/Images/UI/Bestiary/Icon_Tags_Shadow";
        public static Item Forest = null!; // not used, but might as well include
        public static Item Ocean = null!;
        public static Item Crimson = null!;
        public static Item CrimsonDesert = null!;
        public static Item Corrupt = null!;
        public static Item CorruptDesert = null!;
        public static Item Mushroom = null!;
        public static Item Bag = null!;
        public static Item Dungeon = null!;
        public static Item Temple = null!;
        public static Item Island = null!;

        internal (int, int) iconPosition;

        public override string Name => $"BestiaryIcon/{iconPosition.Item1}-{iconPosition.Item2}";

        public BestiaryIcon() {
            iconPosition = (0, 0);
            Forest = this.Item;
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
            Ocean = add(12, 1);
            Crimson = add(12, 0);
            CrimsonDesert = add(14, 0);
            Corrupt = add(7, 0);
            CorruptDesert = add(9, 0);
            Mushroom = add(8, 1);
            Bag = add(13, 3);
            Dungeon = add(0, 2);
            Temple = add(15, 1);
            Island = add(10, 1);
        }
    }
}
