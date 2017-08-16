using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Utilities;

namespace EddiDataDefinitions
{
    public class CommodityDefinitions
    {
        // Mapping from Elite internal names to common names
        private static Dictionary<string, string> nameMapping = new Dictionary<string, string>
        {
            {"agriculturalmedicines", "agrimedicines"},
            {"atmosphericextractors", "atmosphericprocessors"},
            {"basicnarcotics", "narcotics"},
            {"hazardousenvironmentsuits", "hesuits"},
            {"heliostaticfurnaces", "microbialfurnaces"},
            {"marinesupplies", "marineequipment"},
            //{"mutomimager", "muonimager"},
            {"skimercomponents", "skimmercomponents"},
            {"terrainenrichmentsystems", "landenrichmentsystems"},
            {"trinketsoffortune", "trinketsofhiddenfortune"},
            //{"unknownartifact", "unknownartefact"},
            //{"usscargoancientartefact", "ancientartefact"},
            //{"usscargoexperimentalchemicals", "experimentalchemicals"},
            //{"usscargomilitaryplans", "militaryplans"},
            //{"usscargoprototypetech", "prototypetech"},
            //{"usscargorebeltransmissions", "rebeltransmissions"},
            //{"usscargotechnicalblueprints", "technicalblueprints"},
            //{"usscargotradedata", "tradedata"},
            {"comercialsamples", "commercialsamples"},
        };

