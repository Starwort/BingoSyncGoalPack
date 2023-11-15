using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.GameContent;
using Terraria;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class Buff : ModItem {
        private class AnyBuff : AssetCycleAnimation {
            private static Random rng = new();

            public override Asset<Texture2D> getFrame(uint frame) {
                while (true) {
                    // don't allow Buff #0 (it's null)
                    var idx = rng.Next(TextureAssets.Buff.Length - 1) + 1;
                    var asset = TextureAssets.Buff[idx];
                    if (asset is null) {
                        Main.NewText($"Asset for buff {idx} was null!", Color.Red);
                        Console.Error.WriteLine($"Asset for buff {idx} was null!");
                    } else {
                        return asset;
                    }
                }
            }
        }
        private class AnyDebuff : AssetCycleAnimation {
            private static Random rng = new();
            private Asset<Texture2D>[] debuffs;

            public AnyDebuff() {
                // init debuffs with a list of all debuff textures
                debuffs = TextureAssets.Buff.Where((_, i) => Main.debuff[i]).ToArray();
            }

            public override Asset<Texture2D> getFrame(uint frame) {
                return debuffs[rng.Next(debuffs.Length)];
            }
        }
        public static Item any = null!;
        public static Item anyDebuff = null!;

        public static Item suffocation = null!;
        public static Item stinky = null!;

        private int buffId;

        public Buff() {
            this.buffId = -1;
            any = ModContent.GetInstance<AnyBuff>().Item;
            anyDebuff = ModContent.GetInstance<AnyDebuff>().Item;
        }

        public Buff(int buffId) {
            this.buffId = buffId;
        }

        public override bool IsLoadingEnabled(Mod mod) => buffId != -1;

        public override string Name => $"Buff/{buffId}";

        public override string Texture => $"Terraria/Images/Buff_{buffId}";

        public static void registerItems() {
            Item add(int buffId) {
                Buff icon = new(buffId);
                ModContent.GetInstance<BingoGoalPackBingoSyncGoals>().AddContent(
                    icon
                );
                return icon.Item;
            }
            suffocation = add(BuffID.Suffocation);
            stinky = add(BuffID.Stinky);
        }
    }
}
