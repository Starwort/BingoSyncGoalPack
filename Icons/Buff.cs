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

            public AnyBuff() {
                Buff.Any = this.Item;
            }

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
        private class _AnyDebuff : AssetCycleAnimation {
            private static Random rng = new();
            private Asset<Texture2D>[] debuffs;

            public _AnyDebuff() {
                Buff.AnyDebuff = this.Item;
                // init debuffs with a list of all debuff textures
                debuffs = TextureAssets.Buff.Where((_, i) => Main.debuff[i]).ToArray();
            }

            public override Asset<Texture2D> getFrame(uint frame) {
                return debuffs[rng.Next(debuffs.Length)];
            }
        }
        public static Item Any = null!;
        public static Item AnyDebuff = null!;

        public static Item Suffocation = null!;
        public static Item Stinky = null!;
        public static Item TheTongue = null!;

        private int buffId;

        public Buff() {
            this.buffId = -1;
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
            Suffocation = add(BuffID.Suffocation);
            Stinky = add(BuffID.Stinky);
            TheTongue = add(BuffID.TheTongue);
        }
    }
}