        private static Dictionary<long, Commodity> CommoditiesByEliteID = new Dictionary<long, Commodity>
        {
            {128049204, new Commodity(1, "Explosives", "Explosifs","Produits chimiques", 261, false) },
            {128049202, new Commodity(2, "Hydrogen Fuel", "Carburant à base d'hydrogène", "Produits chimiques", 110, false) },
            {128049203, new Commodity(3, "Mineral Oil","Huile minérale", "Produits chimiques", 181, false) },
            {128049205, new Commodity(4, "Pesticides", "Produits chimiques", 241, false) },
            {128049241, new Commodity(5, "Clothing", "Vêtements", "Produits de consommation", 285, false) },
            {128049240, new Commodity(6, "Consumer Technology", "Électronique grand public", "Produits de consommation", 6769, false) },
            {128049238, new Commodity(7, "Domestic Appliances", "Équipement de loisir", "Produits de consommation", 487, false) },
            {128049214, new Commodity(8, "Beer", "Bière", "Drogues légales", 186, false) },
            {128049216, new Commodity(9, "Liquor", "Liqueur", "Drogues légales", 587, false) },
            {128049212, new Commodity(10, "Basic Narcotics", "Narcotiques", "Drogues légales", 9966, false) },
            {128049213, new Commodity(11, "Tobacco", "Tabac", "Drogues légales", 5035, false) },
            {128049215, new Commodity(12, "Wine", "Vin", "Drogues légales", 260, false) },
            {128049177, new Commodity(13, "Algae", "Algues", "Alimentation", 137, false) },
            {128049182, new Commodity(14, "Animalmeat", "Viande", "Alimentation", 1292, false) },
            {128049189, new Commodity(15, "Coffee", "Café", "Alimentation", 1279, false) },
            {128049183, new Commodity(16, "Fish", "Poisson", "Alimentation", 406, false) },
            {128049184, new Commodity(17, "Food Cartridges", "Cartouches alimentaires", "Alimentation", 105, false) },
            {128049178, new Commodity(18, "Fruit and Vegetables", "Fruits et légumes", "Alimentation", 312, false) },
            {128049180, new Commodity(19, "Grain", "Céréales", "Alimentation", 210, false) },
            {128049185, new Commodity(20, "Synthetic Meat", "Viande synthétique",  "Alimentation", 271, false) },
            {128049188, new Commodity(21, "Tea", "Thé", "Alimentation", 1467, false) },
            {128049197, new Commodity(22, "Polymers", "Polymères", "Matériaux industriels", 171, false) },
            {128049199, new Commodity(23, "Semiconductors", "Semi-conducteurs",  "Matériaux industriels", 967, false) },
            {128049200, new Commodity(24, "Superconductors", "Supraconducteurs", "Matériaux industriels", 6609, false) },
            {128064028, new Commodity(25, "Atmospheric Extractors", "Processeurs atmosphériques", "Machines", 357, false) },
            {128049222, new Commodity(26, "Crop Harvesters", "Moissoneuses", "Machines", 2021, false) },
            {128049223, new Commodity(27, "Marine Supplies", "Équipement aquamarin", "Machines", 3916, false) },
            {128049220, new Commodity(28, "Heliostatic Furnaces", "Hauts fournaux microbiens", "Machines", 236, false) },
            {128049221, new Commodity(29, "Mineral Extractors", "Équipement géologique", "Machines", 443, false) },
            {128049217, new Commodity(30, "Power Generators", "Générateurs", "Machines", 458, false) },
            {128049218, new Commodity(31, "Water Purifiers", "Purificateurs d'eau", "Machines", 258, false) },
            {128049208, new Commodity(32, "Agricultural Medicines", "Agri-Médicaments", "Médicaments", 1038, false) },
            {128049210, new Commodity(33, "Basic Medicines", "Médicaments simples", "Médicaments", 279, false) },
            {128049670, new Commodity(34, "Combat Stabilisers", "Stabilisateurs de combat", "Médicaments", 3505, false) },
            {128049209, new Commodity(35, "Performance Enhancers", "Produits dopants", "Médicaments", 6816, false) },
            {128049669, new Commodity(36, "Progenitor Cells", "Cellules souches", "Médicaments", 6779, false) },
            {128049176, new Commodity(37, "Aluminium", "Metals", 340, false) },
            {128049168, new Commodity(38, "Beryllium", "Béryllium", "Metals", 8288, false) },
            {128049162, new Commodity(39, "Cobalt", "Metals", 647, false) },
            {128049175, new Commodity(40, "Copper", "Cuivre", "Metals", 481, false) },
            {128049170, new Commodity(41, "Gallium", "Metals", 5135, false) },
            {128049154, new Commodity(42, "Gold", "Or", "Metals", 9401, false) },
            {128049169, new Commodity(43, "Indium", "Metals", 5727, false) },
            {128049173, new Commodity(44, "Lithium", "Metals", 1596, false) },
            {128049153, new Commodity(45, "Palladium", "Metals", 13298, false) },
            {128049152, new Commodity(46, "Platinum", "Platine", "Metals", 19279, false) },
            {128049155, new Commodity(47, "Silver", "Argent", "Metals", 4775, false) },
            {128049171, new Commodity(48, "Tantalum", "Tantale", "Metals", 3962, false) },
            {128049174, new Commodity(49, "Titanium", "Titane", "Metals", 1006, false) },
            {128049172, new Commodity(50, "Uranium", "Metals", 2705, false) },
            {128049165, new Commodity(51, "Bauxite", "Minéraux", 120, false) },
            {128049156, new Commodity(52, "Bertrandite", "Minéraux", 2374, false) },
            {128049159, new Commodity(53, "Coltan", "Minéraux", 1319, false) },
            {128049158, new Commodity(54, "Gallite", "Minéraux", 1819, false) },
            {128049157, new Commodity(55, "Indite", "Minéraux", 2088, false) },
            {128049161, new Commodity(56, "Lepidolite", "Lépidolite", "Minéraux", 544, false) },
            {128049163, new Commodity(57, "Rutile", "Minéraux", 299, false) },
            {128049160, new Commodity(58, "Uraninite", "Minéraux", 836, false) },
            {128667728, new Commodity(59, "Imperial Slaves", "Esclaves Impériaux", "Esclaves", 15984, false) },
            {128049243, new Commodity(60, "Slaves", "Esclaves", "Esclaves", 10584, false) },
            {128049231, new Commodity(61, "Advanced Catalysers", "Technologie", 2947, false) },
            {128049229, new Commodity(62, "Animal Monitors", "Système de surveillance animale", "Technologie", 324, false) },
            {128049230, new Commodity(63, "Aquaponic Systems", "Systèmes aquaponiques", "Technologie", 314, false) },
            {128049228, new Commodity(64, "Auto Fabricators", "Dispositif d'auto-fabrication", "Technologie", 3734, false) },
            {128049672, new Commodity(65, "Bio Reducing Lichen", "Lichen bioréducteur", "Technologie", 998, false) },
            {128049225, new Commodity(66, "Computer Components", "Composants d'ordinateur", "Technologie", 513, false) },
            {128049226, new Commodity(67, "Hazardous Environment Suits", "Combinaisons de protection", "Technologie", 340, false) },
            {128049232, new Commodity(68, "Terrain Enrichment Systems", "Systèmes d'enrichissement des sols", "Technologie", 4887, false) },
            {128049671, new Commodity(69, "Resonating Separators", "Séparateurs à résonance", "Technologie", 5958, false) },
            {128049227, new Commodity(70, "Robotics", "Robots", "Technologie", 1856, false) },
            {128049190, new Commodity(72, "Leather", "Cuir", "Textiles", 205, false) },
            {128049191, new Commodity(73, "Natural Fabrics", "Fibre textile naturelle", "Textiles", 439, false) },
            {128049193, new Commodity(74, "Synthetic Fabrics", "Tissu synthétique", "Textiles", 211, false) },
            {128049244, new Commodity(75, "Biowaste", "Déchets organiques", "Déchets", 63, false) },
            {128049246, new Commodity(76, "Chemical Waste", "Déchets chimiques", "Déchets", 131, false) },
            {128049248, new Commodity(77, "Scrap", "Ferraille", "Déchets", 48, false) },
            {128049236, new Commodity(78, "Non Lethal Weapons", "Armes incapacitantes", "Armes", 1837, false) },
            {128049233, new Commodity(79, "Personal Weapons", "Armes de poing", "Armes", 4632, false) },
            {128049235, new Commodity(80, "Reactive Armour", "Protection réactive", "Armes", 2113, false) },
            {128049234, new Commodity(81, "Battle Weapons", "Armes militaires", "Armes", 7259, false) },
            {200000009, new Commodity(82, "Toxic Waste", "Déchets toxiques", "Déchets", 287, false) },
            {128668550, new Commodity(83, "Painite", "Minéraux", 40508, false) },
            {128066403, new Commodity(84, "drones", "Limpet", "NonMarketable", 101, false) },
            {300000001, new Commodity(85, "Eranin Pearl Whiskey", "Drogues légales", 9040, true) },
            {300000002, new Commodity(86, "Kamorin Historic Weapons", "Armes", 9766, true) },
            {300000003, new Commodity(87, "Lucan Onion Head", "Drogues légales", 8472, true) },
            {300000004, new Commodity(88, "Motrona Experience Jelly", "Drogues légales", 13129, true) },
            {300000005, new Commodity(89, "Onion Head", "Drogues légales", 8437, true) },
            {300000006, new Commodity(90, "Rusani Old Smokey", "Drogues légales", 11994, true) },
            {300000007, new Commodity(91, "Tarach Spice", "Drogues légales", 8642, true) },
            {300000008, new Commodity(92, "Terra Mater Blood Bores", "Médicaments", 13414, true) },
            {300000009, new Commodity(93, "Wolf Fesh", "Drogues légales", 8399, true) },
            {300000010, new Commodity(94, "Wuthielo Ku Froth", "Drogues légales", 8194, true) },
            {128668548, new Commodity(95, "Ai Relics", "Ai Relics", "Kamorin", 138613, false) },
            {128668551, new Commodity(96, "Antiquities", "Salvage", 115511, false) },
            {128671118, new Commodity(97, "Osmium", "Metals", 7591, false) },
            {128671443, new Commodity(98, "S A P8 Core Container", "Sap 8 Core Container", "Salvage", 59196, false) },
            {128671444, new Commodity(99, "Trinkets Of Fortune", "Trinkets Of Hidden Fortune", "Salvage", 1428, false) },
            {128666754, new Commodity(100, "U S S Cargo Trade Data", "Trade Data", "Salvage", 2790, false) },
            {128672308, new Commodity(101, "Thermal Cooling Units", "Machines", 256, false) },
            {128672313, new Commodity(102, "Skimer Components", "Skimmer Components", "Machines", 859, false) },
            {128672307, new Commodity(103, "Geological Equipment", "Machines", 1661, false) },
            {128672311, new Commodity(104, "Structural Regulators", "Technologie", 1791, false) },
            {128672297, new Commodity(105, "Pyrophyllite", "Minéraux", 1565, false) },
            {128672296, new Commodity(106, "Moissanite", "Minéraux", 8273, false) },
            {128672295, new Commodity(107, "Goslarite", "Minéraux", 916, false) },
            {128672294, new Commodity(108, "Cryolite", "Minéraux", 2266, false) },
            {128672301, new Commodity(109, "Thorium", "Metals", 11513, false) },
            {128672299, new Commodity(110, "Thallium", "Metals", 3618, false) },
            {128672298, new Commodity(111, "Lanthanum", "Metals", 8766, false) },
            {128672300, new Commodity(112, "Bismuth", "Metals", 2284, false) },
            {128672306, new Commodity(113, "Bootleg Liquor", "Drogues légales", 855, false) },
            {128672701, new Commodity(114, "Meta Alloys", "Meta-Alloys", "Matériaux industriels", 88148, false) },
            {128672302, new Commodity(115, "Ceramic Composites", "Matériaux industriels", 232, false) },
            {128672314, new Commodity(116, "Evacuation Shelter", "Produits de consommation", 343, false) },
            {128672303, new Commodity(117, "Synthetic Reagents", "Produits chimiques", 6675, false) },
            {128672305, new Commodity(118, "Surface Stabilisers", "Produits chimiques", 467, false) },
            {128672309, new Commodity(119, "Building Fabricators", "Machines", 980, false) },
            {128672312, new Commodity(121, "Landmines", "Armes", 4602, false) },
            {128672304, new Commodity(122, "Nerve Agents", "Produits chimiques", 13526, false) },
            {200000008, new Commodity(123, "Occupied CryoPod", "Salvage", 5132, false) },
            {128672310, new Commodity(124, "mutomimager", "Muon Imager", "Technologie", 6353, false) },
            {310000001, new Commodity(125, "Lavian Brandy", "Drogues légales", 10365, true) },
            {310000002, new Commodity(126, "usscargoblackbox", "Black Box", "Salvage", 6995, false) },
            {128666755, new Commodity(127, "usscargomilitaryplans", "Military Plans", "Salvage", 9413, false) },
            {128666756, new Commodity(128, "usscargoancientartefact", "Ancient Artefact", "Salvage", 8183, false) },
            {300000012, new Commodity(129, "usscargorareartwork", "Rare Artwork", "Salvage", 7774, false) },
            {128666758, new Commodity(130, "usscargoexperimentalchemicals", "Experimental Chemicals", "Salvage", 3524, false) },
            {128666759, new Commodity(131, "usscargorebeltransmissions", "Rebel Transmissions", "Salvage", 4068, false) },
            {128666760, new Commodity(132, "usscargoprototypetech", "Prototype Tech", "Salvage", 10696, false) },
            {128666761, new Commodity(133, "usscargotechnicalblueprints", "Technical Blueprints", "Salvage", 6333, false) },
            {300000013, new Commodity(134, "HIP 10175 Bush Meat", "Alimentation", 9382, true) },
            {300000014, new Commodity(135, "Albino Quechua Mammoth", "Alimentation", 9687, true) },
            {300000015, new Commodity(136, "Utgaroar Millennial Eggs", "Alimentation", 9163, true) },
            {300000016, new Commodity(137, "Witchhaul Kobe Beef", "Alimentation", 11085, true) },
            {300000017, new Commodity(138, "Karsuki Locusts", "Alimentation", 8543, true) },
            {300000018, new Commodity(139, "Giant Irukama Snails", "Alimentation", 9174, true) },
            {300000019, new Commodity(140, "Baltah Sine Vacuum Krill", "Alimentation", 8479, true) },
            {300000020, new Commodity(141, "Ceti Rabbits", "Alimentation", 9079, true) },
            {300000021, new Commodity(142, "Kachirigin Filter Leeches", "Médicaments", 8227, true) },
            {300000022, new Commodity(143, "Lyrae Weed", "Drogues légales", 8937, true) },
            {300000023, new Commodity(144, "Borasetani Pathogenetics", "Armes", 13679, true) },
            {300000024, new Commodity(145, "HIP 118311 Swarm", "Armes", 13448, true) },
            {300000025, new Commodity(146, "Kongga Ale", "Drogues légales", 8310, true) },
            {300000026, new Commodity(147, "Alacarakmo Skin Art", "Produits de consommation", 8899, true) },
            {300000027, new Commodity(148, "Eleu Thermals", "Produits de consommation", 8507, true) },
            {300000028, new Commodity(149, "Eshu Umbrellas", "Produits de consommation", 9343, true) },
            {300000029, new Commodity(150, "Karetii Couture", "Produits de consommation", 11582, true) },
            {300000030, new Commodity(151, "Njangari Saddles", "Produits de consommation", 8356, true) },
            {300000031, new Commodity(152, "Any Na Coffee", "Alimentation", 9160, true) },
            {300000032, new Commodity(153, "CD-75 Kitten Brand Coffee", "Alimentation", 9571, true) },
            {300000033, new Commodity(154, "Goman Yaupon Coffee", "Alimentation", 8921, true) },
            {300000034, new Commodity(155, "Volkhab Bee Drones", "Machines", 10198, true) },
            {300000035, new Commodity(156, "Kinago Violins", "Produits de consommation", 13030, true) },
            {300000036, new Commodity(157, "Nguna Modern Antiques", "Produits de consommation", 8545, true) },
            {300000037, new Commodity(158, "Rajukru Multi-Stoves", "Produits de consommation", 8378, true) },
            {300000038, new Commodity(159, "Tiolce Waste2Paste Units", "Produits de consommation", 8710, true) },
            {300000039, new Commodity(160, "Chi Eridani Marine Paste", "Alimentation", 8450, true) },
            {300000040, new Commodity(161, "Esuseku Caviar", "Alimentation", 9625, true) },
            {300000041, new Commodity(162, "Live Hecate Sea Worms", "Alimentation", 8737, true) },
            {300000042, new Commodity(163, "Helvetitj Pearls", "Alimentation", 10450, true) },
            {300000043, new Commodity(164, "HIP Proto-Squid", "Alimentation", 8497, true) },
            {300000044, new Commodity(165, "Coquim Spongiform Victuals", "Alimentation", 8077, true) },
            {300000045, new Commodity(166, "Eden Apples Of Aerial", "Alimentation", 8331, true) },
            {300000046, new Commodity(167, "Neritus Berries", "Alimentation", 8497, true) },
            {300000047, new Commodity(168, "Ochoeng Chillies", "Alimentation", 8601, true) },
            {300000048, new Commodity(169, "Deuringas Truffles", "Alimentation", 9232, true) },
            {300000049, new Commodity(170, "HR 7221 Wheat", "Alimentation", 8190, true) },
            {300000050, new Commodity(171, "Jaroua Rice", "Alimentation", 8169, true) },
            {300000051, new Commodity(172, "Belalans Ray Leather", "Textiles", 8519, true) },
            {300000052, new Commodity(173, "Damna Carapaces", "Textiles", 8120, true) },
            {300000053, new Commodity(174, "Rapa Bao Snake Skins", "Textiles", 8285, true) },
            {300000054, new Commodity(175, "Vanayequi Ceratomorpha Fur", "Textiles", 8331, true) },
            {300000055, new Commodity(176, "Bast Snake Gin", "Drogues légales", 8659, true) },
            {300000056, new Commodity(177, "Thrutis Cream", "Drogues légales", 8550, true) },
            {300000057, new Commodity(178, "Wulpa Hyperbore Systems", "Machines", 8726, true) },
            {300000058, new Commodity(179, "Aganippe Rush", "Médicaments", 14220, true) },
            {300000059, new Commodity(180, "Holva Duelling Blades", "Armes", 12493, true) },
            {300000060, new Commodity(181, "Gilya Signature Weapons", "Armes", 13038, true) },
            {300000061, new Commodity(182, "Delta Phoenicis Palms", "Produits chimiques", 8188, true) },
            {300000062, new Commodity(183, "Toxandji Virocide", "Produits chimiques", 8275, true) },
            {300000063, new Commodity(184, "xihecompanions", "Xihe Biomorphic Companions", "Technologie", 11058, true) },
            {300000064, new Commodity(185, "Sanuma Decorative Meat", "Alimentation", 8504, true) },
            {300000065, new Commodity(186, "Ethgreze Tea Buds", "Alimentation", 10197, true) },
            {300000066, new Commodity(187, "Ceremonial Heike Tea", "Alimentation", 9251, true) },
            {300000067, new Commodity(188, "Tanmark Tranquil Tea", "Alimentation", 9177, true) },
            {300000068, new Commodity(189, "Az Cancri Formula 42", "Technologie", 12440, true) },
            {300000069, new Commodity(190, "Kamitra Cigars", "Drogues légales", 12282, true) },
            {300000070, new Commodity(191, "Yaso Kondi Leaf", "Drogues légales", 12171, true) },
            {300000071, new Commodity(192, "Chateau De Aegaeon", "Drogues légales", 8791, true) },
            {300000072, new Commodity(193, "Waters Of Shintara", "Médicaments", 13711, true) },
            {300000073, new Commodity(194, "Ophiuch Exino Artefacts", "Produits de consommation", 10969, true) },
            {300000074, new Commodity(195, "Aepyornis Egg", "Alimentation", 9769, true) },
            {300000075, new Commodity(196, "Saxon Wine", "Drogues légales", 8983, true) },
            {300000076, new Commodity(197, "Centauri Mega Gin", "Drogues légales", 10217, true) },
            {300000077, new Commodity(198, "Anduliga Fire Works", "Produits chimiques", 8519, true) },
            {300000078, new Commodity(199, "Banki Amphibious Leather", "Textiles", 8338, true) },
            {300000079, new Commodity(200, "Cherbones Blood Crystals", "Minéraux", 16714, true) },
            {300000080, new Commodity(201, "Geawen Dance Dust", "Drogues légales", 8618, true) },
            {300000081, new Commodity(202, "Gerasian Gueuze Beer", "Drogues légales", 8215, true) },
            {300000082, new Commodity(203, "Haidne Black Brew", "Alimentation", 8837, true) },
            {300000083, new Commodity(204, "Havasupai Dream Catcher", "Produits de consommation", 14639, true) },
            {300000084, new Commodity(205, "Burnham Bile Distillate", "Drogues légales", 8466, true) },
            {300000085, new Commodity(206, "HIP Organophosphates", "Produits chimiques", 8169, true) },
            {300000086, new Commodity(207, "Jaradharre Puzzle Box", "Produits de consommation", 16816, true) },
            {300000087, new Commodity(208, "Koro Kung Pellets", "Produits chimiques", 8067, true) },
            {300000088, new Commodity(209, "Void Extract Coffee", "Alimentation", 9554, true) },
            {300000089, new Commodity(210, "Honesty Pills", "Médicaments", 8860, true) },
            {300000090, new Commodity(211, "Non Euclidian Exotanks", "Machines", 8526, true) },
            {300000091, new Commodity(212, "LTT Hypersweet", "Alimentation", 8054, true) },
            {300000092, new Commodity(213, "Mechucos High Tea", "Alimentation", 8846, true) },
            {300000093, new Commodity(214, "Medb Starlube", "Matériaux industriels", 8191, true) },
            {300000094, new Commodity(215, "Mokojing Beast Feast", "Alimentation", 9788, true) },
            {300000095, new Commodity(216, "Mukusubii Chitin-Os", "Alimentation", 8359, true) },
            {300000096, new Commodity(217, "Mulachi Giant Fungus", "Alimentation", 7957, true) },
            {300000097, new Commodity(218, "Ngadandari Fire Opals", "Minéraux", 19112, true) },
            {300000098, new Commodity(219, "Tiegfries Synth Silk", "Textiles", 8478, true) },
            {300000099, new Commodity(220, "Uzumoku Low-G Wings", "Produits de consommation", 13845, true) },
            {300000100, new Commodity(221, "V Herculis Body Rub", "Médicaments", 8010, true) },
            {300000101, new Commodity(222, "Wheemete Wheat Cakes", "Alimentation", 8081, true) },
            {300000102, new Commodity(223, "Vega Slimweed", "Médicaments", 9588, true) },
            {300000103, new Commodity(224, "Altairian Skin", "Produits de consommation", 8432, true) },
            {300000104, new Commodity(225, "Pavonis Ear Grubs", "Drogues légales", 8364, true) },
            {300000105, new Commodity(226, "Jotun Mookah", "Produits de consommation", 8780, true) },
            {300000106, new Commodity(227, "Giant Verrix", "Machines", 12496, true) },
            {300000107, new Commodity(228, "Indi Bourbon", "Drogues légales", 8806, true) },
            {300000108, new Commodity(229, "Arouca Conventual Sweets", "Alimentation", 8737, true) },
            {300000109, new Commodity(230, "Tauri Chimes", "Médicaments", 8549, true) },
            {300000110, new Commodity(231, "Zeessze Ant Grub Glue", "Produits de consommation", 8161, true) },
            {300000111, new Commodity(232, "Pantaa Prayer Sticks", "Médicaments", 9177, true) },
            {300000112, new Commodity(233, "Fujin Tea", "Médicaments", 8597, true) },
            {300000113, new Commodity(234, "Chameleon Cloth", "Textiles", 9071, true) },
            {300000114, new Commodity(235, "Orrerian Vicious Brew", "Alimentation", 8342, true) },
            {300000115, new Commodity(236, "Uszaian Tree Grub", "Alimentation", 8578, true) },
            {300000116, new Commodity(237, "Momus Bog Spaniel", "Produits de consommation", 9184, true) },
            {300000117, new Commodity(238, "Diso Ma Corn", "Alimentation", 8134, true) },
            {300000118, new Commodity(239, "Leestian Evil Juice", "Drogues légales", 8220, true) },
            {300000119, new Commodity(240, "bluemilk", "Azure Milk", "Drogues légales", 10805, true) },
            {300000120, new Commodity(241, "alieneggs", "Leathery Eggs", "Produits de consommation", 25067, true) },
            {300000121, new Commodity(242, "Alya Body Soap", "Médicaments", 8218, true) },
            {300000122, new Commodity(243, "Vidavantian Lace", "Produits de consommation", 12615, true) },
            {300000123, new Commodity(244, "Jaques Quinentian Still", "Produits de consommation", 2108, true) },
            {300000124, new Commodity(245, "Soontill Relics", "Produits de consommation", 19885, true) },
            {128668547, new Commodity(246, "unknownartifact", "Unknown Artefact", "Salvage", 290190, false) },
            {128668549, new Commodity(247, "Hafnium178", "Hafnium 178", "Metals", 69098, false) },
            {128668552, new Commodity(248, "Military Intelligence", "Salvage", 55527, false) },
            {300000128, new Commodity(249, "The Hutton Mug", "Produits de consommation", 7986, true) },
            {300000129, new Commodity(250, "Sothis Crystalline Gold", "metals", 19112, true) },
            {300000130, new Commodity(251, "wreckagecomponents", "Salvageable Wreckage", "Salvage", 394, false) },
            {300000131, new Commodity(252, "encripteddatastorage", "Encrypted Data Storage", "Salvage", 806, false) },
            {300000132, new Commodity(253, "Personal Effects", "Salvage", 379, false) },
            {300000133, new Commodity(254, "Commercial Samples", "Salvage", 361, false) },
            {300000134, new Commodity(255, "Tactical Data", "Salvage", 457, false) },
            {300000135, new Commodity(256, "Assault Plans", "Salvage", 446, false) },
            {300000136, new Commodity(257, "Encrypted Correspondence", "Salvage", 372, false) },
            {300000137, new Commodity(258, "Diplomatic Bag", "Salvage", 572, false) },
            {300000138, new Commodity(259, "Scientific Research", "Salvage", 635, false) },
            {300000139, new Commodity(260, "Scientific Samples", "Salvage", 772, false) },
            {300000140, new Commodity(261, "Political Prisoner", "Salvage", 5132, false) },
            {300000141, new Commodity(262, "Hostage", "Salvage", 2427, false) },
            {300000142, new Commodity(263, "Geological Samples", "Salvage", 446, false) },
            {300000143, new Commodity(264, "Master Chefs", "Slavery", 20590, true) },
            {300000144, new Commodity(265, "Crystalline Spheres", "Produits de consommation", 12216, true) },
            {300000145, new Commodity(266, "Taaffeite", "Minéraux", 20696, false) },
            {300000146, new Commodity(267, "Jadeite", "Minéraux", 13474, false) },
            {300000147, new Commodity(268, "Unstable Data Core", "Salvage", 2427, false) },
            {300000148, new Commodity(269, "Onionhead Alpha Strain", "Drogues légales", 8437, true) },
            {300000149, new Commodity(270, "damagedescapepod", "Occupied Escape Pod", "Salvage", 4474, false) },
            {128049166, new Commodity(271, "Water", "Produits chimiques", 120, false) },
            {300000150, new Commodity(272, "Onionhead Beta Strain", "Drogues légales", 8437, true) },
            {128673845, new Commodity(273, "Praseodymium", "Metals", 7156, false) },
            {128673846, new Commodity(274, "Bromellite", "Minéraux", 7062, false) },
            {128673847, new Commodity(275, "Samarium", "Metals", 6330, false) },
            {128673848, new Commodity(276, "Low Temperature Diamond", "Minéraux", 57445, false) },
            {128673850, new Commodity(277, "Hydrogen Peroxide", "Produits chimiques", 917, false) },
            {128673851, new Commodity(278, "Liquid Oxygen", "Produits chimiques", 263, false) },
            {128673852, new Commodity(279, "methanolmonohydratecrystals", "Methanol Monohydrate", "Minéraux", 2282, false) },
            {128673853, new Commodity(280, "Lithium Hydroxide", "Minéraux", 5646, false) },
            {128673854, new Commodity(281, "Methane Clathrate", "Minéraux", 629, false) },
            {128673855, new Commodity(282, "Insulating Membrane", "Matériaux industriels", 7837, false) },
            {128673856, new Commodity(283, "C M M Composite", "CMM Composite", "Matériaux industriels", 3132, false) },
            {128673857, new Commodity(284, "Cooling Hoses", "Micro-Weave Cooling Hoses", "Matériaux industriels", 403, false) },
            {128673858, new Commodity(285, "Neofabric Insulation", "Matériaux industriels", 2769, false) },
            {128673859, new Commodity(286, "Articulation Motors", "Machines", 4997, false) },
            {128673860, new Commodity(287, "H N Shock Mount", "HN Shock Mount", "Machines", 406, false) },
            {128673861, new Commodity(288, "Emergency Power Cells", "Machines", 1011, false) },
            {128673862, new Commodity(289, "Power Converter", "Machines", 246, false) },
            {128673863, new Commodity(290, "powergridassembly", "Energy Grid Assembly", "Machines", 1684, false) },
            {128673864, new Commodity(291, "Power Transfer Conduits", "Machines", 857, false) },
            {128673865, new Commodity(292, "Radiation Baffle", "Machines", 383, false) },
            {128673866, new Commodity(293, "Exhaust Manifold", "Machines", 479, false) },
            {128673867, new Commodity(294, "Reinforced Mounting Plate", "Machines", 1074, false) },
            {128673868, new Commodity(295, "Heatsink Interlink", "Machines", 729, false) },
            {128673869, new Commodity(296, "Magnetic Emitter Coil", "Machines", 199, false) },
            {128673870, new Commodity(297, "Modular Terminals", "Machines", 695, false) },
            {128673871, new Commodity(298, "Nanobreakers", "Technologie", 639, false) },
            {128673872, new Commodity(299, "Telemetry Suite", "Technologie", 2080, false) },
            {128673873, new Commodity(300, "Micro Controllers", "Technologie", 3274, false) },
            {128673874, new Commodity(301, "Ion Distributor", "Technologie", 1133, false) },
            {128673875, new Commodity(302, "Hardware Diagnostic Sensor", "Technologie", 4337, false) },
            {128682044, new Commodity(303, "Conductive Fabrics", "Textiles", 507, false) },
            {128682045, new Commodity(304, "Military Grade Fabrics", "Textiles", 708, false) },
            {128682046, new Commodity(305, "Advanced Medicines", "Médicaments", 1259, false) },
            {128682047, new Commodity(306, "Medical Diagnostic Equipment", "Technologie", 2848, false) },
            {128682048, new Commodity(307, "Survival Equipment", "Produits de consommation", 485, false) },
            {300000151, new Commodity(308, "Data Core", "Salvage", 2872, false) },
            {300000152, new Commodity(309, "Galactic Travel Guide", "Salvage", 332, false) },
            {300000153, new Commodity(310, "Mysterious Idol", "Salvage", 15196, false) },
            {300000154, new Commodity(311, "Prohibited Research Materials", "Salvage", 46607, false) },
            {300000155, new Commodity(312, "Antimatter Containment Unit", "Salvage", 26608, false) },
            {300000156, new Commodity(313, "Space Pioneer Relics", "Salvage", 7342, false) },
            {300000157, new Commodity(314, "Fossil Remnants", "Salvage", 9927, false) },
            {300000158, new Commodity(315, "Unknown Probe", "Salvage", 411003, false) },
            {300000159, new Commodity(316, "Precious Gems", "Salvage", 109641, false) },
            {300000160, new Commodity(317, "Unknown Link", "Salvage", 31350, false) },
            {300000161, new Commodity(318, "Unknown Biological Matter", "Salvage", 25479, false) },
            {300000162, new Commodity(319, "Unknown Resin", "Salvage", 18652, false) },
            {300000163, new Commodity(320, "Unknown Technology Samples", "Salvage", 22551, false) },
            // Items for which we do not have EDDB IDs
            {200000001, new Commodity(10001, "Ancient Orb", "Ancient Artifacts", 0, false) },
            {200000002, new Commodity(10002, "Ancient Urn", "Ancient Artifacts", 0, false) },
            {200000003, new Commodity(10003, "Ancient Tablet", "Ancient Artifacts", 0, false) },
            {200000004, new Commodity(10004, "Ancient Casket", "Ancient Artifacts", 0, false) },
            {200000005, new Commodity(10005, "Ancient Relic", "Ancient Artifacts", 0, false) },
            {200000006, new Commodity(10006, "Ancient Totem", "Ancient Artifacts", 0, false) },
            {200000007, new Commodity(10007, "smallexplorationdatacash", "Small Exploration Data Cache", "Salvage", 0, false) },
            {200000010, new Commodity(10010, "largeexplorationdatacash", "Large Exploration Data Cache", "Salvage", 0, false) },
            {200000011, new Commodity(10011, "unknownartifact2", "Unknown Artefact (2)", "Salvage", 0, false) },
            {200000012, new Commodity(10012, "siriuscommercialcontracts", "Sirius Commerical Contracts", "Powerplay", 0, false) },
            {200000013, new Commodity(10013, "siriusindustrialequipment", "Sirius Inustrial Equipment", "Powerplay", 0, false) },
            {200000014, new Commodity(10014, "siriusfranchisepackage", "Sirius Franchise Package", "Powerplay", 0, false) },
            {200000015, new Commodity(10015, "republicangarisonsupplies", "Repiblic Garrison Supplies", "Powerplay", 0, false) },
        };

