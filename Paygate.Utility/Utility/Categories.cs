

namespace Paygate.Utility
{
   public class Categories
    {
       public enum CateType : int
       {
           CARD_TELCO = 10, //Thẻ điện thoai
           CARD_GAME = 11, //Thẻ game
           CARD_LICENSE = 12, //Bản quyền phần mềm
           CARD_VDC = 13, //Thẻ gọi quốc tế VDC

           TOPUP_TELCO_SINGLE_PREPAID = 20, //Nạp trả trước 1 số
           TOPUP_TELCO_SINGLE_POSTPAID = 21, //Nạp trả sau 1 số
           TOPUP_TELCO_MULTI_PREPAID = 22, //Nạp trả trước nhiều số
           TOPUP_TELCO_MULTI_POSTPAID = 23, //Nạp trả sau nhiều số

           TOPUP_POINT = 30, //Nạp @Point
           TOPUP_LEARN_ONLINE = 31, //Nạp học trược tuyến
           TOPUP_CALL_WORLD = 32, //Nạp điện thoại quốc tế
           TOPUP_EXTENDSUBCRIBER = 33, //Nạp tiền gia hạn thuê bao truyền hình số
           TOPUP_BAC = 34, //Nạp Bạc FPT
           TOPUP_PAYOO = 35, //Nạp tiền thanh toán cho Hóa đơn Payoo
           TOPUP_MCASH = 36, // Nạp mcash- Netgame asia
           BUY_TICKET = 37, // Mua vé tàu xe
           TOPUP_VCOIN = 40, //Nạp Vcoin
           TOPUP_DIALPHONE_WIRED = 50,// điện thoại cố định có dây
           TOPUP_DIALPHONE_HOMEPHONE = 51, // điện thoại cố định không dây
           TOPUP_INTERNET_DCOM = 60,// thanh toán cước internet dcom

           OTHER_HUNA = 90,//Bộ sản phẩn Huna
           OTHER_MIC = 91, // Bảo hiểm Mic
           OTHER_IBEST = 92, //Thanh toán khóa học tiếng anh Ibest
           VTC_AUTO_PAYMENT = 101, // tự động gia hạn truyền hình KTS VTC
           VTC_AUTO_REMIND = 102, // tự động nhắc lịch gia hạn truyền hình KTS VTC
           PAYOO_AUTO_PAYMENT = 103, // tự động thanh toán hóa đơn Payoo
           PAYOO_AUTO_REMIND = 104, // tự động nhắc nợ thanh toán hóa đơn Payoo
           TOPUP_SCOIN = 41, // nạp Scoin
           MService_BillPay = 38,//MService VNPTHCM, JetStar
           TOPUP_XU=39,
           TOPUP_ONCASH=42
       }

       public enum GroupCate:int
       {
           Mobile=21,
           Game=32,
           CallWord = 81,
       }
      public enum GameOnline:int
       {
           TopUpPoint = 35,
           TopUpCash = 36,
           TopUpOngBau = 37,
           TopUpVcoin = 115,
           TopUpCabal = 52,
           TopUpDocBaGiangHo = 48,
           TopUpPlayPark = 53,
           TopUpTamQuoc = 51
       }

     public  enum LearnOnline :int
       {
          TopUpHocmai = 40,
          TopupTTrucTuyen = 41
       }

      public enum SoftKey
       {

        Bidifender = 144,
        Bkav = 145
       }

     public  enum OtherService :int
       {
         CallWord = 104,
         PenRead = 159
       }

     public enum GameCard :int
     {
        Vcoin = 114,
        Zing = 67,
        Gate = 68,
        Softnyx = 99,
        Key7554=171

     }

       public enum TelcoCard: int
       {
           Viettel=27,
           Vina=28,
           Mobi=29,
           Sfone=30,
           Vietnamobile=154,
           Beeline=173

       }
     
    }
}
