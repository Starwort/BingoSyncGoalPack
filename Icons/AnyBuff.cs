using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class AnyBuff : AssetCycleAnimation {
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
}