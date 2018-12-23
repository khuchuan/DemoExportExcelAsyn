using Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Report
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check dieu kien
                // Call to API

                string spName = ddlSPName.SelectedValue;
                string request = string.Empty;

                string paramsJson = string.Empty;
               

                switch (spName)
                {
                    case "SP_ListTrans_1":

                        var condistionSearch = new Param()
                        {
                            City = ddlCity.SelectedValue,
                            FromDate = string.IsNullOrEmpty(txtFromDate.Text) ? DateTime.Now : Convert.ToDateTime(txtFromDate.Text),
                            ToDate = string.IsNullOrEmpty(txtToDate.Text) ? DateTime.Now : Convert.ToDateTime(txtToDate.Text),
                            Status = Convert.ToInt32(ddlStatus.SelectedValue)
                        };
                        paramsJson = JsonConvert.SerializeObject(condistionSearch);
                       

                        break;
                    case "SP_ListTrans_2":
                        break;
                    case "SP_ListTrans_3":
                        break;

                    default:
                        break;
                }

                var userRequest = new SearchRequest()
                {
                    SPName = spName,
                    UserName = "huankc",
                    Params = paramsJson                    
                };

                CallAPI(userRequest);

            }
            catch (Exception ex)
            {
            }

        }

        public void CallAPI(SearchRequest searchInfo)
        {
            try
            {
                string searchInfoJson = JsonConvert.SerializeObject(searchInfo);

                string endPoint = "http://localhost:64418/api/Message/SendMsgRequest";
                string fullRequest = string.Format("{0}?searchRequest={1}&signature={2}", endPoint, searchInfoJson, "mot hai ba");

                var client = new RestClient(fullRequest);
                var request = new RestRequest(Method.GET);
                request.AddHeader("postman-token", "3496ac08-557f-138c-bdbf-547aa5ee04d2");
                request.AddHeader("cache-control", "no-cache");
                IRestResponse response = client.Execute(request);
            }
            catch (Exception ex)
            {

            }
        }


    }
}