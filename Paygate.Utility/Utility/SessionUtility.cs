using System;
/*
 * Author: khuyennv
 * email:vankhuyen.nguyen@vt.vn
 * YM:thansauvtc@yahoo.com.vn
 */
using System.Web;

namespace Paygate.Utility
{
    public class SessionUtility
    {

        #region --- Khai báo tên các session ---
        public const string SessionAccount = "Account"; //Dùng để lưu AccountID|AccountName|AccountTypeID|SessionKey|PasswordKey    //SessionKey|PasswordKey dùng để kiểm xoát đăng nhập 1 lần
        public const string SessionCaptcha = "Captcha"; //Dùng để lưu Captcha
        public const string SessionListPhone = "ListPhone"; //Dùng để lưu danh sách điện thoại upload lên
        public const string SessionListPhoneInvalid = "ListPhoneInvalid"; //Dùng để lưu danh sách điện thoại upload lên nhưng không hợp lệ
        public const string SESSION_TRANSFERACCOUNT = "##TransferAccount"; //Dùng tại trang chuyển tiền giữa 2 tài khoản paygate 
        public const string SESSION_OTP = "#OTPPASSWORD#"; //Dùng tại trang chuyển tiền giữa 2 tài khoản paygate
        public const string SESSION_TRANSFERMONEY = "##TransferMoney"; //Dùng tại trang chuyển tiền giữa 2 tài khoản paygate
        public const string SessionexportOrderID = "exportOrderID"; // Dùng để lưu lại exportOrderID  khi bán một mã thẻ điện thoại thành công.
        public const string Session_TotalPayment = "TotalPayment"; // Dùng để lưu lại giá phải trả khi mua một sản phẩm
        public const string Session_Agent = "Agent"; // Dùng để lưu lại thông tin về đại lý.
        public const string Session_CardTelcoDataInfo = "CardTelcoDataInfo"; // Dùng để lưu lại thông tin về thẻ điện thoại đã mua
        public const string Session_CategoryID = "CategoryID"; // Dùng để lưu lại CategoryID của các sản phẩm bán mã thẻ dùng sang trang xem kho hàng
        public const string Session_FileName = "FileName";// danh cho truong hop upload file nhu excel, image
        public const string Session_PenPrice = "PenPrice";// Lưu giá trị sản phẩm bút đọc
        public const string Session_Sumcard = "Sumcard";// tổng số thẻ mua
        public const string Session_Integrate_Partner = "ListPartner";// lưu danh sách đối tác tích hợp của VTC-Paygate


        //Dungnd_Tạo session sử dụng tại trang Nạp tiền online
        public const string SessionBankId = "BankId";
        public const string SessionBankCode = "BankCode";
        public const string SessionAmount = "Amount";
        public const string SessionFree = "Fee";

        //huankc: Luu cac session thanh toan online
        public const string Session_Order_Website = "#orderWebsite@";
        public const string SessionData = "Data";// để lưu các data có dạnh danh sách. dùng ở bank và history, paygate, distribution
        public const string Session_Order_Button = "orderButtonInfo";
        public const string Session_Mail_Buyer = "@reporttoBuyer";
        public const string Session_Mail_Saler = "@reporttoSaler";

        //Dùng cho khiếu nại. bắt đầu từ lịch sử giao dịch chi tiết cho thanh toán online
        //Hoàngpn
        public const string Session_TranType = "TransactionTranType";
        public const string Session_RelateTranID = "RelateTranID";
        public const string Session_TranID = "TransactionTranID";
        //Khuyennv lam cho ma du thuong
        public const string Session_GiftCode = "GiftCode";

        public const string Session_OrderInfo = "OrderInfo"; //Chungbx tạo, dùng để lưu trữ thông tin đơn hàng - 16/02/2012
        public const string Session_BuyerAccountName = "BuyerAccountName"; //Chungbx tạo, dùng để lưu trữ AccountName của người mua hàng, acc này có thể được gõ hoặc tạo tự động trên CTT (cho Cổng thanh toán của Distribution) - 27/02/2012
        public const string Session_BuyerName = "BuyerName"; //Chungbx tạo, dùng để lưu trữ FullName (TKCN) hoặc OrganicName (TKDN) của người mua hàng, thông tin này đc lấy ra khi hiện Hóa đơn Mua thẻ - 28/02/2012

        public const string Session_SentOtp_product = "SentOtpproduct"; // tuanhd tạo, lưu trữ thông tin xác nhận đã gửi Otp chưa
        public const string Session_SentOtp_category = "SentOtpcategory"; // tuanhd tạo, lưu trữ thông tin xác nhận đã gửi Otp chưa

        public const string Session_PageInput = "PageInput"; // tuanhd tạo, lưu trữ thông tin mã KH thanh toán Payoo
        public const string Session_BillInfo = "BillInfo"; // tuanhd tạo, lưu trữ thông tin đơn hàng Payoo

        //public const string SessionActiveAccountName = "ActiveAccountName"; //Chungbx tạo, lưu trữ thông tin accountName (chưa active) dùng cho trang Kích hoạt - 28/05/12

        public const string Session_TraderOrderInfo = "TraderOrderInfo"; //Chungbx tạo, dùng để lưu trữ thông tin đơn hàng của Trading - 23/07/2012

        public const string Session_BillRegister = "BillRegister"; //Tuanhd, dùng để lưu trữ thông tin đơn hàng của thanh toán hóa đơn khi đăng ký tự động thanh toán, nhắc nợ - 09/08/2012
        
        #endregion

        

        public void RemoveSessionData()
        {
            Remove(Session_CardTelcoDataInfo);
            Remove(SessionData);
            Remove(Session_FileName);
            Remove(Session_Integrate_Partner);
            Remove(SessionListPhone);
            Remove(SessionListPhoneInvalid);
            Remove(SESSION_TRANSFERACCOUNT);
          //  Remove(SessionexportOrderID);
            Remove(Session_CardTelcoDataInfo);



        }


        /// <summary>
        /// lấy ra giá trị session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetValue(string name)
        {
            try
            {
                return HttpContext.Current.Session[name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        /// <summary>
        /// hủy một session
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            HttpContext.Current.Session.Remove(name);

        }




        /// <summary>
        /// Nạp giá trị cho session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, object value)
        {
            HttpContext.Current.Session[name] = value;
        }

    }
}
