using BingoBoardCore.AnimationHelpers;
using Terraria;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class AchievementIcon : ModItem {
        public override string Texture => "Terraria/Images/UI/Achievements";
        public static Item Timber = null!;
        public static Item DeadMenTellNoTales = null!;
        public static Item IntoOrbit = null!;
        public static Item RockBottom = null!;
        public static Item VehicularManslaughter = null!;

        internal (int, int) iconPosition;

        public override string Name => $"AchievementIcon/{iconPosition.Item1}-{iconPosition.Item2}";

        public AchievementIcon() {
            iconPosition = (0, 0);
            Timber = this.Item;
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
            DeadMenTellNoTales = add(7, 12);
            IntoOrbit = add(4, 6);
            RockBottom = add(5, 6);
            VehicularManslaughter = add(1, 7);
        }
    }
}
