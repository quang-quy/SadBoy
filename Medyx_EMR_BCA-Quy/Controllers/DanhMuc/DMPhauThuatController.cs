﻿using System;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medyx_EMR_BCA.Models.DanhMuc;
using Excel;
using MongoDB.Driver;
using Medyx_EMR_BCA.Models;
using Newtonsoft.Json;
namespace HTC.WEB.NIOEH.Areas.Client.DanhMuc
{
    public class DMPhauThuatController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        //public readonly ISession session;
        public DMPhauThuatController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo

        #region Load danh sách phẫu thuật paging

        [HttpGet]
        public JsonResult LoadData(string maPT, string tenPT,String TenNhomDV,String TenPLPTTT, String TenTat, String TenChungLoai,String MaBYT,String TenBYT,String GhiChu, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
        {
            //var response = _PhauThuatService.DMPhauThuatGetListPaging(maPT, tenPT, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(maPT))
                maPT = "";
            if (string.IsNullOrEmpty(tenPT))
                tenPT = "";
            if (string.IsNullOrEmpty(maMay))
                maMay = "";
            if (string.IsNullOrEmpty(ngaySD))
                ngaySD = "";
            if (string.IsNullOrEmpty(nguoiSD))
                nguoiSD = "";
            if (string.IsNullOrEmpty(TenChungLoai))
                TenChungLoai = "";
            if (string.IsNullOrEmpty(TenPLPTTT))
                TenPLPTTT = "";
            if (string.IsNullOrEmpty(TenTat))
                TenTat = "";
            if (string.IsNullOrEmpty(MaBYT))
                MaBYT = "";
            if (string.IsNullOrEmpty(TenBYT))
                TenBYT = "";
            if (string.IsNullOrEmpty(TenNhomDV))
                TenNhomDV = "";
            if (string.IsNullOrEmpty(GhiChu))
                GhiChu = "";
            var response = db.DMPhauThuatGetListPaging(maPT, tenPT, TenNhomDV, TenPLPTTT, TenTat, TenChungLoai, MaBYT, TenBYT, GhiChu, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion

        #region View thực hiện update phẫu thuật

        [HttpPost]
        public ActionResult Modify(DMPhauThuat DMPhauThuat)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMPhauThuat/Index/Modify").Count() > 0;
            if (Quyen)
            {
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMPhauThuat";
                emp.KieuTacDong = "Update";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = JsonConvert.SerializeObject(DMPhauThuat);
                collection.InsertOne(emp);
                #endregion
                db.spDMPhauThuat_UPDATE(DMPhauThuat.MaPT, DMPhauThuat.TenPT, DMPhauThuat.MaNhomDV, DMPhauThuat.MaPLPTTT, DMPhauThuat.TenTat, DMPhauThuat.MaChungLoai, DMPhauThuat.MaBYT, DMPhauThuat.TenBYT, DMPhauThuat.GhiChu, MaMay, u.Pub_sNguoiSD, DMPhauThuat.Huy);
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền sửa phẫu thuật!", status = 500 });

        }

        #endregion 

        #region View delete phẫu thuật

        [HttpPost]
        public ActionResult DeletePhauThuat(string maPT)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMPhauThuat/Index/Delete").Count() > 0;
            if (Quyen)
            {
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                string MaMay = this.GetLocalIPAddress();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMPhauThuat";
                emp.KieuTacDong = "Delete";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Delete maPT: " + maPT;
                collection.InsertOne(emp);
                #endregion
                db.spDMPhauThuat_DELETED(maPT, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền xóa chức vụ!", status = 500 });
        }

        #endregion 

        #region View thêm mới phẫu thuật
        [HttpPost]
        public ActionResult CreatePhauThuat(string TenPT, string MaNhomDV, string MaPLPTTT, string TenTat, string MaChungLoai, string MaBYT, string TenBYT, string GhiChu)
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMPhauThuat/Index/Create").Count() > 0;
            if (Quyen)
            {
                string MaMay = this.GetLocalIPAddress();
                HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                #region ghi log
                string constr = u.MongoDBConnectionString;
                var client = new MongoClient(constr);
                IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                TraceLogMongo emp = new TraceLogMongo();
                emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                emp.TenBang = "DMPhauThuat";
                emp.KieuTacDong = "Create";
                emp.NguoiSD = u.Pub_sNguoiSD;
                emp.MaMay = MaMay;
                emp.NoiDungSD = "Create TenPT: " + TenPT + ", MaNhomDV: " + MaNhomDV + ", MaPLPTTT: " + MaPLPTTT + ", TenTat: " + TenTat + ", MaChungLoai: " + MaChungLoai + ", MaBYT: " + MaBYT + ", TenBYT: " + TenBYT + ", GhiChu: " + GhiChu;
                collection.InsertOne(emp);
                #endregion
                db.spDMPhauThuat_CREATE(TenPT, MaNhomDV, MaPLPTTT, TenTat, MaChungLoai, MaBYT, TenBYT, GhiChu, MaMay, u.Pub_sNguoiSD);

                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới phẫu thuật!", status = 500 });
        }
        #endregion

        //#region Load danh mục phẫu thuật get all
        //public JsonResult DMPhauThuatGetAll()
        //{
        //    var response = _PhauThuatService.DMPhauThuatGetAll();
        //    return CreateJsonJsonResult(() =>
        //    {
        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    });
        //}
        //#endregion

        #region Export dữ liệu theo các cột được chọn
        [HttpGet]
        public ActionResult ExportExcel(string obj)
        {
            dynamic data = JObject.Parse(obj);
            string key = data.key;
            string columns = data.columns;
            //HttpContext.Server.ScriptTimeout = 90;
            //var dataSource = _chucVuService.ExportDMChucVu(key, columns);
            HL7CoreDataDataContext db = new HL7CoreDataDataContext();
            var dataSource = db.ExportDMPhauThuat(key, columns);
            string filename = "DMPhauThuat " + DateTime.Now.ToString() + ".xlsx";
            //MVC4 mVC4 = new MVC4();
            //mVC4.
            ExportToExcel(filename, dataSource);
            return RedirectToAction("/Index");
        }
        #endregion

        #region Import data
        [HttpPost]
        public ActionResult ImportDanhMuc()
        {
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            var Quyen = u.ListRoleSession.Where(x => x.ActionDetailsName == "/DMPhauThuat/Index/ImportDanhMuc").Count() > 0;
            if (Quyen)
            {
                var file = Request.Form.Files[0];
                //HttpPostedFileBase fileName = (HttpPostedFileBase)Request.Form.Files[0];
                string ins = Request.Form["insert"];
                bool insert = Convert.ToBoolean(ins);
                //if (ModelState.IsValid)
                //{
                if (file != null && file.Length > 0)
                {
                    //ExcelDataReader works on binary excel file
                    Stream stream = file.OpenReadStream();
                    //We need to written the Interface.
                    IExcelDataReader reader = null;
                    if (file.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        return RedirectToAction("Index");
                    }
                    //treats the first row of excel file as Coluymn Names
                    reader.IsFirstRowAsColumnNames = true;
                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();
                    reader.Close();
                    result.Tables[0].TableName = "DMPhauThuat";
                    for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    {
                        if (i == 5)
                        {
                            DataColumn newcolumn = new DataColumn("temporary", typeof(DateTime));
                            result.Tables[0].Columns.Add(newcolumn);
                            foreach (DataRow row in result.Tables[0].Rows)
                            {
                                try
                                {
                                    row["temporary"] = Convert.ChangeType(row[i], typeof(DateTime));
                                }
                                catch
                                {
                                }
                            }
                            result.Tables[0].Columns.Remove("NgaySD");
                            newcolumn.ColumnName = "NgaySD";
                        }
                        else
                            result.Tables[0].Columns[i].DataType = typeof(String);
                    }
                    HL7CoreDataDataContext db = new HL7CoreDataDataContext();
                    #region ghi log
                    string MaMay = this.GetLocalIPAddress();
                    string constr = u.MongoDBConnectionString;
                    var client = new MongoClient(constr);
                    IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
                    IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
                    TraceLogMongo emp = new TraceLogMongo();
                    emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                    emp.TenBang = "DMPhauThuat";
                    emp.KieuTacDong = "Import";
                    emp.NguoiSD = u.Pub_sNguoiSD;
                    emp.MaMay = MaMay;
                    emp.NoiDungSD = JsonConvert.SerializeObject(result.Tables[0]);
                    collection.InsertOne(emp);
                    #endregion
                    db.ImportDMPhauThuat(result.Tables[0], insert);
                    //_chucVuService.ImportDMChucVu(result.Tables[0], insert);
                    return RedirectToAction("Index");
                }
                //}
                //else
                //{
                //    ModelState.AddModelError("File", "Please upload your file");
                //}
                return RedirectToAction("Index");
            }
            else
                return Json(new { success = false, message = "Không có quyền thêm mới phẫu thuật!", status = 500 });
        }
        #endregion
    }
}