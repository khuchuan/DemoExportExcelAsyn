using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace Paygate.Utility
{
    public class Config
    {
        //Các hằng số cho Menu--------
        public const int FUNC_ROOT_ID = 0;          //FatherID cấp cao nhất
        public const int FUNC_HOME_ID = 33;         //Trang chủ
        public const int FUNC_PROFILE_ID = 35;      //Hồ sơ
        public const int FUNC_SHOP_ID = 34;         //Mua hàng
        public const int FUNC_INTEGRATE_ID = 36;    //Tích hợp
        public const int FUNC_UTILITY_ID = 37;      //Tiện ích
        public const int FUNC_GUIDE_ID = 38;        //Hướng dẫn
        public const int FUNC_NEWS_ID = 39;         //Tin tức

        public const int FUNC_REGISTER_ID = 61;     //Đăng ký
        public const int FUNC_LOSTPASSWORD_ID = 62; //Quên password

        public const int FUNC_FOOTER_ID = 55;       //FatherID cho các menu Footer

        public const int FUNC_SHOP_GUIDE_ID = 40;           //ID của hướng dẫn Mua sắm
        public const int FUNC_SHOP_MOBILE_ID = 41;          //ID của điện thoại di động
        public const int FUNC_SHOP_MOBILLE_PREPAID_ID = 44; //ID của Nạp tiền dd trả trước
        public const int FUNC_SHOP_STOREPRODUCT_ID = 145; //ID của Xem hàng tồn kho
        public const int FUNC_SHOP_CALLWORLD_ID = 47; //ID của Nạp tiền điện thoại quốc tế
        public const int FUNC_SHOP_TOPUPGAME_ID = 48; //ID của Nạp tiền game online
        public const int FUNC_SHOP_LEARNONLINE_ID = 50; //ID của Nạp tiền học trực tuyến
        public const int FUNC_SHOP_KEYSOFT_ID = 51; //ID key phần mềm
        public const int FUNC_SHOP_PENREAD_ID = 52; //ID mua bút chấm đọc
        public const int FUNC_SHOP_CARDTELCO_ID = 46; //ID mua bút chấm đọc
        public const int FUNC_SHOP_HLINKTICKET_ID = 144; //ID mua vé tàu xe trực tuyến

        public const int FUNC_PROFILE_MANAGEMENT_COMPLAINT_ID = 154; //ID khiếu nại


        // tuanhd - 23/2/2012
        //public const int FUNC_SHOP_GAME_ID = 197;          //ID của game online
        public const int FUNC_SHOP_HUNA_ID = 52;          //ID của bộ sản phẩm Huna
        public const int FUNC_SHOP_GAMEONLIE_ID = 42;     // ID Game Online
        public const int FUNC_SHOP_TELCO_ID = 42;


        // tuanhd-10/07/2012 ID các control trang chủ mua sắm Trading
        public const int FUNC_TRADING_HOME_ID = 280;          // ID trang chủ  local là 287
        public const int FUNC_TRADING_TELCO_ID = 281;         // ID điện thoại local là 288
        public const int FUNC_TRADING_GAMEONLIE_ID = 285;     // ID Game Online  local là 293
        public const int FUNC_TRADING_CALLWORLD_ID = 286;     //ID gọi điện thoại quốc tế  local là 294
        public const int FUNC_TRADING_HUNA_ID = 293;          //ID của bộ sản phẩm Huna local là 301
        public const int FUNC_TRADING_LEARN_ID = 295;         //ID học trực tuyến local là 303
        public const int FUNC_TRADING_SOFTKEY_ID = 297;       //ID key phần mềm  local là 300

        // Tham so cac chuc nang trong API Paygate
        public const string FUNC_CHECK_TRANSACTION_STATUS = "CHECK_Transaction_Status";
        public const string FUNC_CHECK_ACCOUNT_EXITS = "CHECK_ACCOUNT_EXITS";
        public const string FUNC_TOPUP_PARTNER = "TOPUP_PARTNER";
        public const string PAYGATE_GET_CATEGORY = "GET_LIST_CATEGORY";
        public const string PAYGATE_CHECK_ODP = "CHECK_EXITS_ODP";
        public const string PAYGATE_AUTHEN_ODP = "AUTHENTICATE_ODP";
        public const string PAYGATE_SEND_ODP = "SEND_ODP";
        public const string PAYGATE_SEND_CARD_SMS = "SEND_CARD_SMS";
        public const string PAYGATE_CHANGE_PASSWORD = "CHANGE_PASSWORD";
        public const string PAYGATE_TRANSFER_AMOUNT = "TRANSFER_AMOUNT";
        public const string PAYGATE_GET_PRODUCTS = "GET_LIST_PRODUCT";
        public const string PAYGATE_AUTHENTICATE = "AUTHENTICATE";
        public const string PAYGATE_ACCOUNT_INFORMATION = "ACCOUNT_INFORMATION";
        public const string PAYGATE_GET_ACCOUNT_INFOR = "GET_ACCOUNT_INFOR";
        public const string PAYGATE_GET_LIST_BANK = "GET_LIST_BANK";
        public const string PAYGATE_REPORT_AMOUNT = "REPORT_AMOUNT";
        public const string PAYGATE_REPORT_SALES = "REPORT_SALES";
        public const string FUNC_TOPUP_MOBILE = "TOPUP_MOBILE";
        public const string FUNC_GET_CARD_CODE = "GET_CARD_CODE";
        public const string FUNC_BUY_CARD_CODE = "BUY_CARD_CODE";
        public const string FUNC_BUY_CARD_VDC1718 = "BUY_CARD_VDC1718";
        public const string FUNC_GET_CARD_VDC1718 = "GET_CARD_VDC1718";
        public const string FUNC_REPORT_TRANSACTION = "GET_REPORT_TRANSACTION";
        public const string FUNC_BUY_HUNA = "BUY_HUNA";
        public const string FUNC_GET_SALE_PRICE = "GET_SALE_PRICE";
        public const string FUNC_GET_LOCATIONS = "GET_LIST_LOCATION";
        public const string FUNC_GET_DISTRICTS = "GET_LIST_DISTRICT";
        public const string FUNC_PAY_ORDER = "PAY_ORDER"; // Thanh toan don hang bang tai khoan Paygate
        public const string FUNC_BUY_MIC_INSURANCE = "BUY_MIC_INSURANCE";
        public const string FUNC_GET_DEBIT_BILL = "GET_DEBIT_BILL";

        public const string FUNC_SEND_SMS_RESET_PASS = "SEND_SMS_RESET_PASS";
        public const string FUNC_AUTHEN_SMS_RESET_PASS = "AUTHEN_SMS_RESET_PASS";
        public const string FUNC_RESET_PASS_ODP = "RESET_PASS_ODP";

        public const string FUNC_PAY_STATE = "PAY_STATE";

        public const string PAYMENT_TYPE_CASH = "CASH";
        public const string PAYMENT_ACCOUNTING = "PAYMENT_ACCOUNTING";
        public const string PAYMENT_TYPE_PAYGATE = "PAYGATE";
        // Loai tai khoan nay duoc phep mua hang tren PG ma ko can tien mat, se dc ghi no
        public const byte ACCOUNT_TYPE_DEBT = 8; 

        public const string PAYMENT_PAYGATE_WEB = "COMFIRM_STATUS_TRANSFER";

        //Hằng số các loại tài khoản---
        public enum ACCOUNT_TYPE_ID : byte
        {
            MEMBER_PERSONAL_NORMAL = 1,     //Tài khoản Cá nhân thông thường
            MEMBER_CORPORATE_NORMAL = 4,    //Tài khoản Doanh nghiệp thông thường
            MEMBER_CORPORATE_VCOIN = 5,     //Tài khoản Doanh nghiệp tích hợp thông tin - Channeling (không đc đăng nhập)
            MEMBER_CORPORATE_PAYMENT = 6,   //Tài khoản Doanh nghiệp thanh toán (Contract Company)
            MEMBER_CORPORATE_DEPOSIT = 7,   //Tài khoản Doanh nghiệp nạp tiền trước - API (Deposit Contract)
            MEMBER_CORPORATE_POSTPAID = 8,  //Tài khoản Doanh nghiệp nạp tiền sau - API (Payment Contract)

            MEMBER_PERSONAL_AGENT = 10,     //Tài khoản tổng đại lý Cá nhân 
            MEMBER_CORPORATE_AGENT = 40,    //Tài khoản  tổng đại lý Doanh nghiệp 
        }

        //huankc
        public enum OnlinePaymentType : byte
        {
            Bank = 1,
            Wallet = 2,
            Intenationa = 3,
            VTCEBank = 4
        }

        // Phân biệt ECPAY và Payoo
        public enum BillType
        {
            Payoo = 1,
            EcPay = 2,
        }

        //---

        //Hằng số các Group quyền---
        public enum GROUP_ID : int
        {
            GUEST = 20,                       //ID Group khách vãng lai
            MEMBER_PERSONAL_NORMAL = 21,      //ID Group thành viên tài khoản Cá nhân thông thường
            MEMBER_CORPORATE_NORMAL = 24,     //ID Group thành viên tài khoản Doanh nghiệp thông thường
            MEMBER_CORPORATE_VCOIN = 25,      //ID Group thành viên tài khoản Doanh nghiệp tích hợp thông tin - Channeling (không đc đăng nhập)
            MEMBER_CORPORATE_PAYMENT = 26,    //ID Group thành viên tài khoản Doanh nghiệp thanh toán (Contract Company)
            MEMBER_CORPORATE_DEPOSIT = 27,    //ID Group thành viên tài khoản Doanh nghiệp nạp tiền trước - API (Deposit Contract)
            MEMBER_CORPORATE_POSTPAID = 28,   //ID Group thành viên tài khoản Doanh nghiệp nạp tiền sau - API (Payment Contract)
            MEMBER_PERSONAL_AGENT = 32,      //ID Group thành viên tài khoản  Cá nhân Tổng đại lý
            MEMBER_CORPORATE_AGENT = 33,     //ID Group thành viên tài khoản Doanh nghiệp Tổng đại lý
            GUEST_TRADING = 34,             //ID Group khách hàng trading
        }
        //---

        public static int GetGroupID(byte accountTypeID)
        {
            switch (accountTypeID)
            {
                case (byte)ACCOUNT_TYPE_ID.MEMBER_PERSONAL_NORMAL:
                    return (int)GROUP_ID.MEMBER_PERSONAL_NORMAL;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_CORPORATE_NORMAL:
                    return (int)GROUP_ID.MEMBER_CORPORATE_NORMAL;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_CORPORATE_VCOIN:
                    return (int)GROUP_ID.MEMBER_CORPORATE_VCOIN;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_CORPORATE_PAYMENT:
                    return (int)GROUP_ID.MEMBER_CORPORATE_PAYMENT;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_CORPORATE_DEPOSIT:
                    return (int)GROUP_ID.MEMBER_CORPORATE_DEPOSIT;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_CORPORATE_POSTPAID:
                    return (int)GROUP_ID.MEMBER_CORPORATE_POSTPAID;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_PERSONAL_AGENT:
                    return (int)GROUP_ID.MEMBER_PERSONAL_AGENT;
                case (byte)ACCOUNT_TYPE_ID.MEMBER_CORPORATE_AGENT:
                    return (int)GROUP_ID.MEMBER_CORPORATE_AGENT;
                default:
                    return (int)GROUP_ID.GUEST;
            }
        }

        //topup telco partner
        public const int SERVICE_CODE = 123;

        // applied object cho trading <tuanhd 10/08/2012>
        public const int TRADING_APPLIEDOBJECT = 2;

        public const string PAYMENT_CODE = "ePOS";
        public const int SERVICEID_TELCO = 306;

        // id ảo của mã thẻ Vcoin VDC-Net2E
        public const string Vcoin_VDCNet2E = "12345";
        //Giá tiền extend Mic
        public const decimal Mic_ExtendAmount = 30000;
        public enum ServiceID //Các hằng số dịch vụ
        {
            ODP = 1, // Ma ODP
            PenRead = 981,  // Bút chấm đọc
            Withdrawal = 984, // Dich vu rut tien khoi Paygate
            PaymentOnline = 986,
            TopupAfter = 991,
            Recharge = 993, // Nap tien (nạp tại vtc)
            Topup = 995,  // Topup (dtu game, telco)      
            Topup1718 = 970,  // Topup (dtu game, telco)      
            TopupVCoin = 996,
            Transfer = 997, // Chuyen tien
            Refund = 998, // Hoan tien
            SalePin = 999, // Ma the
            PayBill = 994, //Dịch vụ SMS
            PayBillRemind = 976, //Thanh tóan cước (Thanh toán hóa đơn Payoo)
            Trading = 980, // Dành cho paygate Trading  
            SMS = 994,
            MicPeson = 266,  //Bảo hiểm con người
            MicMoTo = 267,  //Bảo hiểm mô tô
            MicOTo = 268,  //Bảo hiểm ô tô
            BillBankNet = 965 // Thanh toan hoa don Banknet
        }
        

        //Trạng thái giao dịch
        public enum TransactinStatus
        {
            Init = 0, //Mới tạo
            Success = 1, //Thành công
            Cancel = 4, //Hủy (admin hủy)
            Confuse = 2, //Nghi vấn
            refund = 3 //Hoàn tiền
        }

        // Trạng thái giao dịch thanh toán online
        public enum TransOnlinePaymentStatus
        {
            Fail = -1, //Thất bại
            Confuse = 0,//Nghi vấn, đang chờ xử lý
            Success = 1,//Thành công
            Pendding = 2, //Thanh toán tạm giữ 
            Refund = 4 //hoàn tiền, hủy giao dịch

        }
        public enum SMSServiceAccountStatus
        {
            Init = 1, // Chua dang su dung ODP hoac da huy bo su dung
            Susses = 2    // Dang dung ODP   
        }

        public enum SMSServiceID
        {
            OTPServiceID = 1,
            SMSServiceAsc = 2, // Số dư tăng
            SMSServiceIDDesc = 5, // Số dư giảm
            SMSServiceChangePass = 8 // Thay đổi password
        }

        public enum PaymenObjecType
        {
            Paygate = 0,
            Button = 2,
            Website = 1
        }

        public enum CurrencyPayment
        {
            VcoinPayVNĐ = 0, //Thanh toán bằng VND va vcoin thanh toan
            VNĐ = 1,
            VCoinPay = 2, //Thanh toan bang Vcoin thanh toan
            VCoinGame = 3, //Thanh toan bang Vcoin game
            VCoinPayVCoinGameVNĐ = 4 //Thanh toan bang vnd, vcoin thanh toan, vcoin game
        }


        public enum ApplicedObjectFee
        {
            AppliedSell = 1, // Voi nguoi ban thi phaichiu phi
            AppliedBuy = 2  // Voi nguoi mua thi khong can chiup phi
        }

        public const int NATIONAL_VIETNAM_ID = 4;

        public static string ExportExcellConnectionString
        {
            get { return GetConnectionString("ExportExcellConnectionString"); }
        }

        /*
         * 
         * Thêm chuỗi kết nối Cá thủ siêu đẳng 6-8-2012
         * 
         * */
        public static string BettingConnectionString
        {
            get { return GetConnectionString("BettingConnectionString"); }
        }

        public static string BettingConnectionStringV2
        {
            get { return GetConnectionString("BettingConnectionStringV2"); }
        }

        //END

        public static string EbankConnectionString
        {
            get { return GetConnectionString("EbankConnectionString"); }
        }
        public static string PaygateConnectionString
        {
            get { return GetConnectionString("PaygateConnectionString"); }
        }
        public static string TopupConnectionString
        {
            get { return GetConnectionString("TopupConnectionString"); }
        }

        public static string EBankSMSConnectionString
        {
            get { return GetConnectionString("eBankSMSConnectionString"); }
        }

        public static string BillingConnectionString
        {
            get { return GetConnectionString("BillingConnectionString"); }
        }

        public static string PinManagerConnectionString
        {
            get { return GetConnectionString("PinManagerConnectionString"); }
        }

        public static string NhomVipNewsConnectionString
        {
            get { return GetConnectionString("NhomVipNewsConnectionString"); }
        }

        public static string PaygateBankingConnectionString
        { get { return GetConnectionString("PaygateBankingConnectionString"); } }

        public static string PaygateAdminConnectionString
        { get { return GetConnectionString("PaygateAdminConnectionString"); } }

        public static string PaygateAdminDeployConnectionString
        { get { return GetConnectionString("PaygateAdminDeployConnectionString"); } }

        // Them chuoi ket noi tra thuong xo so
        public static string LotteryOnlineConnectionString
        { 
            get { return GetConnectionString("LotteryOnlineConnectionString"); } 
        }

        public static string PartnerGoodsAPIConnectionString
        {
            get { return GetConnectionString("PartnerGoodsAPIConnectionString"); }
        }



        public static string MediaUrl { get { return GetAppsetting("MEDIA.URL"); } }

        public static string UploadDir { get { return GetAppsetting("UPLOAD.DIR"); } }

        public static string PaygateUrl { get { return GetAppsetting("PAYGATE.URL"); } }

        public static string WalltetUrl { get { return GetAppsetting("WALLET.URL"); } }
        public static string WapPaygateUrl { get { return GetAppsetting("WAPPAYGATE.URL"); } }
        public static string DistributionUrl { get { return GetAppsetting("DISTRIBUTION.URL"); } }
        public static string CommunityUrl { get { return GetAppsetting("COMMUNITY.URL"); } }
        public static string SSOUrl { get { return GetAppsetting("SSO.URL"); } }
        public static string MediaCMSUrl { get { return GetAppsetting("MediaUrl.CMS"); } }
        public static string BusinessBackEndUrl { get { return GetAppsetting("BusinessBackEnd.URL"); } }
        public static string TradingUrl { get { return GetAppsetting("Trading.URL"); } }

        //Dung tai trang nap tien vao tai khoan__Dungnd
        public static string PaygateUrlGateBanks { get { return GetAppsetting("PAYGATE_URL_GATEBANKS"); } }
        public static string VtoAccountMerchentKey { get { return GetAppsetting("VTO.Account.MerchantKey"); } }
        public static string VtoAccountMerchantCode { get { return GetAppsetting("VTO.Account.MerchantCode"); } }
        public static string MerchantUrlDone { get { return GetAppsetting("MERCHANT_URL_DONE"); } }
        public static string MerchantSecurityKey { get { return GetAppsetting("MERCHANT_SECURITY_KEY"); } }


        //Dung tai trang chung thuc tai khoan_Dungnd
        public static string FileImageFormat { get { return GetAppsetting("FileImageFormat"); } }
        public static string CertificatePathTemplate { get { return GetAppsetting("IMAGETEMP.PATH"); } }
        public static string CertificatePath { get { return GetAppsetting("IMAGECERIFICATE.PATH"); } }



        //NhatND -> Dùng trong upload logo cho tích hợp website
        public static string LogoWebsiteIntegrate { get { return GetAppsetting("LOGO_WEBSITE_INTEGRATE"); } }

        //Dùng cho tích hợp sản phẩm - NhatND
        public static string Product_Integrate_Min_Price { get { return GetAppsetting("PRODUCT_INTEGRATE_MIN_PRICE"); } }

        public static string ChargePacket_IsPublic { get { return GetAppsetting("ChargePacket_IsPublic"); } }
        /**************/

        public static string SysPartnerEBankKey { get { return GetAppsetting("SysPartnerEBankKey"); } }
        public static int AssociateSystem { get { return int.Parse(GetAppsetting("AssociateSystem")); } }

        //Dành cho email------
        public static string MAIL_FROM_NAME { get { return GetAppsetting("MAIL.FROM_NAME"); } }
        public static string MAIL_FROM_EMAIL { get { return GetAppsetting("MAIL.FROM_EMAIL"); } }
        public static string MAIL_KEY { get { return GetAppsetting("MAIL.KEY"); } }
        //------

        //Dùng cho thanh toán hóa đơn Payoo
        public static string BILL_MERCHANT_ID { get { return GetAppsetting("BILL.MERCHANT_ID"); } }
        public static string BILL_SECRET_KEY { get { return GetAppsetting("BILL.SECRET_KEY"); } }
        public static int BILL_PENDING_DAY { get { return int.Parse(GetAppsetting("BILL.PENDING_DAY")); } }
        public static int BILL_WEBSITE_ID { get { return int.Parse(GetAppsetting("BILL.WEBSITE_ID")); } }
        public static int BILL_MAX_PERIOD { get { return int.Parse(GetAppsetting("BILL.MAX_PERIOD")); } }
        public static string BILL_PARTNER_USERNAME { get { return GetAppsetting("BILL.PARTNER_USERNAME"); } }
        public static string PAYOO_BILL_ACCOUNT { get { return GetAppsetting("Payoo_Bill_Account"); } }
        public static decimal Fee_SMS_Payoo { get { return Decimal.Parse(GetAppsetting("Fee_SMS_Payoo")); } }  // Phi quy dinh khi gui tin nhan nhac no tu Payoo
        //

        public static int PRICE_VCOIN { get { return int.Parse(GetAppsetting("PRICE.VCOIN")); } }


        public static int TELCO_MUTILCATE { get { return int.Parse(GetAppsetting("TELCO.MUTILCATE")); } }

        public static string COOKIE_EVENT_NAME { get { return GetAppsetting("COOKIE_EVENT_NAME"); } }

        //Dành cho Version của js, css, image - Xử lý việc Cache
        public static string VERSION { get { return GetAppsetting("VERSION"); } }
        //

        // Tai khoan Paygate cua VTC Mobile danh cho tra thuong xo so.
        public static string VTC_MOBILE_LOTTERY_ACCOUNT { get { return GetAppsetting("Lottery.Account"); } }     


        private static string GetConnectionString(string nameConnection)
        {
            return ConfigurationManager.ConnectionStrings[nameConnection] == null ? string.Empty : new RijndaelEnhanced("pay", "@1B2c3D4e5F6g7H8").Decrypt(ConfigurationManager.ConnectionStrings[nameConnection].ConnectionString);
        }


        private static string GetAppsetting(string appSettingName)
        {
            return ConfigurationManager.AppSettings[appSettingName] ?? string.Empty;
        }


        public static string ApplicationUrl
        {
            get
            {
                var url = ConfigurationManager.AppSettings["Paygate"] ?? "http://" + System.Web.HttpContext.Current.Request.Url.Authority +
                   System.Web.HttpContext.Current.Request.ApplicationPath;
                return url.EndsWith("/") ? url : url + "/";
            }
        }
        public static int SystemId
        {
            get

            {
                var systemId = ConfigurationManager.AppSettings["SystemId"] ?? "0";
                return Int32.Parse(systemId);
            }
        }

        public static int CategoryTopupGame
        {
            get
            {
                var systemId = ConfigurationManager.AppSettings["Category_TopupGame"] ?? "0";
                return Int32.Parse(systemId);
            }
        }

        /// <summary>
        /// Kiểm tra xem chuỗi token request với token quy định có trùng nhau không
        /// </summary>
        /// <param name="param"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool CheckTokenKey(string[] param, string key)
        {
            var _key = param.Aggregate(string.Empty, (current, s) => current + s);
            if (string.IsNullOrEmpty(_key.Trim())) return false;
            return Paygate.Utility.Encrypt.Md5(_key) == key;
        }


        public static void SetLanguage()
        {
            CultureInfo culture;
            switch (HttpContext.Current.Request["l"])
            {
                case "vi":
                    culture = new CultureInfo("vi-VN");
                    break;
                case "en":
                    culture = new CultureInfo("en-US");
                    break;
                default:
                    culture = new CultureInfo("vi-VN");
                    break;
            }

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }


        public static string GetCurrentLanguage()
        {
            //return HttpContext.Current.Request["l"] ?? "vi";
            switch (HttpContext.Current.Request["l"])
            {
                case "vi":
                    return "vi";
                case "en":
                    return "en";
                default:
                    return "vi";
            }
        }

        /// <summary>
        /// Từ GetCurrentLanguage() lấy ra chuỗi Query language với:
        /// - Nếu là vi thì trả về chuỗi rỗng
        /// - Nếu khác vi thì trả về chuỗi dạng như "?l=en"
        /// </summary>
        /// <returns></returns>
        public static string GetStringLanguage()
        {
            var lang = Config.GetCurrentLanguage();
            lang = lang.ToLower().Contains("vi") ? string.Empty : "?l=" + lang;
            return lang;
        }


        /// <summary>
        /// Start SqlDependency tại Application_Start khi sử dụng SqlCacheDependency
        /// </summary>
        public static void SqlDependency_Start()
        {
            System.Data.SqlClient.SqlDependency.Start(PaygateAdminConnectionString);
        }

        /// <summary>
        /// Stop SqlDependency tại Application_Stop khi sử dụng SqlCacheDependency
        /// </summary>
        public static void SqlDependency_Stop()
        {
            System.Data.SqlClient.SqlDependency.Stop(PaygateAdminConnectionString);
        }

        public static string Domain { get { return GetAppsetting("DOMAIN"); } }

        public static string GetMenuUrl()
        {
            var url = string.Format("{0}{1}", Domain, HttpContext.Current.Request.RawUrl);
            return url.IndexOf("?") > 0 ? url.Substring(0, url.IndexOf("?")) : url;
        }

        public static string SettingPath
        {
            get { return GetAppsetting("SETTING.PATH"); }
        }

        public static int AccountID
        {
            get
            {
                try
                {

                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return 0;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return 0;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return 0;
                    var accountID = Convert.ToInt32(arrCurrent[0]);
                    return accountID;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return 0;
                }
            }
        }

        public static string AccountName
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return string.Empty;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, current);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return string.Empty;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return string.Empty;
                    var accountName = arrCurrent[1];
                    if (!string.IsNullOrEmpty(accountName)) CachingUtility.LoginSuccess(CachingUtility.CacheInvalidAccount + accountName);
                    return accountName;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return string.Empty;
                }
            }
        }

        public static byte AccountTypeID
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return 0;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return 0;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return 0;
                    var accountTypeID = Convert.ToByte(arrCurrent[2]);
                    return accountTypeID;
                }
                catch (Exception ex)
                {
                    NLogLogger.LogInfo("" + ex);
                    return 0;
                }
            }
        }

        public static string SessionKey
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return string.Empty;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, current);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return string.Empty;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return string.Empty;
                    var sessionKey = arrCurrent[3];
                    return sessionKey;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return string.Empty;
                }
            }
        }

        public static string PasswordKey
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return string.Empty;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, current);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return string.Empty;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return string.Empty;
                    var passwordKey = arrCurrent[4];
                    return passwordKey;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return string.Empty;
                }
            }
        }


        /// <summary>
        /// Thay chuỗi text vào chuỗi original từ vị trí startIndex, với chuỗi kết quả có độ dài = độ dài chuỗi ban đầu (phần thừa của chuỗi text sẽ bị loại bỏ)
        /// </summary>
        /// <param name="original">Chuỗi gốc</param>
        /// <param name="text">Chuỗi cần thay</param>
        /// <param name="startIndex">Vị trí bắt đầu của chuỗi gốc</param>
        /// <returns>Chuỗi kết quả sau khi thay</returns>
        public static string ReplaceText(string original, string text, int startIndex)
        {
            if (string.IsNullOrEmpty(original))
                return "";

            if (original.Length <= startIndex)
                return "";

            var begin = original.Substring(0, startIndex);

            if (text.Length + startIndex > original.Length) //Nếu text dài quá thì cắt phần thừa đi
                text = text.Substring(0, original.Length - startIndex);

            var end = "";
            if (original.Length > text.Length + startIndex)
                end = original.Substring(text.Length + startIndex);

            return begin + text + end;
        }


        /// <summary>
        /// Lấy ip
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            var ip = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if (ip == "")
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        public static bool IsEmail(string email)
        {
            const string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            return email != null && System.Text.RegularExpressions.Regex.IsMatch(email, MatchEmailPattern);
        }


        /// <summary>
        /// Get ra kiểu email (yahoo, gmail, msn) từ địa chỉ email để sử dụng OpenID
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// 0: Loại khác
        /// 1: Yahoo
        /// 2: gmail
        /// 3: msn
        /// </returns>
        public static int GetEmailType(string email)
        {
            var listyahoo = new List<string> { "yahoo", "ymail.com", "rocketmail.com" };
            var listgmail = new List<string> { "gmail.com", "googlemail.com" };
            var listmsn = new List<string> { "hotmail.com", "msn.com", "live.com" };
            var domain = email.Substring(email.IndexOf('@') + 1);
            if (listyahoo.Exists(e => domain.ToLower().StartsWith(e)))
                return 1;
            else if (listgmail.Exists(e => domain.ToLower().StartsWith(e)))
                return 2;
            else if (listmsn.Exists(e => domain.ToLower().StartsWith(e)))
                return 3;
            else
                return 0;
        }

        public static bool IsNumber(string strNumber)
        {
            return !new Regex("[^0-9]").IsMatch(strNumber);
            //const string MatchNumber = @"^[0-9]$";
            //return System.Text.RegularExpressions.Regex.IsMatch(strNumber, MatchNumber);
        }

        /// <summary>
        /// Nếu là ngôn ngữ tiếng việt sẽ có định dạng dd/MM/yyyy còn tiếng anh là MM/dd/yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertStringToDateTime(string date)
        {
            if (string.IsNullOrEmpty(date)) return DateTime.Now;
            var arr = date.Split('/');
            if (GetCurrentLanguage().ToLower().Contains("en"))
                return new DateTime(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
            return new DateTime(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[0]));


        }


        public static void Dowload(string filepath, string filename)
        {
            System.IO.Stream iStream = null;
            byte[] buffer = new Byte[100000];
            int length;
            long dataToRead;
            try
            {
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                dataToRead = iStream.Length;
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                while (dataToRead > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 100000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        buffer = new Byte[100000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                File.Delete(filepath);
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
                HttpContext.Current.Response.Close();
                File.Delete(filepath);

            }

        }

        /// <summary>
        /// Download file trực tiếp về Client (nơi gọi method này)
        /// </summary>
        /// <param name="url_Server">Url chứa file trên server</param>
        /// <param name="filePath_Server">Đường dẫn file trên server, dùng để xóa file sau khi download</param>
        /// <param name="filePath_Client">Đường dẫn file phía client sau khi down</param>
        public static void Dowload(string url_Server, string filePath_Server, string filePath_Client)
        {

            //NLogLogger.Info(string.Format("{0}|{1}|{2}", url_Server, filePath_Server, filePath_Client));
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    client.DownloadFile(url_Server, filePath_Client);
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                }
                finally 




                {
                    File.Delete(filePath_Server);
                }
            }
            //System.Net.WebClient wb = new System.Net.WebClient();
            //wb.DownloadFile(url_Server, filePath_Client);


        }


        /// <summary>
        /// Lấy url không còn các param từ url truyền vào
        /// http://paygate.vtc.vn/mua-sam/ma-the-1-2-3.html --> http://paygate.vtc.vn/mua-sam/ma-the.html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetUrlNotQuery(string url)
        {
            //Xử lý TH có url trong url
            var post_html = url.IndexOf(".html");
            if (post_html < 0) return url;
            var url1 = url.Substring(0, post_html);
            var url2 = url.Substring(post_html);
            //
            var arr = url1.Split('-');
            var i = arr.Length - 1;
            while (i >= 0)
            {
                int a;
                if (!int.TryParse(arr[i], out a))
                {
                    break;
                }
                var tmp = new List<string>(arr);
                tmp.RemoveAt(i);
                arr = tmp.ToArray();
                i--;
            }
            var link = arr.Aggregate((current, next) => current + "-" + next) + url2;
            var live = GetAppsetting("LIVE");
            if (string.IsNullOrEmpty(live)) return link;
            if (live == "1") return link;// danh cho truong hop da trien khai that hoac test local
            arr = link.Split('1');
            return string.Format("{0}{1}", arr[0], arr[1]);
        }
        public static string VerifyUrl(string url)
        {
            var live = GetAppsetting("LIVE");
            if (string.IsNullOrEmpty(live)) return url;
            if (live == "1") return url;// danh cho truong hop da trien khai that hoac test local
            url = url.Remove(0, 8);
            var arr = url.Split('/');
            url = "https://";
            var index = 0;
            foreach (var s in arr)
            {
                url += s;
                if (index == 1)
                    url += "1";
                if (index < arr.Length - 1)
                    url += "/";
                index++;

            }
            return url;

        }
        public static string GetPassword()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(3, true));
            builder.Append(RandomNumber(1, 9));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }


        //Hằng số các loại bảo mật ODP, OTP ma trận, SMS plus---
        public enum UtilServiceId : byte
        {
            ODP_SMS = 1, //ODP SMS mien phi
            OTP_SMS = 7, // OTP 3 phút
            OTP_EMAIL = 14, // OTP gửi qua email
            ODP_EMAIL = 100, //ODP email
            OTP_MATRIX = 200, //OTP maxtrix
            OTP_APP=201, // otp app
            SMSPLUS_BALANCE_INCREASE = 2, //Bien dong so du tang
            SMSPLUS_BALANCE_REDUCE = 5, //Bien dong so du giam
            SMSPLUS_PASSWORD_CHANGE = 8, //Thay đổi mật khẩu
        }
        //Hằng số trạng thái dịch vụ bảo mật ODP, OTP ma trận, SMS plus---
        public enum UtilServiceStatus : byte
        {
            CANCEL = 0, //Hủy (Chưa đăng ký)
            DEACTIVATED = 1, //Ngưng hoạt động, Chưa kích hoạt
            ACTIVE = 2, //Hoạt động, Đã kích hoạt
            RESEND_OTPMT = 3, //Lấy lại ma trận OTP
        }



        /// <summary>
        /// Lay url query cho Paygate Trading
        /// </summary>
        /// <returns></returns>
        public static string GetTraderQuery()
        {
            var tid = HttpContext.Current.Request.QueryString["TraderId"] ?? "";
            var tkey = HttpContext.Current.Request.QueryString["TraderKey"] ?? "";
            var textend = HttpContext.Current.Request.QueryString["TraderExtend"] ?? "";

            var result = "";
            if (!string.IsNullOrEmpty(tid))
            {
                result += (string.IsNullOrEmpty(result) ? "?" : "&") + "TraderId=" + tid;
            }
            if (!string.IsNullOrEmpty(tkey))
            {
                result += (string.IsNullOrEmpty(result) ? "?" : "&") + "TraderKey=" + tkey;
            }
            if (!string.IsNullOrEmpty(textend))
            {
                result += (string.IsNullOrEmpty(result) ? "?" : "&") + "TraderExtend=" + textend;
            }

            return result;
        }


        /// <summary>
        /// Lấy query về thông tin đối tác trading khi thực hiện giao dịch khác
        /// </summary>
        /// <returns></returns>
        public static string GetTraderInfo_Url()
        {
            var result = "";
            var payResult = HttpContext.Current.Request.QueryString["r"] ?? ""; //r: status_transId_buyerAccountName_traderId_traderKey_traderExtend_productId_categoryId (chắc chắn trong nhưng thứ này kg có dấu -)
            if (string.IsNullOrEmpty(payResult)) return string.Empty;
            var arrPayResult = payResult.Split('_');
            if (arrPayResult.Length != 8) return string.Empty; //data không đúng định dạng
            var traderId = arrPayResult[3];
            var traderKey = arrPayResult[4];
            var traderExtend = arrPayResult[5];
            int id = 0;
            int.TryParse(traderId, out id);
            if (!string.IsNullOrEmpty(traderId) && id > 0)
            {
                result += (string.IsNullOrEmpty(result) ? "?" : "&") + "TraderId=" + traderId;
            }
            if (!string.IsNullOrEmpty(traderKey))
            {
                result += (string.IsNullOrEmpty(result) ? "?" : "&") + "TraderKey=" + traderKey;
            }
            if (!string.IsNullOrEmpty(traderExtend))
            {
                result += (string.IsNullOrEmpty(result) ? "?" : "&") + "TraderExtend=" + traderExtend;
            }
            return result;

        }


        public static bool SystemMaintain()
        {
            try
            {
                var close = GetAppsetting("SYSTEM.CLOSE");
                if (close == null) return false;
                if (close == "0") return false;
                var url = GetAppsetting("MAINTAIN.URL");
                var ip = GetAppsetting("IPLOCAL").Split('|');
                var ipRequest = GetIP();
                foreach (var s in ip)
                {
                    if (s.Trim() == ipRequest) return false;
                }
                HttpContext.Current.Response.Redirect(url,false);
                return true;
            }
            catch (Exception exception)
            {
                NLogLogger.PublishException(exception);
                return false;

            }
        }


        public static bool IsPasswordStrong(string password)
        {
            return Regex.IsMatch(password, @"^(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$");
        }
    }
}

