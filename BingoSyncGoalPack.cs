global using static BingoSyncGoalPack.BingoSyncGoalPack;
using BingoSyncGoalPack.MonitorHooks;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BingoSyncGoalPack {
    public class BingoSyncGoalPack : Mod {
        public static string GithubUserName => "Starwort";
        public static string GithubProjectName => "BingoGoalPack-BingoSyncGoals";

        internal static string translate(string key, params string[] substitutions) {
            return Language.GetTextValue(
                "Mods.BingoSyncGoalPack." + key,
                substitutions.Select(
                    sub => Language.GetTextValue(sub)
                ).ToArray()
            );
        }

        public override void PostSetupContent() {
            BingoBoardCore.BingoBoardCore.onGameStart(() => {
                foreach (var player in Main.player) {
                    if (player.TryGetModPlayer(out PlayerHooks hooks)) {
                        hooks.onGameStart();
                    }
                }
            });
        }
    }
}