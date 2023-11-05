using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public class AnyDebuff : AssetCycleAnimation {
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
}