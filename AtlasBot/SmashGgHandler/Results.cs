using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashGgHandler
{
    public partial class ResultRoot
    {
        [JsonProperty("actionRecords")]
        public List<object> ActionRecords { get; set; }

        [JsonProperty("entities")]
        public ResultEntities Entities { get; set; }

        [JsonProperty("result")]
        public long Result { get; set; }

        [JsonProperty("resultEntity")]
        public string ResultEntity { get; set; }
    }

    public partial class ResultEntities
    {
        //[JsonProperty("entrants")]
        //public List<Entrant> Entrants { get; set; }

        //[JsonProperty("groups")]
        //public Groups Groups { get; set; }

        [JsonProperty("player")]
        public List<Player> Player { get; set; }

        //[JsonProperty("rankingIteration")]
        //public List<RankingIteration> RankingIteration { get; set; }

        //[JsonProperty("rankingSeries")]
        //public List<RankingSery> RankingSeries { get; set; }
        [JsonProperty("seeds")]
        public List<Seed> Seeds { get; set; }
        [JsonProperty("sets")]
        public List<Set> Sets { get; set; }
    }

    public partial class RankingSery
    {
        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("createdBy")]
        public long? CreatedBy { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("locationId")]
        public long? LocationId { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("locationRadius")]
        public long? LocationRadius { get; set; }

        [JsonProperty("locationType")]
        public long LocationType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissionType")]
        public string PermissionType { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("radiusUnit")]
        public string RadiusUnit { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("sourceId")]
        public long? SourceId { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("videogameId")]
        public long VideogameId { get; set; }
    }

    public partial class RankingIteration
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("createdBy")]
        public long CreatedBy { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("endAt")]
        public long? EndAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("permissionType")]
        public string PermissionType { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("publishedAt")]
        public long PublishedAt { get; set; }

        [JsonProperty("seriesId")]
        public long SeriesId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("startAt")]
        public long? StartAt { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("submittedAt")]
        public long? SubmittedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("entrantId")]
        public string EntrantId { get; set; }

        [JsonProperty("gamerTag")]
        public string GamerTag { get; set; }

        [JsonProperty("gamerTagChangedAt")]
        public long? GamerTagChangedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("nameDisplay")]
        public string NameDisplay { get; set; }

        [JsonProperty("permissionType")]
        public string PermissionType { get; set; }

        [JsonProperty("playerType")]
        public string PlayerType { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("rank")]
        public long? Rank { get; set; }

        [JsonProperty("rankings")]
        public List<Ranking> Rankings { get; set; }

        [JsonProperty("redditUsername")]
        public object RedditUsername { get; set; }

        [JsonProperty("region")]
        public object Region { get; set; }

        [JsonProperty("slug")]
        public object Slug { get; set; }

        [JsonProperty("smashboardsLink")]
        public string SmashboardsLink { get; set; }

        [JsonProperty("smashboardsUserId")]
        public long? SmashboardsUserId { get; set; }

        [JsonProperty("ssbwikiLink")]
        public object SsbwikiLink { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("streamMeStream")]
        public object StreamMeStream { get; set; }

        [JsonProperty("twitchStream")]
        public string TwitchStream { get; set; }

        [JsonProperty("twitterHandle")]
        public string TwitterHandle { get; set; }

        [JsonProperty("youtube")]
        public object Youtube { get; set; }
    }

    public partial class Ranking
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("delta")]
        public double? Delta { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("iterationId")]
        public long IterationId { get; set; }

        [JsonProperty("publishedAt")]
        public long PublishedAt { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("seriesId")]
        public long SeriesId { get; set; }

        [JsonProperty("sourceId")]
        public long SourceId { get; set; }

        [JsonProperty("videogameId")]
        public long VideogameId { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("createdAt")]
        public object CreatedAt { get; set; }

        [JsonProperty("entity")]
        public object Entity { get; set; }

        [JsonProperty("entityId")]
        public object EntityId { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("isOriginal")]
        public bool IsOriginal { get; set; }

        [JsonProperty("ratio")]
        public double Ratio { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updatedAt")]
        public object UpdatedAt { get; set; }

        [JsonProperty("uploadedBy")]
        public object UploadedBy { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class Groups
    {
        [JsonProperty("applyAll")]
        public object ApplyAll { get; set; }

        [JsonProperty("autoAssigning")]
        public object AutoAssigning { get; set; }

        [JsonProperty("bestOf")]
        public object BestOf { get; set; }

        [JsonProperty("canAutoAssign")]
        public bool CanAutoAssign { get; set; }

        [JsonProperty("displayIdentifier")]
        public string DisplayIdentifier { get; set; }

        //[JsonProperty("expand")]
        //public List<string> Expand { get; set; }

        [JsonProperty("finalized")]
        public bool Finalized { get; set; }

        [JsonProperty("firstRoundTime")]
        public object FirstRoundTime { get; set; }

        [JsonProperty("groupTypeId")]
        public long GroupTypeId { get; set; }

        [JsonProperty("hasCustomWinnerByes")]
        public bool HasCustomWinnerByes { get; set; }

        [JsonProperty("hasSets")]
        public bool HasSets { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("losersTargetPhaseId")]
        public object LosersTargetPhaseId { get; set; }

        [JsonProperty("matchmakingEnabled")]
        public bool MatchmakingEnabled { get; set; }

        [JsonProperty("numProgressing")]
        public long NumProgressing { get; set; }

        [JsonProperty("numRounds")]
        public object NumRounds { get; set; }

        [JsonProperty("percentageComplete")]
        public string PercentageComplete { get; set; }

        [JsonProperty("phaseId")]
        public long PhaseId { get; set; }

        [JsonProperty("pointsPerBye")]
        public object PointsPerBye { get; set; }

        [JsonProperty("pointsPerGameWin")]
        public object PointsPerGameWin { get; set; }

        [JsonProperty("pointsPerMatchWin")]
        public object PointsPerMatchWin { get; set; }

        [JsonProperty("poolRefId")]
        public object PoolRefId { get; set; }

        [JsonProperty("rematchSeconds")]
        public long RematchSeconds { get; set; }

        [JsonProperty("rounds")]
        public List<object> Rounds { get; set; }

        [JsonProperty("runOnce")]
        public object RunOnce { get; set; }

        [JsonProperty("scheduleId")]
        public long ScheduleId { get; set; }

        [JsonProperty("seeds")]
        public List<object> Seeds { get; set; }

        [JsonProperty("sets")]
        public List<object> Sets { get; set; }

        [JsonProperty("setsOnDeck")]
        public long SetsOnDeck { get; set; }

        [JsonProperty("startAt")]
        public object StartAt { get; set; }

        [JsonProperty("startedAt")]
        public object StartedAt { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("tiebreakOrder")]
        public List<TiebreakOrder> TiebreakOrder { get; set; }

        [JsonProperty("tiebreaks")]
        public object Tiebreaks { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("waveId")]
        public object WaveId { get; set; }

        [JsonProperty("winnersTargetPhaseId")]
        public object WinnersTargetPhaseId { get; set; }
    }
    public partial class Entrant
    {
        [JsonProperty("defaultSkill")]
        public long DefaultSkill { get; set; }

        [JsonProperty("eventId")]
        public long EventId { get; set; }

        [JsonProperty("expand")]
        public List<object> Expand { get; set; }

        [JsonProperty("finalPlacement")]
        public long FinalPlacement { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("initialSeedNum")]
        public long InitialSeedNum { get; set; }

        //[JsonProperty("isPlaceholder")]
        //public object IsPlaceholder { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("participant1Id")]
        //public object Participant1Id { get; set; }

        //[JsonProperty("participant2Id")]
        //public object Participant2Id { get; set; }

        [JsonProperty("participantIds")]
        public List<long> ParticipantIds { get; set; }

        [JsonProperty("playerIds")]
        public Dictionary<string, long?> PlayerIds { get; set; }

        [JsonProperty("prefixes")]
        public Dictionary<int, string> Prefixes { get; set; }

        //[JsonProperty("skill")]
        //public long Skill { get; set; }

        //[JsonProperty("skillOrder")]
        //public long SkillOrder { get; set; }

        [JsonProperty("unverified")]
        public bool Unverified { get; set; }
    }

    public class Seed
    {
        [JsonProperty("checkInState")]
        public long CheckInState { get; set; }

        [JsonProperty("entrantId")]
        public long? EntrantId { get; set; }

        [JsonProperty("expand")]
        public List<object> Expand { get; set; }

        [JsonProperty("groupSeedNum")]
        public long GroupSeedNum { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isBye")]
        public bool? IsBye { get; set; }

        [JsonProperty("isDisqualified")]
        public bool? IsDisqualified { get; set; }

        [JsonProperty("isEligible")]
        public bool? IsEligible { get; set; }

        [JsonProperty("isFinal")]
        public bool? IsFinal { get; set; }

        [JsonProperty("isSeeded")]
        public bool? IsSeeded { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("phaseGroupId")]
        public long PhaseGroupId { get; set; }

        [JsonProperty("phaseId")]
        public long PhaseId { get; set; }

        [JsonProperty("phaseLinkId")]
        public long? PhaseLinkId { get; set; }

        [JsonProperty("placement")]
        public long? Placement { get; set; }

        [JsonProperty("prereqProgressionId")]
        public object PrereqProgressionId { get; set; }

        [JsonProperty("progressionSeedId")]
        public object ProgressionSeedId { get; set; }

        [JsonProperty("projectedEntrantId")]
        public object ProjectedEntrantId { get; set; }

        [JsonProperty("seedNum")]
        public long SeedNum { get; set; }

        [JsonProperty("unverified")]
        public bool Unverified { get; set; }
    }
    public partial class Set
    {
        [JsonProperty("adminMessagedAt")]
        public object AdminMessagedAt { get; set; }

        [JsonProperty("adminMessagedBy")]
        public object AdminMessagedBy { get; set; }

        [JsonProperty("adminViewedAt")]
        public object AdminViewedAt { get; set; }

        [JsonProperty("adminViewedBy")]
        public object AdminViewedBy { get; set; }

        [JsonProperty("bestOf")]
        public long BestOf { get; set; }

        [JsonProperty("bracketId")]
        public string BracketId { get; set; }

        [JsonProperty("completedAt")]
        public double? CompletedAt { get; set; }

        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("crewPlayerCount")]
        public object CrewPlayerCount { get; set; }

        [JsonProperty("displayRound")]
        public double DisplayRound { get; set; }

        [JsonProperty("durationSeconds")]
        public long? DurationSeconds { get; set; }

        [JsonProperty("entrant1CharacterIds")]
        public List<long> Entrant1CharacterIds { get; set; }

        [JsonProperty("entrant1Id")]
        public long? Entrant1Id { get; set; }

        [JsonProperty("entrant1PrereqCondition")]
        public string Entrant1PrereqCondition { get; set; }

        [JsonProperty("entrant1PrereqId")]
        public long? Entrant1PrereqId { get; set; }

        [JsonProperty("entrant1PrereqStr")]
        public string Entrant1PrereqStr { get; set; }

        [JsonProperty("entrant1PrereqType")]
        public string Entrant1PrereqType { get; set; }

        [JsonProperty("entrant1Present")]
        public bool? Entrant1Present { get; set; }

        [JsonProperty("entrant1Score")]
        public double? Entrant1Score { get; set; }

        [JsonProperty("entrant2CharacterIds")]
        public List<long> Entrant2CharacterIds { get; set; }

        [JsonProperty("entrant2Id")]
        public long? Entrant2Id { get; set; }

        [JsonProperty("entrant2PrereqCondition")]
        public string Entrant2PrereqCondition { get; set; }

        [JsonProperty("entrant2PrereqId")]
        public long? Entrant2PrereqId { get; set; }

        [JsonProperty("entrant2PrereqStr")]
        public string Entrant2PrereqStr { get; set; }

        [JsonProperty("entrant2PrereqType")]
        public string Entrant2PrereqType { get; set; }

        [JsonProperty("entrant2Present")]
        public bool? Entrant2Present { get; set; }

        [JsonProperty("entrant2Score")]
        public double? Entrant2Score { get; set; }

        [JsonProperty("eventId")]
        public long EventId { get; set; }

        [JsonProperty("eventType")]
        public long EventType { get; set; }

        [JsonProperty("expand")]
        public List<string> Expand { get; set; }

        [JsonProperty("fbUrl")]
        public object FbUrl { get; set; }

        [JsonProperty("fullRoundText")]
        public string FullRoundText { get; set; }

        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        [JsonProperty("hasPlaceholder")]
        public bool HasPlaceholder { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("images")]
        public List<object> Images { get; set; }

        [JsonProperty("isGF")]
        public bool IsGF { get; set; }

        [JsonProperty("isLast")]
        public bool IsLast { get; set; }

        [JsonProperty("isTiebreak")]
        public object IsTiebreak { get; set; }

        [JsonProperty("lEligiblePhaseId")]
        public object LEligiblePhaseId { get; set; }

        [JsonProperty("lOverallPlacement")]
        public long? LOverallPlacement { get; set; }

        [JsonProperty("lPlacement")]
        public long? LPlacement { get; set; }

        [JsonProperty("lProgressionSeedId")]
        public object LProgressionSeedId { get; set; }

        [JsonProperty("loserId")]
        public long? LoserId { get; set; }

        [JsonProperty("midRoundText")]
        public string MidRoundText { get; set; }

        [JsonProperty("modRequestedAt")]
        public object ModRequestedAt { get; set; }

        [JsonProperty("modRequestedBy")]
        public object ModRequestedBy { get; set; }

        [JsonProperty("originalRound")]
        public double OriginalRound { get; set; }

        [JsonProperty("phaseGroupId")]
        public long PhaseGroupId { get; set; }

        [JsonProperty("progressionCount")]
        public object ProgressionCount { get; set; }

        [JsonProperty("progressionPlacement")]
        public object ProgressionPlacement { get; set; }

        [JsonProperty("round")]
        public double Round { get; set; }

        [JsonProperty("roundDivision")]
        public long? RoundDivision { get; set; }

        [JsonProperty("setGamesType")]
        public object SetGamesType { get; set; }

        [JsonProperty("shortRoundText")]
        public string ShortRoundText { get; set; }

        [JsonProperty("smashggUrl")]
        public object SmashggUrl { get; set; }

        [JsonProperty("startAt")]
        public long? StartAt { get; set; }

        [JsonProperty("startedAt")]
        public long? StartedAt { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("stationId")]
        public long? StationId { get; set; }

        [JsonProperty("streamId")]
        public object StreamId { get; set; }

        [JsonProperty("subState")]
        public List<object> SubState { get; set; }

        [JsonProperty("tasksPruned")]
        public bool? TasksPruned { get; set; }

        [JsonProperty("totalGames")]
        public object TotalGames { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("unreachable")]
        public object Unreachable { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("updatedAtMicro")]
        public double? UpdatedAtMicro { get; set; }

        [JsonProperty("videogameId")]
        public long VideogameId { get; set; }

        [JsonProperty("vodUrl")]
        public object VodUrl { get; set; }

        [JsonProperty("wEligiblePhaseId")]
        public object WEligiblePhaseId { get; set; }

        [JsonProperty("wOverallPlacement")]
        public long? WOverallPlacement { get; set; }

        [JsonProperty("wPlacement")]
        public long? WPlacement { get; set; }

        [JsonProperty("wProgressionSeedId")]
        public object WProgressionSeedId { get; set; }

        [JsonProperty("winnerId")]
        public long? WinnerId { get; set; }
    }
    public partial class Game
    {
        [JsonProperty("createdAt")]
        public long? CreatedAt { get; set; }

        [JsonProperty("entrant1Id")]
        public long? Entrant1Id { get; set; }

        [JsonProperty("entrant1P1CharacterId")]
        public double? Entrant1P1CharacterId { get; set; }

        [JsonProperty("entrant1P1ParticipantId")]
        public double? Entrant1P1ParticipantId { get; set; }

        [JsonProperty("entrant1P1Stocks")]
        public long? Entrant1P1Stocks { get; set; }

        [JsonProperty("entrant1P1StocksInitial")]
        public double? Entrant1P1StocksInitial { get; set; }

        [JsonProperty("entrant1P2CharacterId")]
        public double? Entrant1P2CharacterId { get; set; }

        [JsonProperty("entrant1P2ParticipantId")]
        public double? Entrant1P2ParticipantId { get; set; }

        [JsonProperty("entrant1P2Stocks")]
        public double? Entrant1P2Stocks { get; set; }

        [JsonProperty("entrant1P2StocksInitial")]
        public double? Entrant1P2StocksInitial { get; set; }

        [JsonProperty("entrant2Id")]
        public long? Entrant2Id { get; set; }

        [JsonProperty("entrant2P1CharacterId")]
        public long? Entrant2P1CharacterId { get; set; }

        [JsonProperty("entrant2P1ParticipantId")]
        public double? Entrant2P1ParticipantId { get; set; }

        [JsonProperty("entrant2P1Stocks")]
        public long? Entrant2P1Stocks { get; set; }

        [JsonProperty("entrant2P1StocksInitial")]
        public double? Entrant2P1StocksInitial { get; set; }

        [JsonProperty("entrant2P2CharacterId")]
        public double? Entrant2P2CharacterId { get; set; }

        [JsonProperty("entrant2P2ParticipantId")]
        public double? Entrant2P2ParticipantId { get; set; }

        [JsonProperty("entrant2P2Stocks")]
        public double? Entrant2P2Stocks { get; set; }

        [JsonProperty("entrant2P2StocksInitial")]
        public double? Entrant2P2StocksInitial { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("loserId")]
        public long? LoserId { get; set; }

        [JsonProperty("loserP1CharacterId")]
        public double? LoserP1CharacterId { get; set; }

        [JsonProperty("loserP1Stocks")]
        public double? LoserP1Stocks { get; set; }

        [JsonProperty("loserP2CharacterId")]
        public double? LoserP2CharacterId { get; set; }

        [JsonProperty("loserP2Stocks")]
        public double? LoserP2Stocks { get; set; }

        [JsonProperty("orderNum")]
        public string OrderNum { get; set; }

        [JsonProperty("sGameId")]
        public object SGameId { get; set; }

        [JsonProperty("selections")]
        public Dictionary<string, Dictionary<string, List<Character>>> Selections { get; set; }

        [JsonProperty("setId")]
        public long SetId { get; set; }

        [JsonProperty("stageId")]
        public double? StageId { get; set; }

        [JsonProperty("startedAt")]
        public double? StartedAt { get; set; }

        [JsonProperty("startingEntrantId")]
        public double? StartingEntrantId { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("winnerId")]
        public long? WinnerId { get; set; }

        [JsonProperty("winnerP1CharacterId")]
        public int? WinnerP1CharacterId { get; set; }

        [JsonProperty("winnerP1Stocks")]
        public int? WinnerP1Stocks { get; set; }

        [JsonProperty("winnerP2CharacterId")]
        public  int? WinnerP2CharacterId { get; set; }

        [JsonProperty("winnerP2Stocks")]
        public int? WinnerP2Stocks { get; set; }
    }
    public partial class Character
    {
        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("entrantId")]
        public long EntrantId { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("orderNum")]
        public object OrderNum { get; set; }

        [JsonProperty("participantId")]
        public object ParticipantId { get; set; }

        [JsonProperty("selectionType")]
        public string SelectionType { get; set; }

        [JsonProperty("selectionValue")]
        public long SelectionValue { get; set; }

        [JsonProperty("setId")]
        public long SetId { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }
    }
}
