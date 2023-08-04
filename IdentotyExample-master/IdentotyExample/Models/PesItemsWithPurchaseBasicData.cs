using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Models
{
    public class PesItemsWithPurchaseBasicData
    {
        public int maxSelection { get; set; }
        public List<PesItemIdData> itemIds { get; set; }
       // public PesItemType notificationType { get; set; }
        public string promotionId { get; set; }
        public string alternatePromotionId { get; set; }
        public List<PesCouponIdData> coupons { get; set; }
        public List<PesLocalizedKeyValueData> description { get; set; }
        public int alertDuration { get; set; }
        public string promotionName { get; set; }
        public string promotionDescription { get; set; }
        public PesLocalizedTextData localizedPromotionName { get; set; }
        public PesLocalizedTextData localizedPromotionDescription { get; set; }
        public string alertType { get; set; }
        public string notificationFor { get; set; }
        public int notificationOrder { get; set; }
        public string resourceURL { get; set; }

    }
}
