using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class LivingLeaf : AssetCycleAnimation {
        DrawAnimationSheetSlice slice = new(new Rectangle(162, 54, 16, 16));
        static Random rng = new();

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, slice);
        }

        static ushort[] sheets = new[] {
            TileID.LeafBlock,
            TileID.LivingMahoganyLeaves,
        };

        public override Asset<Texture2D> getFrame(uint frame) {
            slice.frame.X = 162 + 18 * rng.Next(3);
            return TextureAssets.Tile[sheets[frame % sheets.Length]];
        }
    }
}