        private static Dictionary<string, Commodity> CommoditiesByName = CommoditiesByEliteID.ToDictionary(kp => kp.Value.name.ToLowerInvariant().Replace(" ", "").Replace(".", "").Replace("-", ""), kp => kp.Value);
        private static Dictionary<string, Commodity> CommoditiesByEDName = CommoditiesByEliteID.ToDictionary(kp => kp.Value.EDName.ToLowerInvariant().Replace(" ", "").Replace(".", "").Replace("-", ""), kp => kp.Value);

        public static Commodity CommodityFromEliteID(long id)
        {
            Commodity Commodity = new Commodity();

            Commodity Template;
            if (CommoditiesByEliteID.TryGetValue(id, out Template))
            {
                Commodity.EDDBID = Template.EDDBID;
                Commodity.EDName = Template.EDName;
                Commodity.name = Template.name;
                Commodity.category = Template.category;
                Commodity.rare = Template.rare;
                Commodity.avgprice = Template.avgprice;
            }
            return Commodity;
        }

        public static Commodity FromName(string name)
        {
            if (name == null)
            {
                return null;
            }

            Commodity Commodity = new Commodity();

            string cleanedName = name.ToLowerInvariant()
                .Replace("$", "") // Header for types from mining and mission events
                .Replace("_name;", "") // Trailer for types from mining and mission events
                ;

            // Map from ED name to sensible name
            string edName;
            nameMapping.TryGetValue(cleanedName, out edName);

            // Now try to fetch the commodity by either ED or real name
            Commodity Template = null;
            bool found = false;

            if (edName != null)
            {
                found = CommoditiesByEDName.TryGetValue(edName, out Template);
                if (!found)
                {
                    found = CommoditiesByName.TryGetValue(edName, out Template);
                }
            }
            if (!found)
            {
                found = CommoditiesByEDName.TryGetValue(cleanedName, out Template);
            }
            if (!found)
            {
                found = CommoditiesByName.TryGetValue(cleanedName, out Template);
            }
            if (found)
            {
                Commodity.EDDBID = Template?.EDDBID ?? Commodity.EDDBID;
                Commodity.EDName = Template?.EDName ?? Commodity.EDName;
                Commodity.name = Template?.name ?? Commodity.name;
                Commodity.category = Template?.category ?? Commodity.category;
                Commodity.rare = Template?.rare ?? Commodity.rare;
                Commodity.avgprice = Template?.avgprice ?? Commodity.avgprice;
            }
            else
            {
                Logging.Report("Unknown commodity", @"{""name"":""" + name + @"""}");

                // Put some basic information in place
                Commodity.EDName = name;
                Commodity.name = Regex.Replace(name.Replace("$", "").Replace("_Name;", ""), "([a-z])([A-Z])", "$1 $2");
            }
            return Commodity;
        }
    }
}

