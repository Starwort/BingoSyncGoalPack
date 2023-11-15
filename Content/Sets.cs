using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Content {
    public class Sets {
        internal static List<int> tiles = new() {ItemID.DirtBlock};
        internal static List<int> spears = new() {ItemID.Spear};
        internal static List<int> accessories = new() {ItemID.Shackle};
        internal static List<int> questFish = new() {ItemID.AmanitaFungifin};
        internal static List<int> critterCages = new() {ItemID.BunnyCage};
        internal static List<int> summonStaves = new() {ItemID.SlimeStaff};
        internal static List<int> hooks = new() {ItemID.GrapplingHook};
        internal static List<int> swords = new() {ItemID.CopperShortsword};
        internal static List<int> minecarts = new() {ItemID.Minecart};
        internal static List<int> craftablePianos = new() {ItemID.Piano};
        internal static List<int> platforms = new() {ItemID.WoodPlatform};
        internal static List<int> dungeonWeapons = new() {ItemID.Muramasa};
        internal static List<int> torches = new() {ItemID.Torch};
        internal static List<int> paintings = new() {ItemID.PaintingAcorns};
        internal static List<int> crates = new() {ItemID.WoodenCrate};
        internal static List<int> yoyos = new() {ItemID.WoodYoyo};
        internal static List<int> flasks = new() {ItemID.FlaskofCursedFlames};

        internal static List<int> phmCampfires = new() {
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire
        };

        internal static List<int> herbs = new() {
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf
        };

        internal static List<int> lowTierBars = new() {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
        };

        internal static List<int> bars = new() {
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

        internal static List<int> grassSeeds = new() {
            ItemID.GrassSeeds,
            ItemID.AshGrassSeeds,
            ItemID.JungleGrassSeeds,
            ItemID.MushroomGrassSeeds,
            ItemID.CorruptSeeds,
            ItemID.CrimsonSeeds,
            ItemID.HallowedSeeds
        };

        internal static List<int> gemCritterCages = new() {
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

        internal static List<int> arrows = new() {
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

        internal static List<int> gemStaves = new() {
            ItemID.AmethystStaff,
            ItemID.TopazStaff,
            ItemID.SapphireStaff,
            ItemID.EmeraldStaff,
            ItemID.AmberStaff,
            ItemID.RubyStaff,
            ItemID.DiamondStaff,
        };

        internal static List<int> townNPCs = new() {NPCID.Angler};

        internal static void load() {
            void createItemSets(params (Func<int, Item, bool> shouldBeInSet, List<int> storage)[] rules) {
                foreach ((var _, var storage) in rules) {
                    storage.Clear();
                }
                foreach ((var id, var item) in ContentSamples.ItemsByType) {
                    foreach ((var when, var storage) in rules) {
                        if (when(id, item)) {
                            storage.Add(id);
                        }
                    }
                }
            }
            void createNpcSets(params (Func<int, NPC, bool> shouldBeInSet, List<int> storage)[] rules) {
                foreach ((var _, var storage) in rules) {
                    storage.Clear();
                }
                foreach ((var id, var npc) in ContentSamples.NpcsByNetId) {
                    foreach ((var when, var storage) in rules) {
                        if (when(id, npc)) {
                            storage.Add(id);
                        }
                    }
                }
            }
            void createRecipeSets(params (Func<Recipe, bool> shouldBeInSet, List<int> storage)[] rules) {
                foreach ((var _, var storage) in rules) {
                    storage.Clear();
                }
                foreach (var recipe in Main.recipe) {
                    foreach ((var when, var storage) in rules) {
                        if (when(recipe)) {
                            storage.Add(recipe.createItem.type);
                        }
                    }
                }
            }
            void filterDropRules(params (List<IItemDropRule> what, Func<DropRateInfo, bool> when, List<int> where)[] rules) {
                foreach ((var what, var when, var where) in rules) {
                    where.Clear();

                    List<DropRateInfo> list = new();
                    DropRateInfoChainFeed ratesInfo = new(1f);
                    foreach (var item in what) {
                        item.ReportDroprates(list, ratesInfo);
                    }
                    foreach (var dropInfo in list) {
                        if (when(dropInfo)) {
                            where.Add(dropInfo.itemId);
                        }
                    }
                }
            }

            createItemSets(
                ((_, item) => item.createTile != -1, tiles),
                (
                    (_, item) => item.createTile != -1
                        && TileID.Sets.Platforms[item.createTile],
                    platforms
                ),
                (
                    (id, item) => (
                        item.createTile != -1
                        && TileID.Sets.Torch[item.createTile]
                    ) || ItemID.Sets.Torches[id],
                    torches
                ),
                (
                    (_, item) => item.createTile != -1
                        && TileID.Sets.Paintings[item.createTile],
                    paintings
                ),
                ((id, _) => ItemID.Sets.Spears[id], spears),
                ((_, item) => item.accessory, accessories),
                ((_, item) => item.questItem, questFish),
                (
                    (id, item) => Item.staff[id]
                        && item.CountsAsClass(DamageClass.Summon),
                    summonStaves
                ),
                ((_, item) => Main.projHook[item.shoot], hooks),
                ((_, item) => isSword(item), swords),
                (
                    (_, item) => item.mountType >= 0
                        && MountID.Sets.Cart[item.mountType],
                    minecarts
                ),
                ((id, _) => ItemID.Sets.IsFishingCrate[id], crates),
                ((id, _) => ItemID.Sets.Yoyo[id], yoyos),
                (
                    (_, item) => item.buffType > 0
                        && BuffID.Sets.IsAFlaskBuff[item.buffType],
                    flasks
                )
            );
            createRecipeSets(
                (appearsToBeCritterCage, critterCages),
                (appearsToBeCraftablePiano, craftablePianos)
            );
            filterDropRules(
                (
                    Main.ItemDropsDB.GetRulesForItemID(ItemID.LockBox),
                    drop => ContentSamples.ItemsByType[drop.itemId].damage > 0,
                    dungeonWeapons
                )
            );
            createNpcSets(((_, npc) => npc.townNPC, townNPCs));
        }

        public static bool appearsToBeCritterCage(Recipe recipe) {
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
