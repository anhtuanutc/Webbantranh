using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_TTCMWeb.Models;
namespace BTL_TTCMWeb.Areas.admin.ApiControllers
{
    public class Order_product_producer_APIController : ApiController
    {
        HAWContextEntities bd = new HAWContextEntities();
        DemoDataContext db = new DemoDataContext();
        [Route("Layorder")]
        [HttpGet]
        public List<order1> Getallorder()
        {
            return db.order1s.ToList();
        }

        [Route("layuser")]
        public List<tbl_user> getuser()
        {
            return db.tbl_users.ToList();
        }

        [Route("laycategory")]
        public List<tbl_category> getcategory()
        {
            return db.tbl_categories.ToList();
        }
        [Route("layproducerr")]
        public List<tbl_producer> getproducer()
        {
            return db.tbl_producers.ToList();
        }
        [Route("Layorder/{order_id}")]
        [HttpGet]
        public order1 Getorder(int order_id)
        {
            return db.order1s.FirstOrDefault(n => n.order_id == order_id);
        }
        //them
        //[Route("postorder/{order_id}/{user_id}/{order_receiver_note}/{order_total_price}/{order_state}")]
        [HttpPost]
        public bool Insertorder(int order_id, int user_id, string order_receiver_note, float order_total_price, int order_state)
        {
            try
            {
                tbl_Order tbl_Order = new tbl_Order();
                tbl_Order.order_id = order_id;
                tbl_Order.user_id = user_id;
                tbl_Order.order_receiver_note = order_receiver_note;
                tbl_Order.order_total_price = order_total_price;
                tbl_Order.order_state = order_state;               
                db.tbl_Orders.InsertOnSubmit(tbl_Order);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //sua
        //[Route("putorder/{order_id}/{user_id}/{order_receiver_note}/{order_total_price}/{order_state}")]
        [HttpPut]
        public bool Updateorder(int order_id, int user_id, string order_receiver_note, float order_total_price, int order_state)
        {
            try
            {
                tbl_Order tbl_Order = db.tbl_Orders.FirstOrDefault(n => n.order_id == order_id);
                if (tbl_Order == null) { return false; }
                tbl_Order.order_id = order_id;
                tbl_Order.user_id = user_id;
                tbl_Order.order_receiver_note = order_receiver_note;
                tbl_Order.order_total_price = order_total_price;
                tbl_Order.order_state = order_state;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //xoa
        [Route("deleteorder/{order_id}")]
        [HttpDelete]

        public bool Deleteorder(int order_id)
        {
            try
            {
                tbl_Order tbl_Order = db.tbl_Orders.FirstOrDefault(n => n.order_id == order_id);
                if (tbl_Order == null) { return false; }
                db.tbl_Orders.DeleteOnSubmit(tbl_Order);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //het api order

        //begin product
        [Route("Layproduct")]
        [HttpGet]
        public List<product> Getallproduct()
        {
            return db.products.ToList();
        }
        //public Array Getalllproduct()
        //{
        //    List<tbl_producer> tbl_Producers = db.tbl_producers.ToList();
        //    List<tbl_state> tbl_States = db.tbl_states.ToList();
        //    List<tbl_category> tbl_Categories = db.tbl_categories.ToList();
        //    List<tbl_product> tbl_Products = db.tbl_products.ToList();

        //    var list = (from p in tbl_Products
        //                join pr in tbl_Producers on p.product_producer equals pr.producer_id
        //                join s in tbl_States on p.state equals s.state_id
        //                join c in tbl_Categories on p.category_id equals c.category_id
        //                select new
        //                {
        //                    product_id = p.product_id,
        //                    product_name = p.product_name,
        //                    product_alias = p.product_alias,
        //                    product_description = p.product_description,
        //                    product_content = p.product_content,
        //                    product_img = p.product_img,
        //                    product_sub_img = p.product_sub_img,
        //                    //product_isHot = p.product_isHot,
        //                    //product_isNew = p.product_isNew,
        //                    //product_isSale = p.product_isSale,
        //                    //product_CreatedAt = p.product_CreatedAt,
        //                    //product_UpdatedAt = p.product_UpdatedAt,
        //                    //product_code = p.product_code,
        //                    //product_package = p.product_package,
        //                    //product_delivery = p.product_delivery,
        //                    //product_delivery_time = p.product_delivery_time,
        //                    //product_payment = p.product_payment,
        //                    //product_payment_type = p.product_payment_type,
        //                    //product_sub_info = p.product_sub_info,
        //                    //state = p.state,
        //                    //title_seo = p.title_seo,
        //                    //des_seo = p.des_seo,
        //                    //friendly_url = p.friendly_url,
        //                    //keyword = p.keyword,
        //                    //product_material = p.product_material,
        //                    //product_shape = p.product_shape,
        //                    //product_producer = p.product_producer,
        //                    //category_id = p.category_id
        //                });

        //    return list.ToArray();
        //}

        //lay 1 product
        [Route("Layproduct/{product_id}")]
        [HttpGet]
        public product Getproduct(int product_id)
        {
            return db.products.FirstOrDefault(n => n.product_id == product_id);
        }
        //them
        //[Route("postproduct/{product_id}/{product_name}/{product_alias}/{product_description}/{product_content}/{product_img}/{product_sub_img}/{product_isHot}/{product_isNew}/{product_isSale}/{product_CreatedAt}/{product_UpdatedAt}/{product_code}/{product_package}/{product_delivery}/{order_state}/{order_state}/{order_state}/{order_state}/{order_state}/{order_state}/{order_state}")]
        [HttpPost]
        public bool InsertProduct(int product_id, string product_name, string product_alias, string product_description, string product_content,
            string product_img, string product_sub_img, bool product_isHot, bool product_isNew, bool product_isSale,
            DateTime product_CreatedAt, DateTime product_UpdatedAt, string product_code, string product_package, string product_delivery,
            DateTime product_delivery_time, string product_payment, string product_payment_type, string product_sub_info, int state,
            string title_seo, string des_seo, string friendly_url, string keyword, string product_material,
            string product_shape, int product_producer, int category_id)
           
        {
            try
            {
                tbl_product tbl_Product = new tbl_product();
                tbl_Product.product_id = product_id;
                tbl_Product.product_name = product_name;
                tbl_Product.product_alias = product_alias;
                tbl_Product.product_description = product_description;
                tbl_Product.product_content = product_content;
                tbl_Product.product_img = product_img;
                tbl_Product.product_sub_img = product_sub_img;
                tbl_Product.product_isHot = product_isHot;
                tbl_Product.product_isNew = product_isNew;
                tbl_Product.product_isSale = product_isSale;
                tbl_Product.product_CreatedAt = product_CreatedAt;
                tbl_Product.product_UpdatedAt = product_UpdatedAt;
                tbl_Product.product_code = product_code;
                tbl_Product.product_package = product_package;
                tbl_Product.product_delivery = product_delivery;
                tbl_Product.product_delivery_time = product_delivery_time;
                tbl_Product.product_payment = product_payment;
                tbl_Product.product_payment_type = product_payment_type;
                tbl_Product.product_sub_info = product_sub_info;
                tbl_Product.state = state;
                tbl_Product.title_seo = title_seo;
                tbl_Product.des_seo = des_seo;
                tbl_Product.friendly_url = friendly_url;
                tbl_Product.keyword = keyword;
                tbl_Product.product_material = product_material;
                tbl_Product.product_shape = product_shape;
                tbl_Product.product_producer = product_producer;
                tbl_Product.category_id = category_id;
                db.tbl_products.InsertOnSubmit(tbl_Product);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //update
        //[Route("postproduct/{product_id}/{product_name}/{product_alias}/{product_description}/{product_content}/{product_img}/{product_sub_img}/{product_isHot}/{product_isNew}/{product_isSale}/{product_CreatedAt}/{product_UpdatedAt}/{product_code}/{product_package}/{product_delivery}/{order_state}/{order_state}/{order_state}/{order_state}/{order_state}/{order_state}/{order_state}")]
        [HttpPut]
        public bool UpdateProduct(int product_id, string product_name, string product_alias, string product_description, string product_content,
            string product_img, string product_sub_img, bool product_isHot, bool product_isNew, bool product_isSale,
            DateTime product_CreatedAt, DateTime product_UpdatedAt, string product_code, string product_package, string product_delivery,
            DateTime product_delivery_time, string product_payment, string product_payment_type, string product_sub_info, int state,
            string title_seo, string des_seo, string friendly_url, string keyword, string product_material,
            string product_shape, int product_producer, int category_id)

           
        {
            try
            {

                tbl_product tbl_Product = db.tbl_products.FirstOrDefault(n => n.product_id == product_id);
                tbl_Product.product_id = product_id;
                tbl_Product.product_name = product_name;
                tbl_Product.product_alias = product_alias;
                tbl_Product.product_description = product_description;
                tbl_Product.product_content = product_content;
                tbl_Product.product_img = product_img;
                tbl_Product.product_sub_img = product_sub_img;
                tbl_Product.product_isHot = product_isHot;
                tbl_Product.product_isNew = product_isNew;
                tbl_Product.product_isSale = product_isSale;
                tbl_Product.product_CreatedAt = product_CreatedAt;
                tbl_Product.product_UpdatedAt = product_UpdatedAt;
                tbl_Product.product_code = product_code;
                tbl_Product.product_package = product_package;
                tbl_Product.product_delivery = product_delivery;
                tbl_Product.product_delivery_time = product_delivery_time;
                tbl_Product.product_payment = product_payment;
                tbl_Product.product_payment_type = product_payment_type;
                tbl_Product.product_sub_info = product_sub_info;
                tbl_Product.state = state;
                tbl_Product.title_seo = title_seo;
                tbl_Product.des_seo = des_seo;
                tbl_Product.friendly_url = friendly_url;
                tbl_Product.keyword = keyword;
                tbl_Product.product_material = product_material;
                tbl_Product.product_shape = product_shape;
                tbl_Product.product_producer = product_producer;
                tbl_Product.category_id = category_id;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //xoa
        [Route("deleteproduct/{product_id}")]
        [HttpDelete]

        public bool Deleteproduct(int product_id)
        {
            try
            {
                tbl_product tbl_Product = db.tbl_products.FirstOrDefault(n => n.product_id == product_id);
                if (tbl_Product == null) { return false; }
                db.tbl_products.DeleteOnSubmit(tbl_Product);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //end product

        //begin producer
        [Route("Layproducer")]
        [HttpGet]
        public List< producer> Getallproducer()
        {
            return db.producers.ToList();
        }
       
        //get 1 product
        [Route("Layproducer/{producer_id}")]
        [HttpGet]
        public producer Getproduce(int producer_id)
        {
            return db.producers.FirstOrDefault(n => n.producer_id == producer_id);
        }    

        //them
        [HttpPost]
        public bool InsertProduce(int producer_id, string producer_name, string producer_address, int state)
        {
            try
            {
                tbl_producer producer = new tbl_producer();
                producer.producer_id = producer_id;
                producer.producer_name = producer_name;
                producer.producer_address = producer_address;
                producer.state = state;
                db.tbl_producers.InsertOnSubmit(producer);
                db.SubmitChanges();                
                return true;
            }
            catch
            {
                return false;
            }
        }


        //sua
        [HttpPut]
        public bool UpdateProduce(int producer_id, string producer_name, string producer_address, int state)
        {
            try
            {
                tbl_producer producer = db.tbl_producers.FirstOrDefault(n => n.producer_id == producer_id);
                if (producer == null) { return false; }
                producer.producer_id = producer_id;
                producer.producer_name = producer_name;
                producer.producer_address = producer_address;
                producer.state = state;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //xoa
        [Route("deleteproducer/{producer_id}")]
        [HttpDelete]

        public bool DeleteProduce(int producer_id)
        {
            try
            {
                tbl_producer tbl_Producer = db.tbl_producers.FirstOrDefault(n => n.producer_id == producer_id);
                if (tbl_Producer == null) { return false; }
                db.tbl_producers.DeleteOnSubmit(tbl_Producer);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [Route("laystate")]
        public List<tbl_state> getstate()
        {
            return db.tbl_states.ToList();
        }
    }
}
