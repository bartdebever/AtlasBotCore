using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Newtonsoft.Json;

namespace DataLibrary
{
    //Don't look here for your own sanity. Didn't know how dictionaries worked yet and did some things I'm not proud of. This will be reworked in the RiotWrapper.
    public class Champion
    {
        public int Id { get; set; }
        [JsonProperty("id")]
        public int ChampionId { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string title { get; set; }
        public List<SkinDto> skins { get; set; }
        public PassiveDto passive { get; set; }
        public List<ChampionSpellDto> spells { get; set; }
        public string lore { get; set; }
        public StatsDto info { get; set; }
    }

    public class SkinDto
    {
        public int Id { get; set; }
        public int num { get; set; }
        public string name { get; set; }
        [JsonProperty("id")]
        public int skinId { get; set; }
    }

    public class PassiveDto
    {
        public int Id { get; set; }
        public string sanitizedDescription { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ChampionSpellDto
    {
        public int Id { get; set; }
        public string cooldownBurn { get; set; }
        public string resource { get; set; }
        public string costType { get; set; }
        public string sanitizedDescription { get; set; }
        public string sanitizedTooltip { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public List<vars> vars { get; set; }
        [NotMapped]
        public List<List<double>> effect { get; set; }
        [NotMapped]
        public List<double> range { get; set; }
        [NotMapped]
        public List<int> cost { get; set; }
        [NotMapped]
        public List<string> effectBurn {
            get { return null; }
            set
            {
                EffectBurn = "";
                for (int i = 1; i < value.Count; i++)
                {
                    EffectBurn += value[i] + ",";
                }; } }
        public string EffectBurn { get; set; }
    }

    public class vars
    {
        public int id { get; set; }
        [NotMapped]
        public List<double> coeff {
            get { return null; }
            set {
                Coeff = new List<coeff>();
                foreach (var val in value)
                {
                    Coeff.Add(new coeff(val));
                }
            }

        }
        public List<coeff> Coeff { get; set; }
        public string key { get; set; }
    }

    public class coeff
    {
        public coeff(double value)
        {
            this.value = value;
        }
        public coeff() { }
        public int Id { get; set; }
        public double value { get; set; }
    }
    public class StatsDto
    {
        public int Id { get; set; }
        public int difficulty { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int magic { get; set; }
    }

    public class Data
    {
        public Champion MonkeyKing { get; set; }
        public Champion Jax { get; set; }
        public Champion Fiddlesticks { get; set; }
        public Champion Shaco { get; set; }
        public Champion Warwick { get; set; }
        public Champion Xayah { get; set; }
        public Champion Nidalee { get; set; }
        public Champion Zyra { get; set; }
        public Champion Kled { get; set; }
        public Champion Brand { get; set; }
        public Champion Rammus { get; set; }
        public Champion Illaoi { get; set; }
        public Champion Corki { get; set; }
        public Champion Braum { get; set; }
        public Champion Darius { get; set; }
        public Champion Tryndamere { get; set; }
        public Champion MissFortune { get; set; }
        public Champion Yorick { get; set; }
        public Champion Xerath { get; set; }
        public Champion Sivir { get; set; }
        public Champion Riven { get; set; }
        public Champion Orianna { get; set; }
        public Champion Gangplank { get; set; }
        public Champion Malphite { get; set; }
        public Champion Poppy { get; set; }
        public Champion Karthus { get; set; }
        public Champion Jayce { get; set; }
        public Champion Nunu { get; set; }
        public Champion Trundle { get; set; }
        public Champion Graves { get; set; }
        public Champion Zoe { get; set; }
        public Champion Gnar { get; set; }
        public Champion Lux { get; set; }
        public Champion Shyvana { get; set; }
        public Champion Renekton { get; set; }
        public Champion Fiora { get; set; }
        public Champion Jinx { get; set; }
        public Champion Kalista { get; set; }
        public Champion Fizz { get; set; }
        public Champion Kassadin { get; set; }
        public Champion Sona { get; set; }
        public Champion Irelia { get; set; }
        public Champion Viktor { get; set; }
        public Champion Rakan { get; set; }
        public Champion Kindred { get; set; }
        public Champion Cassiopeia { get; set; }
        public Champion Maokai { get; set; }
        public Champion Ornn { get; set; }
        public Champion Thresh { get; set; }
        public Champion Kayle { get; set; }
        public Champion Hecarim { get; set; }
        public Champion Khazix { get; set; }
        public Champion Olaf { get; set; }
        public Champion Ziggs { get; set; }
        public Champion Syndra { get; set; }
        public Champion DrMundo { get; set; }
        public Champion Karma { get; set; }
        public Champion Annie { get; set; }
        public Champion Akali { get; set; }
        public Champion Volibear { get; set; }
        public Champion Yasuo { get; set; }
        public Champion Kennen { get; set; }
        public Champion Rengar { get; set; }
        public Champion Ryze { get; set; }
        public Champion Shen { get; set; }
        public Champion Zac { get; set; }
        public Champion Talon { get; set; }
        public Champion Swain { get; set; }
        public Champion Bard { get; set; }
        public Champion Sion { get; set; }
        public Champion Vayne { get; set; }
        public Champion Nasus { get; set; }
        public Champion Kayn { get; set; }
        public Champion TwistedFate { get; set; }
        public Champion Chogath { get; set; }
        public Champion Udyr { get; set; }
        public Champion Lucian { get; set; }
        public Champion Ivern { get; set; }
        public Champion Leona { get; set; }
        public Champion Caitlyn { get; set; }
        public Champion Sejuani { get; set; }
        public Champion Nocturne { get; set; }
        public Champion Zilean { get; set; }
        public Champion Azir { get; set; }
        public Champion Rumble { get; set; }
        public Champion Morgana { get; set; }
        public Champion Taliyah { get; set; }
        public Champion Teemo { get; set; }
        public Champion Urgot { get; set; }
        public Champion Amumu { get; set; }
        public Champion Galio { get; set; }
        public Champion Heimerdinger { get; set; }
        public Champion Anivia { get; set; }
        public Champion Ashe { get; set; }
        public Champion Velkoz { get; set; }
        public Champion Singed { get; set; }
        public Champion Skarner { get; set; }
        public Champion Varus { get; set; }
        public Champion Twitch { get; set; }
        public Champion Garen { get; set; }
        public Champion Blitzcrank { get; set; }
        public Champion MasterYi { get; set; }
        public Champion Elise { get; set; }
        public Champion Alistar { get; set; }
        public Champion Katarina { get; set; }
        public Champion Ekko { get; set; }
        public Champion Mordekaiser { get; set; }
        public Champion Lulu { get; set; }
        public Champion Camille { get; set; }
        public Champion Aatrox { get; set; }
        public Champion Draven { get; set; }
        public Champion TahmKench { get; set; }
        public Champion Pantheon { get; set; }
        public Champion XinZhao { get; set; }
        public Champion AurelionSol { get; set; }
        public Champion LeeSin { get; set; }
        public Champion Taric { get; set; }
        public Champion Malzahar { get; set; }
        public Champion Lissandra { get; set; }
        public Champion Diana { get; set; }
        public Champion Tristana { get; set; }
        public Champion RekSai { get; set; }
        public Champion Vladimir { get; set; }
        public Champion JarvanIV { get; set; }
        public Champion Nami { get; set; }
        public Champion Jhin { get; set; }
        public Champion Soraka { get; set; }
        public Champion Veigar { get; set; }
        public Champion Janna { get; set; }
        public Champion Nautilus { get; set; }
        public Champion Evelynn { get; set; }
        public Champion Gragas { get; set; }
        public Champion Zed { get; set; }
        public Champion Vi { get; set; }
        public Champion KogMaw { get; set; }
        public Champion Ahri { get; set; }
        public Champion Quinn { get; set; }
        public Champion Leblanc { get; set; }
        public Champion Ezreal { get; set; }

        public List<Champion> AllChampions
        {
            get
            {
                return new List<Champion>()
                {

Aatrox
,

Ahri,


Akali
,

Alistar,


Amumu,


Anivia,


Annie,


Ashe,


AurelionSol,


Azir,


Bard,


Blitzcrank,


Brand,


Braum,


Caitlyn,


Camille,


Cassiopeia,


Chogath,


Corki,


Darius,


Diana,


DrMundo,


Draven,


Ekko,


Elise,


Evelynn,


Ezreal,


Fiddlesticks,


Fiora,


Fizz,


Galio,


Gangplank,


Garen,


Gnar,


Gragas,


Graves,


Hecarim,


Heimerdinger,


Illaoi,


Irelia,


Ivern,


Janna,


JarvanIV,


Jax,


Jayce,


Jhin,


Jinx,


Kalista,


Karma,


Karthus,


Kassadin,


Katarina,


Kayle,


Kayn,


Kennen,


Khazix,


Kindred,


Kled,


KogMaw,


Leblanc,


LeeSin,


Leona,


Lissandra,


Lucian,


Lulu,


Lux,


Malphite,


Malzahar,


Maokai,


MasterYi,


MissFortune,


Mordekaiser,


Morgana,


Nami,


Nasus,


Nautilus,


Nidalee,


Nocturne

,
Nunu,


Olaf,


Orianna,


Ornn,


Pantheon,


Poppy,


Quinn,


Rakan,


Rammus,


RekSai,


Renekton,


Rengar,


Riven,


Rumble,


Ryze,


Sejuani,


Shaco,


Shen,


Shyvana,


Singed,


Sion,


Sivir,


Skarner,


Sona,


Soraka,


Swain,


Syndra,


TahmKench,


Taliyah,


Talon,


Taric,


Teemo,


Thresh,


Tristana,


Trundle,


Tryndamere,


TwistedFate,


Twitch,


Udyr,


Urgot,


Varus,


Vayne,


Veigar,


Velkoz,


Vi,


Viktor,


Vladimir,


Volibear,


Warwick,


MonkeyKing,


Xayah,


Xerath,


XinZhao,


Yasuo,


Yorick,


Zac,


Zed,


Ziggs,


Zilean,


Zoe,

Zyra
                };
            }
        }
    }

    public class RootChampion
    {
        public string type { get; set; }
        public string version { get; set; }
        public Data data { get; set; }
    }
  
}
