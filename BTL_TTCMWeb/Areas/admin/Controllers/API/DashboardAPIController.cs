using BTL_TTCMWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_TTCMWeb.Areas.admin.Controllers
{
    public class DashboardAPIController : ApiController
    {
        HAWContextEntities db = new HAWContextEntities();
        [Route("Dashboard")]
        [HttpGet]
        public List<tbl_Order> Get(int id)
        {
            return (List<tbl_Order>)db.tbl_Order.Where(x => x.tbl_state.state_name == "Mới");
        }
        [Route("Laytheoma")]
        [HttpGet]
        public Array Laytong()
        {
            List<tbl_orderDetail> ct_hdb = db.tbl_orderDetail.ToList();
            List<tbl_Order> hdb = db.tbl_Order.ToList();

            var list = (from hd in hdb
                        join ct_hd in ct_hdb on hd.order_id equals ct_hd.oder_id
                        group new { ct_hd,hd}  by hd.order_id into Ma

                        select new
                        {
                            MaDonHang = Ma,
                            TongGia = Ma.Sum(x=>x.ct_hd.quantity*x.ct_hd.price),
                            TongSP = Ma.Sum(x=>x.ct_hd.quantity)
                        }
                      );
            return list.ToArray();
        }

    }
}