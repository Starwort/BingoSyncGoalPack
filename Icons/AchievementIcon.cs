using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class AchievementIcon : ModItem {
        public override string Texture => "Terraria/Images/UI/Achievements";
        public static Item timber = null!;
        public static Item deadMenTellNoTales = null!;
        public static Item intoOrbit = null!;
        public static Item rockBottom = null!;

        internal (int, int) iconPosition;

        public override string Name => $"AchievementIcon/{iconPosition.Item1}-{iconPosition.Item2}";

        public AchievementIcon() {
            iconPosition = (0, 0);
            timber = this.Item;
        }

        public AchievementIcon((int, int) position) {
            iconPosition = position;
        }

        public override void SetStaticDefaults() {
            (var x, var y) = iconPosition;
            Main.RegisterItemAnimation(Type, new DrawAnimationSheetSlice(
                new(x * 66, y * 66, 64, 64)
            ));
        }

        public static void registerItems() {
            Item add(int x, int y) {
                AchievementIcon icon = new((x, y));
                ModContent.GetInstance<BingoGoalPackBingoSyncGoals>().AddContent(
                    icon
                );
                return icon.Item;
            }
            deadMenTellNoTales = add(7, 12);
            intoOrbit = add(4, 6);
            rockBottom = add(5, 6);
        }
    }
}
