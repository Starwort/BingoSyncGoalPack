using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Content {
    public class Sets {
        #region Item IDs
        internal static List<int> Tiles = new() {ItemID.DirtBlock};
        internal static List<int> Spears = new() {ItemID.Spear};
        internal static List<int> Accessories = new() {ItemID.Shackle};
        internal static List<int> QuestFish = new() {ItemID.AmanitaFungifin};
        internal static List<int> CritterCages = new() {ItemID.BunnyCage};
        internal static List<int> SummonStaves = new() {ItemID.SlimeStaff};
        internal static List<int> Hooks = new() {ItemID.GrapplingHook};
        internal static List<int> Swords = new() {ItemID.CopperShortsword};
        internal static List<int> Minecarts = new() {ItemID.Minecart};
        internal static List<int> CraftablePianos = new() {ItemID.Piano};
        internal static List<int> Platforms = new() {ItemID.WoodPlatform};
        internal static List<int> DungeonWeapons = new() {ItemID.Muramasa};
        internal static List<int> Torches = new() {ItemID.Torch};
        internal static List<int> Paintings = new() {ItemID.PaintingAcorns};
        internal static List<int> Crates = new() {ItemID.WoodenCrate};
        internal static List<int> Yoyos = new() {ItemID.WoodYoyo};
        internal static List<int> Flasks = new() {ItemID.FlaskofCursedFlames};
        internal static List<int> Pylons = new() {ItemID.TeleportationPylonPurity};
        internal static List<int> GlowingMosses = new() {ItemID.ArgonMoss};
        internal static List<int> ObsidianSkullUpgrades = new() {ItemID.ObsidianShield};
        internal static List<int> Toilets = new() {ItemID.Toilet};
        internal static List<int> Anvils = new() {ItemID.IronAnvil};
        internal static List<int> LightRedItems = new() {ItemID.TitaniumSword};
        internal static List<int> Phaseblades = new() {ItemID.WhitePhaseblade};

        #region Hardcoded sets
        internal static List<int> PreHardmodeCampfires = new() {
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire
        };

        internal static List<int> Herbs = new() {
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf
        };

        internal static List<int> LowTierBars = new() {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
        };

        internal static List<int> AnyBars = new() {
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

        internal static List<int> GrassSeeds = new() {
            ItemID.GrassSeeds,
            ItemID.AshGrassSeeds,
            ItemID.JungleGrassSeeds,
            ItemID.MushroomGrassSeeds,
            ItemID.CorruptSeeds,
            ItemID.CrimsonSeeds,
            ItemID.HallowedSeeds
        };

        internal static List<int> GemCritterCages = new() {
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

        internal static List<int> Arrows = new() {
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

        internal static List<int> GemStaves = new() {
            ItemID.AmethystStaff,
            ItemID.TopazStaff,
            ItemID.SapphireStaff,
            ItemID.EmeraldStaff,
            ItemID.AmberStaff,
            ItemID.RubyStaff,
            ItemID.DiamondStaff,
        };

        internal static List<int> Fountains = new() {
            ItemID.PureWaterFountain,
            ItemID.DesertWaterFountain,
            ItemID.JungleWaterFountain,
            ItemID.IcyWaterFountain,
            ItemID.CorruptWaterFountain,
            ItemID.CrimsonWaterFountain,
            ItemID.HallowedWaterFountain,
            ItemID.BloodWaterFountain,
            ItemID.CavernFountain,
            ItemID.OasisFountain
        };

        internal static List<int> GoldGraves = new() {
            ItemID.RichGravestone1,
            ItemID.RichGravestone2,
            ItemID.RichGravestone3,
            ItemID.RichGravestone4,
            ItemID.RichGravestone5
        };
        #endregion
        #endregion

        #region NPC IDs
        internal static List<int> TownNPCs = new() {NPCID.Angler};
        #endregion

        #region Tile IDs
        internal static List<int> Leaves = new() {TileID.LeafBlock};
        #endregion

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
            void fromBoolSets(params (bool[] when, List<int> where)[] rules) {
                foreach ((var when, var where) in rules) {
                    where.Clear();
                    for (int i = 0; i < when.Length; i++) {
                        if (when[i]) {
                            where.Add(i);
                        }
                    }
                }
            }

            createItemSets(
                ((_, item) => item.createTile != -1, Tiles),
                (
                    (_, item) => item.createTile != -1
                        && TileID.Sets.Platforms[item.createTile],
                    Platforms
                ),
                (
                    (id, item) => (
                        item.createTile != -1
                        && TileID.Sets.Torch[item.createTile]
                    ) || ItemID.Sets.Torches[id],
                    Torches
                ),
                (
                    (_, item) => item.createTile != -1
                        && TileID.Sets.Paintings[item.createTile],
                    Paintings
                ),
                ((_, item) => item.accessory, Accessories),
                ((_, item) => item.questItem, QuestFish),
                (
                    (id, item) => Item.staff[id]
                        && item.CountsAsClass(DamageClass.Summon),
                    SummonStaves
                ),
                ((_, item) => Main.projHook[item.shoot], Hooks),
                ((_, item) => isSword(item), Swords),
                (
                    (_, item) => item.mountType >= 0
                        && MountID.Sets.Cart[item.mountType],
                    Minecarts
                ),
                (
                    (_, item) => item.buffType > 0
                        && BuffID.Sets.IsAFlaskBuff[item.buffType],
                    Flasks
                ),
                (
                    (_, item) => item.createTile != -1
                        && TileID.Sets.CountsAsPylon.Contains(item.createTile),
                    Pylons
                ),
                (
                    (id, _) => id == ItemID.RainbowMoss
                        || ItemID.Sets.ShimmerTransformToItem[id] == ItemID.RainbowMoss,
                    GlowingMosses
                ),
                (
                    (id, item) => id == ItemID.Toilet
                        || id == ItemID.GoldenToilet
                        || item.createTile == TileID.Toilets,
                    Toilets
                ),
                (
                    (_, item) => item.createTile == TileID.Anvils
                        || item.createTile == TileID.MythrilAnvil,
                    Anvils
                ),
                (
                    (_, item) => item.rare == ItemRarityID.LightRed,
                    LightRedItems
                )
            );
            fromBoolSets(
                (ItemID.Sets.Spears, Spears),
                (ItemID.Sets.IsFishingCrate, Crates),
                (ItemID.Sets.Yoyo, Yoyos),
                (TileID.Sets.Leaves, Leaves)
            );
            createRecipeSets(
                (appearsToBeCritterCage, CritterCages),
                (appearsToBeCraftablePiano, CraftablePianos),
                (
                    recipe => recipe.HasIngredient(ItemID.ObsidianSkull)
                        && recipe.HasTile(TileID.TinkerersWorkbench),
                    ObsidianSkullUpgrades
                ),
                (appearsToBePhaseblade, Phaseblades)
            );
            filterDropRules(
                (
                    Main.ItemDropsDB.GetRulesForItemID(ItemID.LockBox),
                    drop => ContentSamples.ItemsByType[drop.itemId].damage > 0,
                    DungeonWeapons
                )
            );
            createNpcSets(((_, npc) => npc.townNPC, TownNPCs));
        }

        public static bool appearsToBePhaseblade(Recipe recipe) {
            static bool meteorite(Item itm) => (
                itm.type == ItemID.MeteoriteBar
                && itm.stack == 15
            );
            static bool gem(Item itm) => (
                ItemID.Sets.GeodeDrops.ContainsKey(itm.type)
                && itm.stack == 10
            );
            var ingredients = recipe.requiredItem;
            return (
                ingredients.Count == 2
                && (meteorite(ingredients[0]) || gem(ingredients[0]))
                && (meteorite(ingredients[1]) || gem(ingredients[1]))
                && recipe.HasTile(TileID.Anvils)
            );
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
