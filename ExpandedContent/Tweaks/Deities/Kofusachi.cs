﻿using ExpandedContent.Config;
using ExpandedContent.Extensions;
using ExpandedContent.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandedContent.Tweaks.Deities {
    internal class Kofusachi {
        private static readonly BlueprintFeature ChaosDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("8c7d778bc39fec642befc1435b00f613");
        private static readonly BlueprintFeature CharmDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("f1ceba79ee123cc479cece27bc994ff2");
        private static readonly BlueprintFeature GoodDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("882521af8012fc749930b03dc18a69de");
        private static readonly BlueprintFeature LuckDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("d4e192475bb1a1045859c7664addd461");
        private static readonly BlueprintFeature TravelDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("c008853fe044bd442ae8bd22260592b7");
        private static readonly BlueprintFeature CrusaderSpellbook = Resources.GetBlueprint<BlueprintFeature>("673d39f7da699aa408cdda6282e7dcc0");
        private static readonly BlueprintFeature ClericSpellbook = Resources.GetBlueprint<BlueprintFeature>("4673d19a0cf2fab4f885cc4d1353da33");
        private static readonly BlueprintFeature InquisitorSpellbook = Resources.GetBlueprint<BlueprintFeature>("57fab75111f377248810ece84193a5a5");
        private static readonly BlueprintFeature ChannelPositiveAllowed = Resources.GetBlueprint<BlueprintFeature>("8c769102f3996684fb6e09a2c4e7e5b9");
        private static readonly BlueprintCharacterClass ClericClass = Resources.GetBlueprint<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
        private static readonly BlueprintCharacterClass InquistorClass = Resources.GetBlueprint<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
        private static readonly BlueprintCharacterClass WarpriestClass = Resources.GetBlueprint<BlueprintCharacterClass>("30b5e47d47a0e37438cc5a80c96cfb99");



        public static void AddKofusachiFeature() {

            BlueprintItem MasterworkQuarterstaff = Resources.GetBlueprint<BlueprintItem>("ad1a532601f8b644991d5012adccee6c");

            BlueprintArchetype FeralChampionArchetype = Resources.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
            BlueprintArchetype PriestOfBalance = Resources.GetBlueprint<BlueprintArchetype>("a4560e3fb5d247d68fb1a2738fcc0855");

            BlueprintFeature QuarterstaffProficiency = Resources.GetBlueprint<BlueprintFeature>("aed4f88b52ae0fb468895f90da854ad4");
            var KofusachiIcon = AssetLoader.LoadInternal("Deities", "Icon_Kofusachi.jpg");
            var KofusachiFeature = Helpers.CreateBlueprint<BlueprintFeature>("KofusachiFeature", (bp => {

                bp.SetName("Kofusachi");
                bp.SetDescription("\nTitles: The Laughing God   " +
                    "\nAlignment: Chaotic Good   " +
                    "\nAreas of Concern: Abundance, Discovery, Happiness, Prosperity   " +
                    "\nDomains: Chaos, Charm, Good, Luck, Travel   " +
                    "\nSubdomains: Azata, Exploration, Fate, Love, Lust,  Trade   " +
                    "\nFavoured Weapon: Quarterstaff   " +
                    "\nHoly Symbol: String of seven coins   " +
                    "\nSacred Animal: Dog   " +
                    "\nKofusachi, the Laughing God, is the deity of happiness, prosperity, and abundance. His blessing is invoked when a " +
                    "child is born, at weddings, before business deals, and at the beginning of long journeys. He is depicted as a plump, bald man, " +
                    "always smiling, with bare, calloused feet, a walking stick in hand, and a dog at his heels. An incurable wanderer and inveterate " +
                    "libertine, Kofusachi has taken numerous gods and goddesses as lovers. Though his wanderlust always keeps such relationships from " +
                    "becoming too serious, Kofusachi is fast friends with Daikitsu, Desna, and Shelyn.");
                bp.m_Icon = KofusachiIcon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClericClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = PriestOfBalance.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = WarpriestClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = FeralChampionArchetype.ToReference<BlueprintArchetypeReference>();
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = AlignmentMaskType.NeutralGood | AlignmentMaskType.ChaoticGood | AlignmentMaskType.ChaoticNeutral;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { ChannelPositiveAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { ChaosDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { CharmDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { GoodDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { LuckDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { TravelDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<ForbidSpellbookOnAlignmentDeviation>(c => {
                    c.m_Spellbooks = new BlueprintSpellbookReference[1] { CrusaderSpellbook.ToReference<BlueprintSpellbookReference>() };
                    c.m_Spellbooks = new BlueprintSpellbookReference[1] { ClericSpellbook.ToReference<BlueprintSpellbookReference>() };
                    c.m_Spellbooks = new BlueprintSpellbookReference[1] { InquisitorSpellbook.ToReference<BlueprintSpellbookReference>() };
                });

                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = ClericClass.ToReference<BlueprintCharacterClassReference>();


                    c.m_Feature = QuarterstaffProficiency.ToReference<BlueprintFeatureReference>();

                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                               InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                               WarpriestClass.ToReference<BlueprintCharacterClassReference>() };
                });
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { MasterworkQuarterstaff.ToReference<BlueprintItemReference>() };
                    c.m_RestrictedByClass = new BlueprintCharacterClassReference[3] {
                                ClericClass.ToReference<BlueprintCharacterClassReference>(),
                                InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                                WarpriestClass.ToReference<BlueprintCharacterClassReference>()
                    };
                });
            }));

        }
    }

}