using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Models
{
    public class PesRedeemableLoyaltyProgram
    {
        public string promotionId { get; set; }
        public List<PesRewardDescription> description { get; set; }
        public int programId { get; set; }
        public PesProgramType programType { get; set; }
        public string amount { get; set; }
        public int sequenceId { get; set; }

    }
}
