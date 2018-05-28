using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmashHandler.DataTypes
{
    public class CharacterDetailed
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty("slug_name")]
        public string SlugName { get; set; }
        [JsonProperty("game")]
        public int Game { get; set; }
        [JsonProperty("game_slug")]
        public string GameSlug { get; set; }
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
    }

    public class RootCharacters
    {
        private List<CharacterDetailed> characters = null;
        public List<CharacterDetailed> AllCharacters
        {
            get
            {
                if (characters == null)
                {
                    characters= new List<CharacterDetailed>()
                    {
                        #region CharacterList
                        Character0,
Character1,
Character2,
Character3,
Character4,
Character5,
Character6,
Character7,
Character8,
Character9,
Character10,
Character11,
Character12,
Character13,
Character14,
Character15,
Character16,
Character17,
Character18,
Character19,
Character20,
Character21,
Character22,
Character23,
Character24,
Character25,
Character26,
Character27,
Character28,
Character29,
Character30,
Character31,
Character32,
Character33,
Character34,
Character35,
Character36,
Character37,
Character38,
Character39,
Character40,
Character41,
Character42,
Character43,
Character44,
Character45,
Character46,
Character47,
Character48,
Character49,
Character50,
Character51,
Character52,
Character53,
Character54,
Character55,
Character56,
Character57,
Character58,
Character59,
Character60,
Character61,
Character62,
Character63,
Character64,
Character65,
Character66,
Character67,
Character68,
Character69,
Character70,
Character71,
Character72,
Character73,
Character74,
Character75,
Character76,
Character77,
Character78,
Character79,
Character80,
Character81,
Character82,
Character83,
Character84,
Character85,
Character86,
Character87,
Character88,
Character89,
Character90,
Character91,
Character92,
Character93,
Character94,
Character95,
Character96,
Character97,
Character98,
Character99,
Character100,
Character101,
Character102,
Character103,
Character104,
Character105,
Character106,
Character107,
Character108,
Character109,
Character110,
Character111,
Character112,
Character113,
Character114,
Character115,
Character116,
Character117,
Character118,
Character119,
Character120,
Character121,
Character122,
Character123,
Character124,
Character125,
Character126,
Character127,
Character128,
Character129,
Character130,
Character131,
Character132,
Character133,
Character134,
Character135,
Character136,
Character137,
Character138,
Character139,
Character140,
Character141,
Character142,
Character143,
Character144,
Character145,
Character146,
Character147,
Character148,
Character149,
Character150,
Character151,
Character152,
Character153,
Character154,
Character155,
Character156,
Character157,
Character158,
Character159,
Character160,
Character161,
Character162,
Character163,
Character164,
Character165,
Character166,
Character167,
Character168,
Character169,
Character170,
Character171,
Character172,
Character173,
Character174,
Character175,
Character176,
Character177,
Character178,
Character179,
Character180,
Character181,
Character182,
Character183,
Character184,
Character185,
Character186,
Character187,
Character188,
Character189,
Character190,
Character191,
Character192,
Character193,
Character194,
Character195,
Character196,
Character197,
Character198,
Character199,
Character200,
Character201,
Character202,
Character203,
Character204,
Character205,
Character206,
Character207,
Character208,
Character209,
Character210,
Character211,
Character212,
Character213,
Character214,
Character215,
Character216,
Character217,
Character218,
Character219,
Character220,
Character221,
Character222,
Character223,
Character224,
Character225,
Character226,
Character227,
Character228,
Character229,
Character230,
Character231,
Character232,
Character233,
Character234,
Character235,
Character236,
Character237,
Character238,
Character239,
Character240,
Character241,
Character242,
Character243,
Character244,
Character245,
Character246,
Character247,
Character248,
Character249,
Character250,
Character251,
Character252,
Character253,
Character254,
Character255,
Character256,
Character257,
Character258,
Character259,
Character260,
Character261,
Character262,
Character263,
Character264,
Character265,
Character266,
Character267,
Character268,
Character269,
Character270,
Character271,
Character272,
Character273,
Character274,
Character275,
Character276,
Character277,
Character278,
Character279
#endregion

                    };
                }
                return characters;
            }
            set { characters = value; }
        }

        #region Characters
        [JsonProperty("0")]
        public CharacterDetailed Character0 { get; set; }
        [JsonProperty("1")]
        public CharacterDetailed Character1 { get; set; }
        [JsonProperty("2")]
        public CharacterDetailed Character2 { get; set; }
        [JsonProperty("3")]
        public CharacterDetailed Character3 { get; set; }
        [JsonProperty("4")]
        public CharacterDetailed Character4 { get; set; }
        [JsonProperty("5")]
        public CharacterDetailed Character5 { get; set; }
        [JsonProperty("6")]
        public CharacterDetailed Character6 { get; set; }
        [JsonProperty("7")]
        public CharacterDetailed Character7 { get; set; }
        [JsonProperty("8")]
        public CharacterDetailed Character8 { get; set; }
        [JsonProperty("9")]
        public CharacterDetailed Character9 { get; set; }
        [JsonProperty("10")]
        public CharacterDetailed Character10 { get; set; }
        [JsonProperty("11")]
        public CharacterDetailed Character11 { get; set; }
        [JsonProperty("12")]
        public CharacterDetailed Character12 { get; set; }
        [JsonProperty("13")]
        public CharacterDetailed Character13 { get; set; }
        [JsonProperty("14")]
        public CharacterDetailed Character14 { get; set; }
        [JsonProperty("15")]
        public CharacterDetailed Character15 { get; set; }
        [JsonProperty("16")]
        public CharacterDetailed Character16 { get; set; }
        [JsonProperty("17")]
        public CharacterDetailed Character17 { get; set; }
        [JsonProperty("18")]
        public CharacterDetailed Character18 { get; set; }
        [JsonProperty("19")]
        public CharacterDetailed Character19 { get; set; }
        [JsonProperty("20")]
        public CharacterDetailed Character20 { get; set; }
        [JsonProperty("21")]
        public CharacterDetailed Character21 { get; set; }
        [JsonProperty("22")]
        public CharacterDetailed Character22 { get; set; }
        [JsonProperty("23")]
        public CharacterDetailed Character23 { get; set; }
        [JsonProperty("24")]
        public CharacterDetailed Character24 { get; set; }
        [JsonProperty("25")]
        public CharacterDetailed Character25 { get; set; }
        [JsonProperty("26")]
        public CharacterDetailed Character26 { get; set; }
        [JsonProperty("27")]
        public CharacterDetailed Character27 { get; set; }
        [JsonProperty("28")]
        public CharacterDetailed Character28 { get; set; }
        [JsonProperty("29")]
        public CharacterDetailed Character29 { get; set; }
        [JsonProperty("30")]
        public CharacterDetailed Character30 { get; set; }
        [JsonProperty("31")]
        public CharacterDetailed Character31 { get; set; }
        [JsonProperty("32")]
        public CharacterDetailed Character32 { get; set; }
        [JsonProperty("33")]
        public CharacterDetailed Character33 { get; set; }
        [JsonProperty("34")]
        public CharacterDetailed Character34 { get; set; }
        [JsonProperty("35")]
        public CharacterDetailed Character35 { get; set; }
        [JsonProperty("36")]
        public CharacterDetailed Character36 { get; set; }
        [JsonProperty("37")]
        public CharacterDetailed Character37 { get; set; }
        [JsonProperty("38")]
        public CharacterDetailed Character38 { get; set; }
        [JsonProperty("39")]
        public CharacterDetailed Character39 { get; set; }
        [JsonProperty("40")]
        public CharacterDetailed Character40 { get; set; }
        [JsonProperty("41")]
        public CharacterDetailed Character41 { get; set; }
        [JsonProperty("42")]
        public CharacterDetailed Character42 { get; set; }
        [JsonProperty("43")]
        public CharacterDetailed Character43 { get; set; }
        [JsonProperty("44")]
        public CharacterDetailed Character44 { get; set; }
        [JsonProperty("45")]
        public CharacterDetailed Character45 { get; set; }
        [JsonProperty("46")]
        public CharacterDetailed Character46 { get; set; }
        [JsonProperty("47")]
        public CharacterDetailed Character47 { get; set; }
        [JsonProperty("48")]
        public CharacterDetailed Character48 { get; set; }
        [JsonProperty("49")]
        public CharacterDetailed Character49 { get; set; }
        [JsonProperty("50")]
        public CharacterDetailed Character50 { get; set; }
        [JsonProperty("51")]
        public CharacterDetailed Character51 { get; set; }
        [JsonProperty("52")]
        public CharacterDetailed Character52 { get; set; }
        [JsonProperty("53")]
        public CharacterDetailed Character53 { get; set; }
        [JsonProperty("54")]
        public CharacterDetailed Character54 { get; set; }
        [JsonProperty("55")]
        public CharacterDetailed Character55 { get; set; }
        [JsonProperty("56")]
        public CharacterDetailed Character56 { get; set; }
        [JsonProperty("57")]
        public CharacterDetailed Character57 { get; set; }
        [JsonProperty("58")]
        public CharacterDetailed Character58 { get; set; }
        [JsonProperty("59")]
        public CharacterDetailed Character59 { get; set; }
        [JsonProperty("60")]
        public CharacterDetailed Character60 { get; set; }
        [JsonProperty("61")]
        public CharacterDetailed Character61 { get; set; }
        [JsonProperty("62")]
        public CharacterDetailed Character62 { get; set; }
        [JsonProperty("63")]
        public CharacterDetailed Character63 { get; set; }
        [JsonProperty("64")]
        public CharacterDetailed Character64 { get; set; }
        [JsonProperty("65")]
        public CharacterDetailed Character65 { get; set; }
        [JsonProperty("66")]
        public CharacterDetailed Character66 { get; set; }
        [JsonProperty("67")]
        public CharacterDetailed Character67 { get; set; }
        [JsonProperty("68")]
        public CharacterDetailed Character68 { get; set; }
        [JsonProperty("69")]
        public CharacterDetailed Character69 { get; set; }
        [JsonProperty("70")]
        public CharacterDetailed Character70 { get; set; }
        [JsonProperty("71")]
        public CharacterDetailed Character71 { get; set; }
        [JsonProperty("72")]
        public CharacterDetailed Character72 { get; set; }
        [JsonProperty("73")]
        public CharacterDetailed Character73 { get; set; }
        [JsonProperty("74")]
        public CharacterDetailed Character74 { get; set; }
        [JsonProperty("75")]
        public CharacterDetailed Character75 { get; set; }
        [JsonProperty("76")]
        public CharacterDetailed Character76 { get; set; }
        [JsonProperty("77")]
        public CharacterDetailed Character77 { get; set; }
        [JsonProperty("78")]
        public CharacterDetailed Character78 { get; set; }
        [JsonProperty("79")]
        public CharacterDetailed Character79 { get; set; }
        [JsonProperty("80")]
        public CharacterDetailed Character80 { get; set; }
        [JsonProperty("81")]
        public CharacterDetailed Character81 { get; set; }
        [JsonProperty("82")]
        public CharacterDetailed Character82 { get; set; }
        [JsonProperty("83")]
        public CharacterDetailed Character83 { get; set; }
        [JsonProperty("84")]
        public CharacterDetailed Character84 { get; set; }
        [JsonProperty("85")]
        public CharacterDetailed Character85 { get; set; }
        [JsonProperty("86")]
        public CharacterDetailed Character86 { get; set; }
        [JsonProperty("87")]
        public CharacterDetailed Character87 { get; set; }
        [JsonProperty("88")]
        public CharacterDetailed Character88 { get; set; }
        [JsonProperty("89")]
        public CharacterDetailed Character89 { get; set; }
        [JsonProperty("90")]
        public CharacterDetailed Character90 { get; set; }
        [JsonProperty("91")]
        public CharacterDetailed Character91 { get; set; }
        [JsonProperty("92")]
        public CharacterDetailed Character92 { get; set; }
        [JsonProperty("93")]
        public CharacterDetailed Character93 { get; set; }
        [JsonProperty("94")]
        public CharacterDetailed Character94 { get; set; }
        [JsonProperty("95")]
        public CharacterDetailed Character95 { get; set; }
        [JsonProperty("96")]
        public CharacterDetailed Character96 { get; set; }
        [JsonProperty("97")]
        public CharacterDetailed Character97 { get; set; }
        [JsonProperty("98")]
        public CharacterDetailed Character98 { get; set; }
        [JsonProperty("99")]
        public CharacterDetailed Character99 { get; set; }
        [JsonProperty("100")]
        public CharacterDetailed Character100 { get; set; }
        [JsonProperty("101")]
        public CharacterDetailed Character101 { get; set; }
        [JsonProperty("102")]
        public CharacterDetailed Character102 { get; set; }
        [JsonProperty("103")]
        public CharacterDetailed Character103 { get; set; }
        [JsonProperty("104")]
        public CharacterDetailed Character104 { get; set; }
        [JsonProperty("105")]
        public CharacterDetailed Character105 { get; set; }
        [JsonProperty("106")]
        public CharacterDetailed Character106 { get; set; }
        [JsonProperty("107")]
        public CharacterDetailed Character107 { get; set; }
        [JsonProperty("108")]
        public CharacterDetailed Character108 { get; set; }
        [JsonProperty("109")]
        public CharacterDetailed Character109 { get; set; }
        [JsonProperty("110")]
        public CharacterDetailed Character110 { get; set; }
        [JsonProperty("111")]
        public CharacterDetailed Character111 { get; set; }
        [JsonProperty("112")]
        public CharacterDetailed Character112 { get; set; }
        [JsonProperty("113")]
        public CharacterDetailed Character113 { get; set; }
        [JsonProperty("114")]
        public CharacterDetailed Character114 { get; set; }
        [JsonProperty("115")]
        public CharacterDetailed Character115 { get; set; }
        [JsonProperty("116")]
        public CharacterDetailed Character116 { get; set; }
        [JsonProperty("117")]
        public CharacterDetailed Character117 { get; set; }
        [JsonProperty("118")]
        public CharacterDetailed Character118 { get; set; }
        [JsonProperty("119")]
        public CharacterDetailed Character119 { get; set; }
        [JsonProperty("120")]
        public CharacterDetailed Character120 { get; set; }
        [JsonProperty("121")]
        public CharacterDetailed Character121 { get; set; }
        [JsonProperty("122")]
        public CharacterDetailed Character122 { get; set; }
        [JsonProperty("123")]
        public CharacterDetailed Character123 { get; set; }
        [JsonProperty("124")]
        public CharacterDetailed Character124 { get; set; }
        [JsonProperty("125")]
        public CharacterDetailed Character125 { get; set; }
        [JsonProperty("126")]
        public CharacterDetailed Character126 { get; set; }
        [JsonProperty("127")]
        public CharacterDetailed Character127 { get; set; }
        [JsonProperty("128")]
        public CharacterDetailed Character128 { get; set; }
        [JsonProperty("129")]
        public CharacterDetailed Character129 { get; set; }
        [JsonProperty("130")]
        public CharacterDetailed Character130 { get; set; }
        [JsonProperty("131")]
        public CharacterDetailed Character131 { get; set; }
        [JsonProperty("132")]
        public CharacterDetailed Character132 { get; set; }
        [JsonProperty("133")]
        public CharacterDetailed Character133 { get; set; }
        [JsonProperty("134")]
        public CharacterDetailed Character134 { get; set; }
        [JsonProperty("135")]
        public CharacterDetailed Character135 { get; set; }
        [JsonProperty("136")]
        public CharacterDetailed Character136 { get; set; }
        [JsonProperty("137")]
        public CharacterDetailed Character137 { get; set; }
        [JsonProperty("138")]
        public CharacterDetailed Character138 { get; set; }
        [JsonProperty("139")]
        public CharacterDetailed Character139 { get; set; }
        [JsonProperty("140")]
        public CharacterDetailed Character140 { get; set; }
        [JsonProperty("141")]
        public CharacterDetailed Character141 { get; set; }
        [JsonProperty("142")]
        public CharacterDetailed Character142 { get; set; }
        [JsonProperty("143")]
        public CharacterDetailed Character143 { get; set; }
        [JsonProperty("144")]
        public CharacterDetailed Character144 { get; set; }
        [JsonProperty("145")]
        public CharacterDetailed Character145 { get; set; }
        [JsonProperty("146")]
        public CharacterDetailed Character146 { get; set; }
        [JsonProperty("147")]
        public CharacterDetailed Character147 { get; set; }
        [JsonProperty("148")]
        public CharacterDetailed Character148 { get; set; }
        [JsonProperty("149")]
        public CharacterDetailed Character149 { get; set; }
        [JsonProperty("150")]
        public CharacterDetailed Character150 { get; set; }
        [JsonProperty("151")]
        public CharacterDetailed Character151 { get; set; }
        [JsonProperty("152")]
        public CharacterDetailed Character152 { get; set; }
        [JsonProperty("153")]
        public CharacterDetailed Character153 { get; set; }
        [JsonProperty("154")]
        public CharacterDetailed Character154 { get; set; }
        [JsonProperty("155")]
        public CharacterDetailed Character155 { get; set; }
        [JsonProperty("156")]
        public CharacterDetailed Character156 { get; set; }
        [JsonProperty("157")]
        public CharacterDetailed Character157 { get; set; }
        [JsonProperty("158")]
        public CharacterDetailed Character158 { get; set; }
        [JsonProperty("159")]
        public CharacterDetailed Character159 { get; set; }
        [JsonProperty("160")]
        public CharacterDetailed Character160 { get; set; }
        [JsonProperty("161")]
        public CharacterDetailed Character161 { get; set; }
        [JsonProperty("162")]
        public CharacterDetailed Character162 { get; set; }
        [JsonProperty("163")]
        public CharacterDetailed Character163 { get; set; }
        [JsonProperty("164")]
        public CharacterDetailed Character164 { get; set; }
        [JsonProperty("165")]
        public CharacterDetailed Character165 { get; set; }
        [JsonProperty("166")]
        public CharacterDetailed Character166 { get; set; }
        [JsonProperty("167")]
        public CharacterDetailed Character167 { get; set; }
        [JsonProperty("168")]
        public CharacterDetailed Character168 { get; set; }
        [JsonProperty("169")]
        public CharacterDetailed Character169 { get; set; }
        [JsonProperty("170")]
        public CharacterDetailed Character170 { get; set; }
        [JsonProperty("171")]
        public CharacterDetailed Character171 { get; set; }
        [JsonProperty("172")]
        public CharacterDetailed Character172 { get; set; }
        [JsonProperty("173")]
        public CharacterDetailed Character173 { get; set; }
        [JsonProperty("174")]
        public CharacterDetailed Character174 { get; set; }
        [JsonProperty("175")]
        public CharacterDetailed Character175 { get; set; }
        [JsonProperty("176")]
        public CharacterDetailed Character176 { get; set; }
        [JsonProperty("177")]
        public CharacterDetailed Character177 { get; set; }
        [JsonProperty("178")]
        public CharacterDetailed Character178 { get; set; }
        [JsonProperty("179")]
        public CharacterDetailed Character179 { get; set; }
        [JsonProperty("180")]
        public CharacterDetailed Character180 { get; set; }
        [JsonProperty("181")]
        public CharacterDetailed Character181 { get; set; }
        [JsonProperty("182")]
        public CharacterDetailed Character182 { get; set; }
        [JsonProperty("183")]
        public CharacterDetailed Character183 { get; set; }
        [JsonProperty("184")]
        public CharacterDetailed Character184 { get; set; }
        [JsonProperty("185")]
        public CharacterDetailed Character185 { get; set; }
        [JsonProperty("186")]
        public CharacterDetailed Character186 { get; set; }
        [JsonProperty("187")]
        public CharacterDetailed Character187 { get; set; }
        [JsonProperty("188")]
        public CharacterDetailed Character188 { get; set; }
        [JsonProperty("189")]
        public CharacterDetailed Character189 { get; set; }
        [JsonProperty("190")]
        public CharacterDetailed Character190 { get; set; }
        [JsonProperty("191")]
        public CharacterDetailed Character191 { get; set; }
        [JsonProperty("192")]
        public CharacterDetailed Character192 { get; set; }
        [JsonProperty("193")]
        public CharacterDetailed Character193 { get; set; }
        [JsonProperty("194")]
        public CharacterDetailed Character194 { get; set; }
        [JsonProperty("195")]
        public CharacterDetailed Character195 { get; set; }
        [JsonProperty("196")]
        public CharacterDetailed Character196 { get; set; }
        [JsonProperty("197")]
        public CharacterDetailed Character197 { get; set; }
        [JsonProperty("198")]
        public CharacterDetailed Character198 { get; set; }
        [JsonProperty("199")]
        public CharacterDetailed Character199 { get; set; }
        [JsonProperty("200")]
        public CharacterDetailed Character200 { get; set; }
        [JsonProperty("201")]
        public CharacterDetailed Character201 { get; set; }
        [JsonProperty("202")]
        public CharacterDetailed Character202 { get; set; }
        [JsonProperty("203")]
        public CharacterDetailed Character203 { get; set; }
        [JsonProperty("204")]
        public CharacterDetailed Character204 { get; set; }
        [JsonProperty("205")]
        public CharacterDetailed Character205 { get; set; }
        [JsonProperty("206")]
        public CharacterDetailed Character206 { get; set; }
        [JsonProperty("207")]
        public CharacterDetailed Character207 { get; set; }
        [JsonProperty("208")]
        public CharacterDetailed Character208 { get; set; }
        [JsonProperty("209")]
        public CharacterDetailed Character209 { get; set; }
        [JsonProperty("210")]
        public CharacterDetailed Character210 { get; set; }
        [JsonProperty("211")]
        public CharacterDetailed Character211 { get; set; }
        [JsonProperty("212")]
        public CharacterDetailed Character212 { get; set; }
        [JsonProperty("213")]
        public CharacterDetailed Character213 { get; set; }
        [JsonProperty("214")]
        public CharacterDetailed Character214 { get; set; }
        [JsonProperty("215")]
        public CharacterDetailed Character215 { get; set; }
        [JsonProperty("216")]
        public CharacterDetailed Character216 { get; set; }
        [JsonProperty("217")]
        public CharacterDetailed Character217 { get; set; }
        [JsonProperty("218")]
        public CharacterDetailed Character218 { get; set; }
        [JsonProperty("219")]
        public CharacterDetailed Character219 { get; set; }
        [JsonProperty("220")]
        public CharacterDetailed Character220 { get; set; }
        [JsonProperty("221")]
        public CharacterDetailed Character221 { get; set; }
        [JsonProperty("222")]
        public CharacterDetailed Character222 { get; set; }
        [JsonProperty("223")]
        public CharacterDetailed Character223 { get; set; }
        [JsonProperty("224")]
        public CharacterDetailed Character224 { get; set; }
        [JsonProperty("225")]
        public CharacterDetailed Character225 { get; set; }
        [JsonProperty("226")]
        public CharacterDetailed Character226 { get; set; }
        [JsonProperty("227")]
        public CharacterDetailed Character227 { get; set; }
        [JsonProperty("228")]
        public CharacterDetailed Character228 { get; set; }
        [JsonProperty("229")]
        public CharacterDetailed Character229 { get; set; }
        [JsonProperty("230")]
        public CharacterDetailed Character230 { get; set; }
        [JsonProperty("231")]
        public CharacterDetailed Character231 { get; set; }
        [JsonProperty("232")]
        public CharacterDetailed Character232 { get; set; }
        [JsonProperty("233")]
        public CharacterDetailed Character233 { get; set; }
        [JsonProperty("234")]
        public CharacterDetailed Character234 { get; set; }
        [JsonProperty("235")]
        public CharacterDetailed Character235 { get; set; }
        [JsonProperty("236")]
        public CharacterDetailed Character236 { get; set; }
        [JsonProperty("237")]
        public CharacterDetailed Character237 { get; set; }
        [JsonProperty("238")]
        public CharacterDetailed Character238 { get; set; }
        [JsonProperty("239")]
        public CharacterDetailed Character239 { get; set; }
        [JsonProperty("240")]
        public CharacterDetailed Character240 { get; set; }
        [JsonProperty("241")]
        public CharacterDetailed Character241 { get; set; }
        [JsonProperty("242")]
        public CharacterDetailed Character242 { get; set; }
        [JsonProperty("243")]
        public CharacterDetailed Character243 { get; set; }
        [JsonProperty("244")]
        public CharacterDetailed Character244 { get; set; }
        [JsonProperty("245")]
        public CharacterDetailed Character245 { get; set; }
        [JsonProperty("246")]
        public CharacterDetailed Character246 { get; set; }
        [JsonProperty("247")]
        public CharacterDetailed Character247 { get; set; }
        [JsonProperty("248")]
        public CharacterDetailed Character248 { get; set; }
        [JsonProperty("249")]
        public CharacterDetailed Character249 { get; set; }
        [JsonProperty("250")]
        public CharacterDetailed Character250 { get; set; }
        [JsonProperty("251")]
        public CharacterDetailed Character251 { get; set; }
        [JsonProperty("252")]
        public CharacterDetailed Character252 { get; set; }
        [JsonProperty("253")]
        public CharacterDetailed Character253 { get; set; }
        [JsonProperty("254")]
        public CharacterDetailed Character254 { get; set; }
        [JsonProperty("255")]
        public CharacterDetailed Character255 { get; set; }
        [JsonProperty("256")]
        public CharacterDetailed Character256 { get; set; }
        [JsonProperty("257")]
        public CharacterDetailed Character257 { get; set; }
        [JsonProperty("258")]
        public CharacterDetailed Character258 { get; set; }
        [JsonProperty("259")]
        public CharacterDetailed Character259 { get; set; }
        [JsonProperty("260")]
        public CharacterDetailed Character260 { get; set; }
        [JsonProperty("261")]
        public CharacterDetailed Character261 { get; set; }
        [JsonProperty("262")]
        public CharacterDetailed Character262 { get; set; }
        [JsonProperty("263")]
        public CharacterDetailed Character263 { get; set; }
        [JsonProperty("264")]
        public CharacterDetailed Character264 { get; set; }
        [JsonProperty("265")]
        public CharacterDetailed Character265 { get; set; }
        [JsonProperty("266")]
        public CharacterDetailed Character266 { get; set; }
        [JsonProperty("267")]
        public CharacterDetailed Character267 { get; set; }
        [JsonProperty("268")]
        public CharacterDetailed Character268 { get; set; }
        [JsonProperty("269")]
        public CharacterDetailed Character269 { get; set; }
        [JsonProperty("270")]
        public CharacterDetailed Character270 { get; set; }
        [JsonProperty("271")]
        public CharacterDetailed Character271 { get; set; }
        [JsonProperty("272")]
        public CharacterDetailed Character272 { get; set; }
        [JsonProperty("273")]
        public CharacterDetailed Character273 { get; set; }
        [JsonProperty("274")]
        public CharacterDetailed Character274 { get; set; }
        [JsonProperty("275")]
        public CharacterDetailed Character275 { get; set; }
        [JsonProperty("276")]
        public CharacterDetailed Character276 { get; set; }
        [JsonProperty("277")]
        public CharacterDetailed Character277 { get; set; }
        [JsonProperty("278")]
        public CharacterDetailed Character278 { get; set; }
        [JsonProperty("279")]
        public CharacterDetailed Character279 { get; set; }
#endregion

    }
}
