using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Models
{
    public class PesOtherNotificationBasicData
    {
      //  public PesMessageType messageType { get; set; }
        public string promotionId { get; set; }
        public string alternatePromotionId { get; set; }
        public List<PesCouponIdData> coupons { get; set; }
        public List<PesLocalizedKeyValueData> description { get; set; }
        public int alertDuration { get; set; }
        public string promotionName { get; set; }
        public string promotionDescription { get; set; }
        public List<PesLocalizedTextData> localizedPromotionName { get; set;}
        public List<PesLocalizedTextData> localizedPromotionDescription { get; set; }




    }
}
