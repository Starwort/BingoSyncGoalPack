using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Content {
    internal class Set : IList<int>, IReadOnlyList<int> {
        HashSet<int> lookup = [];
        List<int> items = [];

        public int this[int index] { 
            get => items[index]; 
            set => throw new InvalidOperationException(); 
        }

        public int Count => items.Count;
        public bool IsReadOnly => false;

        public void Add(int item) {
            if (Contains(item)){
                throw new InvalidOperationException($"{item} already in set");
            }
            lookup.Add(item);
            items.Add(item);
        }

        public void Clear() {
            lookup.Clear();
            items.Clear();
        }

        public bool Contains(int item) => lookup.Contains(item);

        public void CopyTo(int[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

        public int IndexOf(int item) {
            if (!Contains(item)) return -1;
            return items.IndexOf(item);
        }

        public void Insert(int index, int item) {
            if (Contains(item)){
                throw new InvalidOperationException($"{item} already in set");
            }
            lookup.Add(item);
            items.Insert(index, item);
        }

        public bool Remove(int item) {
            if (!Contains(item)) {
                return false;
            }
            lookup.Remove(item);
            items.Remove(item);
            return true;
        }

        public void RemoveAt(int index) {
            lookup.Remove(items[index]);
            items.RemoveAt(index);
        }

        public IEnumerator<int> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
    public class Sets {
        #region Item IDs
        internal static Set Tiles = [ItemID.DirtBlock];
        internal static Set Spears = [ItemID.Spear];
        internal static Set Accessories = [ItemID.Shackle];
        internal static Set QuestFish = [ItemID.AmanitaFungifin];
        internal static Set CritterCages = [ItemID.BunnyCage];
        internal static Set SummonStaves = [ItemID.SlimeStaff];
        internal static Set Hooks = [ItemID.GrapplingHook];
        internal static Set Swords = [ItemID.CopperShortsword];
        internal static Set Minecarts = [ItemID.Minecart];
        internal static Set CraftablePianos = [ItemID.Piano];
        internal static Set Platforms = [ItemID.WoodPlatform];
        internal static Set DungeonWeapons = [ItemID.Muramasa];
        internal static Set Torches = [ItemID.Torch];
        internal static Set Paintings = [ItemID.PaintingAcorns];
        internal static Set Crates = [ItemID.WoodenCrate];
        internal static Set Yoyos = [ItemID.WoodYoyo];
        internal static Set Flasks = [ItemID.FlaskofCursedFlames];
        internal static Set Pylons = [ItemID.TeleportationPylonPurity];
        internal static Set GlowingMosses = [ItemID.ArgonMoss];
        internal static Set ObsidianSkullUpgrades = [ItemID.ObsidianShield];
        internal static Set Toilets = [ItemID.Toilet];
        internal static Set Anvils = [ItemID.IronAnvil];
        internal static Set LightRedItems = [ItemID.TitaniumSword];
        internal static Set Phaseblades = [ItemID.WhitePhaseblade];
        internal static Set Flails = [ItemID.BallOHurt];

        #region Hardcoded sets
        internal static Set PreHardmodeCampfires = [
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire,
        ];

        internal static Set Herbs = [
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf,
        ];
        internal static Set HerbSeeds = [
            ItemID.BlinkrootSeeds, ItemID.DaybloomSeeds, ItemID.DeathweedSeeds,
            ItemID.FireblossomSeeds, ItemID.MoonglowSeeds, ItemID.ShiverthornSeeds,
            ItemID.WaterleafSeeds,
        ];
        internal static Set Mushrooms = [
            ItemID.GlowingMushroom,
            ItemID.GreenMushroom,
            ItemID.Mushroom,
            ItemID.StrangeGlowingMushroom,
            ItemID.TealMushroom,
            ItemID.ViciousMushroom,
            ItemID.VileMushroom,
        ];

        internal static Set LowTierBars = [
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
        ];

        internal static Set AnyBars = [
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
        ];

        internal static Set GrassSeeds = [
            ItemID.GrassSeeds,
            ItemID.AshGrassSeeds,
            ItemID.JungleGrassSeeds,
            ItemID.MushroomGrassSeeds,
            ItemID.CorruptSeeds,
            ItemID.CrimsonSeeds,
            ItemID.HallowedSeeds,
        ];

        internal static Set GemCritterCages = [
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
        ];

        internal static Set Arrows = [
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
        ];

        internal static Set GemStaves = [
            ItemID.AmethystStaff,
            ItemID.TopazStaff,
            ItemID.SapphireStaff,
            ItemID.EmeraldStaff,
            ItemID.AmberStaff,
            ItemID.RubyStaff,
            ItemID.DiamondStaff,
        ];

        internal static Set Fountains = [
            ItemID.PureWaterFountain,
            ItemID.DesertWaterFountain,
            ItemID.JungleWaterFountain,
            ItemID.IcyWaterFountain,
            ItemID.CorruptWaterFountain,
            ItemID.CrimsonWaterFountain,
            ItemID.HallowedWaterFountain,
            ItemID.BloodWaterFountain,
            ItemID.CavernFountain,
            ItemID.OasisFountain,
        ];

        internal static Set GoldGraves = [
            ItemID.RichGravestone1,
            ItemID.RichGravestone2,
            ItemID.RichGravestone3,
            ItemID.RichGravestone4,
            ItemID.RichGravestone5,
        ];

        internal static Set Watches = [
            ItemID.CopperWatch,
            ItemID.TinWatch,
            ItemID.SilverWatch,
            ItemID.TungstenWatch,
            ItemID.GoldWatch,
            ItemID.PlatinumWatch,
        ];

        internal static Set FishingTrash = [
            ItemID.FishingSeaweed,
            ItemID.OldShoe,
            ItemID.TinCan,
        ];
        #endregion
        #endregion

        #region NPC IDs
        internal static Set TownNPCs = [NPCID.Angler];
        #endregion

        #region Tile IDs
        internal static Set Leaves = [TileID.LeafBlock];
        #endregion

        internal static void load() {
            void createItemSets(params (Func<int, Item, bool> shouldBeInSet, Set storage)[] rules) {
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
            void createNpcSets(params (Func<int, NPC, bool> shouldBeInSet, Set storage)[] rules) {
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
            void createRecipeSets(params (Func<Recipe, bool> shouldBeInSet, Set storage)[] rules) {
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
            void filterDropRules(params (List<IItemDropRule> what, Func<DropRateInfo, bool> when, Set where)[] rules) {
                foreach ((var what, var when, var where) in rules) {
                    where.Clear();

                    List<DropRateInfo> list = [];
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
            void fromBoolSets(params (bool[] when, Set where)[] rules) {
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
                ),
                (
                    (_, item) => item.shoot != -1 && (
                        ContentSamples.ProjectilesByType[item.shoot].aiStyle == ProjAIStyleID.Flail
                        || ContentSamples.ProjectilesByType[item.shoot].aiStyle == ProjAIStyleID.Flairon
                    ),
                    Flails
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
