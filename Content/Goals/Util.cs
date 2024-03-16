using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Terraria.ID;

namespace BingoSyncGoalPack.Content.Goals {
    internal class Util {
        public static string? progressTextFor(HashSet<int> collectedItems, int totalRequiredItems) {
            if (collectedItems.Count >= totalRequiredItems) {
                return null;
            }
            return progressTextFor(collectedItems.Select(
                item => "\n- " + ContentSamples.ItemsByType[item].Name
            ).ToImmutableSortedSet(), totalRequiredItems);
        }
        public static string? progressTextFor(ICollection<string> completedLines, int totalRequiredItems) {
            if (completedLines.Count >= totalRequiredItems) {
                return null;
            }
            var completedLinesText = string.Join("", completedLines.ToImmutableSortedSet());
            if (completedLinesText != "") {
                completedLinesText = ":" + completedLinesText;
            }
            return translate(
                "ProgressText.Collections",
                completedLines.Count.ToString(),
                totalRequiredItems.ToString(),
                completedLinesText
            );
        }
    }
}
