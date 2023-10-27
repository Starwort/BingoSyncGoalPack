using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.GameContent;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class AnyBuff : AnimatedIcon {
        private static Random rng = new();

        internal override Asset<Texture2D> getFrame(uint frame) {
            return TextureAssets.Buff[rng.Next(TextureAssets.Buff.Length)];
        }
    }
}