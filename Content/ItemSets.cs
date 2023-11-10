using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Content {
    public class ItemSets {
        internal static int[] tiles = new int[] {ItemID.DirtBlock};
        internal static int[] spears = new int[] {ItemID.Spear};
        internal static int[] accessories = new int[] {ItemID.Shackle};
        internal static int[] questFish = new int[] {ItemID.AmanitaFungifin};
        internal static int[] critterContainers = new int[] {ItemID.BunnyCage};
        internal static int[] summonStaves = new int[] {ItemID.SlimeStaff};
        internal static int[] hooks = new int[] {ItemID.GrapplingHook};
        internal static int[] swords = new int[] {ItemID.CopperShortsword};
        internal static int[] minecarts = new int[] {ItemID.Minecart};
        internal static int[] craftablePianos = new int[] {ItemID.Piano};
        internal static int[] platforms = new int[] {ItemID.WoodPlatform};
        internal static int[] dungeonWeapons = new int[] {ItemID.Muramasa};

        internal static int[] phmCampfires = new int[] {
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire
        };

        internal static int[] herbs = new int[] {
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf
        };

        internal static int[] lowTierBars = new int[] {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
        };

        internal static int[] bars = new int[23] {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
            // Tier 5
            ItemID.MeteoriteBar,
            // Tier 6
            ItemID.DemoniteBar, ItemID.CrimtaneBar,
            // Tier 7
            ItemID.HellstoneBar,
            // Tier 8
            ItemID.CobaltBar, ItemID.PalladiumBar,
            // Tier 9
            ItemID.MythrilBar, ItemID.OrichalcumBar,
            // Tier 10
            ItemID.AdamantiteBar, ItemID.TitaniumBar,
            // Tier 11
            ItemID.HallowedBar,
            // Tier 12
            ItemID.ChlorophyteBar,
            // Tier 13
            ItemID.ShroomiteBar, ItemID.SpectreBar,
            // Tier 14
            ItemID.LunarBar,
        };

        internal static int[] grassSeeds = new int[] {
            ItemID.GrassSeeds,
            ItemID.AshGrassSeeds,
            ItemID.JungleGrassSeeds,
            ItemID.MushroomGrassSeeds,
            ItemID.CorruptSeeds,
            ItemID.CrimsonSeeds,
            ItemID.HallowedSeeds
        };

        internal static int[] gemCritterCages = new int[] {
            ItemID.AmberBunnyCage,
            ItemID.AmberSquirrelCage,
            ItemID.AmethystBunnyCage,
            ItemID.AmethystSquirrelCage,
            ItemID.DiamondBunnyCage,
            ItemID.DiamondSquirrelCage,
            ItemID.EmeraldBunnyCage,
            ItemID.EmeraldSquirrelCage,
            ItemID.RubyBunnyCage,
            ItemID.RubySquirrelCage,
            ItemID.SapphireBunnyCage,
            ItemID.SapphireSquirrelCage,
            ItemID.TopazBunnyCage,
            ItemID.TopazSquirrelCage,
        };

        internal static int[] arrows = new int[] {
            ItemID.WoodenArrow,
            ItemID.FlamingArrow,
            ItemID.UnholyArrow,
            ItemID.JestersArrow,
            ItemID.HellfireArrow,
            ItemID.HolyArrow,
            ItemID.CursedArrow,
            ItemID.FrostburnArrow,
            ItemID.ChlorophyteArrow,
            ItemID.IchorArrow,
            ItemID.VenomArrow,
            ItemID.BoneArrow,
            ItemID.MoonlordArrow,
            ItemID.ShimmerArrow,
        };

        internal static int[] gemStaves = new int[] {
            ItemID.AmethystStaff,
            ItemID.TopazStaff,
            ItemID.SapphireStaff,
            ItemID.EmeraldStaff,
            ItemID.AmberStaff,
            ItemID.RubyStaff,
            ItemID.DiamondStaff,
        };

        internal static void load() {
            tiles = (
                from val in ContentSamples.ItemsByType
                where val.Value.createTile != -1
                select val.Key
            ).ToArray();
            // It seems that this is inexpressible with linq
            spears = (
                ItemID.Sets.Spears
                .Select((isSpear, id) => new {isSpear, id})
                .Where(val => val.isSpear)
                .Select(val => val.id)
            ).ToArray();
            accessories = (
                from val in ContentSamples.ItemsByType
                where val.Value.accessory
                select val.Key
            ).ToArray();
            questFish = (
                from val in ContentSamples.ItemsByType
                where val.Value.questItem
                select val.Key
            ).ToArray();
            critterContainers = (
                from recipe in Main.recipe
                where appearsToBeCritterContainer(recipe)
                select recipe.createItem.type
            ).ToArray();
            summonStaves = (
                from val in ContentSamples.ItemsByType
                where Item.staff[val.Key]
                    && val.Value.CountsAsClass(DamageClass.Summon)
                select val.Key
            ).ToArray();
            hooks = (
                from val in ContentSamples.ItemsByType
                where Main.projHook[val.Value.shoot]
                select val.Key
            ).ToArray();
            swords = (
                from val in ContentSamples.ItemsByType
                where isSword(val.Value)
                select val.Key
            ).ToArray();
            minecarts = (
                from val in ContentSamples.ItemsByType
                where val.Value.mountType > 0
                    && MountID.Sets.Cart[val.Value.mountType]
                select val.Key
            ).ToArray();
            craftablePianos = (
                from recipe in Main.recipe
                where appearsToBeCraftablePiano(recipe)
                select recipe.createItem.type
            ).ToArray();
            platforms = (
                from val in ContentSamples.ItemsByType
                where val.Value.createTile != -1
                    && TileID.Sets.Platforms[val.Value.createTile]
                select val.Key
            ).ToArray();
            {
                var dropRules = Main.ItemDropsDB.GetRulesForItemID(ItemID.LockBox);
                List<DropRateInfo> list = new();
                DropRateInfoChainFeed ratesInfo = new(1f);
                foreach (var item in dropRules) {
                    item.ReportDroprates(list, ratesInfo);
                }
                dungeonWeapons = (
                    from drop in list
                    where ContentSamples.ItemsByType[drop.itemId].damage > 0
                    select drop.itemId
                ).ToArray();
            }
        }

        public static bool appearsToBeCritterContainer(Recipe recipe) {
            var ingredients = recipe.requiredItem;
            if (ingredients.Count != 2) {
                return false;
            }
            Item? critter = null;
            if (
                ingredients[0].type != ItemID.Terrarium
                && ingredients[0].type != ItemID.Bottle
            ) {
                critter = ingredients[0];
            }
            if (
                ingredients[1].type != ItemID.Terrarium
                && ingredients[1].type != ItemID.Bottle
            ) {
                if (critter is null) {
                    critter = ingredients[1];
                } else {
                    return false;
                }
            }
            return critter is not null && critter.makeNPC > 0;
        }

        public static bool isSword(Item item) {
            if (
                item.createTile != -1
                || item.makeNPC > 0
                || item.createWall != -1
                || item.pick > 0
                || item.axe > 0
                || item.hammer > 0
                || item.damage == -1
                || !(
                    item.DamageType == DamageClass.Melee
                    || (item.DamageType == DamageClass.MeleeNoSpeed && item.useStyle == ItemUseStyleID.Rapier)
                )
            ) {
                return false;
            }
            bool isBroadSword(Item item) {
                if (
                    item.type == ItemID.GravediggerShovel
                    || item.type == ItemID.WaffleIron
                    || item.type == ItemID.Sickle
                ) {
                    return false;
                }
                return true;
            }
            bool isShortSword(Item item) {
                return true;
            }
            bool isNewShortSword(Item item) {
                if (item.type == ItemID.PiercingStarlight) {
                    return false;
                }
                return true;
            }

            return item.useStyle switch {
                ItemUseStyleID.Swing => isBroadSword(item),
                ItemUseStyleID.Thrust => isShortSword(item),
                ItemUseStyleID.Rapier => isNewShortSword(item),
                _ => false,
            };
        }

        public static bool appearsToBeCraftablePiano(Recipe recipe) {
            if (recipe.createItem.createTile == TileID.Pianos) {
                return true;
            }
            int bookCount = 0;
            int boneCount = 0;
            int otherCount = 0;
            var bad = 0;
            foreach (var item in recipe.requiredItem) {
                var _ = item.type switch {
                    ItemID.Book => bookCount += item.stack,
                    ItemID.Bone => boneCount += item.stack,
                    _ => item.stack == 15 && item.createTile != -1
                        ? otherCount += 15
                        : bad = 1
                };
            }
            return (
                bookCount == 1
                && boneCount == 4
                && otherCount == 15
                && bad == 0
            );
        }
    }
}
