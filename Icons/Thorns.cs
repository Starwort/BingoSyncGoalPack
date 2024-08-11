using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace BingoSyncGoalPack.Icons {
    internal class Thorns : AssetCycleAnimation {
        DrawAnimationSheetSlice slice = new(new Rectangle(162, 54, 16, 16));
        static Random rng = new();

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, slice);
        }

        static ushort[] sheets = [
            TileID.CorruptThorns,
            TileID.CrimsonThorns,
            TileID.JungleThorns,
            TileID.PlanteraThorns,
        ];

        public override Asset<Texture2D> getFrame(uint frame) {
            slice.frame.X = 162 + 18 * rng.Next(3);
            return TextureAssets.Tile[sheets[frame % sheets.Length]];
        }
    }
}
