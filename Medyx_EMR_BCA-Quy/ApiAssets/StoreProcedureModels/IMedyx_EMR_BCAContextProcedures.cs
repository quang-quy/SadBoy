﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Medyx_EMR_BCA.ApiAssets.StoreProcedureModels;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.ApiAssets.StoreProcedureModels
{
    public partial interface IMedyx_EMR_BCAContextProcedures
    {
        Task<int> sp_CAPMAAsync(string TENBANG, string MADAU, string MACUOI, byte? LENMACUOI, string WHERE, OutputParameter<string> MA, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_GetAllActionByRoleIDResult>> sp_GetAllActionByRoleIDAsync(string Account, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_GetAllMenuByUserIDResult>> sp_GetAllMenuByUserIDAsync(string UserName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spACCOUNT_GetResult>> spACCOUNT_GetAsync(string ACCOUNT, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spACCOUNT_ResetPassWordAsync(string maNV, string Account, string passwordCu, string password, string mamay, string nguoiSD, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spBenhan_Tiensubenh_Benhphoihop_CreateOrUpdateAsync(DataTable tmp, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMAction_GetByRoleResult>> spDMAction_GetByRoleAsync(string marole, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMChephamMau_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCDanh_CREATEResult>> spDMCHUCDanh_CREATEAsync(string TENCD, string MAMAY, string NGUOISD, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMCHUCDanh_DELETEDAsync(string MAMAY, string NGUOISD, string MaCD, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMChucDanh_ExportByColumnAsync(string dk, string Column, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCDANH_GetAllResult>> spDMCHUCDANH_GetAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCDANH_GetAllPagingResult>> spDMCHUCDANH_GetAllPagingAsync(string MaCD, string TenCD, string MaMay, string NgaySD, string NguoiSD, int? PageIndex, int? PageSize, bool? add, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMChucDanh_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMCHUCDanh_UPDATEAsync(string MACD, string TENCD, string MAMAY, string NGUOISD, bool? huy, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCVU_CREATEResult>> spDMCHUCVU_CREATEAsync(string TENCV, string MAMAY, string NGUOISD, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMCHUCVU_DELETEDAsync(string MAMAY, string NGUOISD, string MaCV, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMChucVu_ExportByColumnAsync(string dk, string Column, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMCHUCVU_FINDSAsync(string DK, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCVU_GetResult>> spDMCHUCVU_GetAsync(string MACV, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCVU_GetAllResult>> spDMCHUCVU_GetAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUCVU_GetAllPagingResult>> spDMCHUCVU_GetAllPagingAsync(string maCV, string tenCV, string maMay, string ngaySD, string nguoiSD, int? PageIndex, int? PageSize, int? add, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMChucVu_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMCHUCVU_UPDATEAsync(string MACV, string TENCV, string MAMAY, string NGUOISD, bool? huy, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMCHUYENMON_GetAllResult>> spDMCHUYENMON_GetAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMDichVu_CHUNGLOAI_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMDichVu_CS_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMDichVu_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMDichVu_LoaiHinh_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMDichVu_Nhom_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMDichvu_PhanLoaiPTTT_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMDMKhoa_Buong_ImportResult>> spDMDMKhoa_Buong_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMKHOA_GetAllResult>> spDMKHOA_GetAllAsync(bool? qadmin, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMKhoa_Giuong_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMKhoa_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMNhanVien_CreateResult>> spDMNhanVien_CreateAsync(string HoTen, string MaChucVu, string MaChuyenMon, string MaKhoa, string MaMay, string NguoiSD, int? MaQL, string MaCD, string TenTat, string GhiChu, string idnhanvien, string manv1, string maRole, string Account, string password, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMNhanVien_DELETEDAsync(string manv, string MaMay, string NguoiSD, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMNhanVien_ExportByColumnAsync(string dk, string Column, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMNHANVIEN_GetAllResult>> spDMNHANVIEN_GetAllAsync(bool? QADMIN, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMNhanVien_GetAllPagingResult>> spDMNhanVien_GetAllPagingAsync(string MaNV, string IDNhanVien, string HoTen, string MaChucVu, string MaChuyenMon, string MaKhoa, string MaMay, string NgaySD, string NguoiSD, string NguoiSD1, string NgaySD1, string MaQL, string MaCD, string TenTat, string GhiChu, string MaNV1, string account, string password, string tenrole, int? PageIndex, int? PageSize, int? add, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMNhanVien_ImportResult>> spDMNhanVien_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMNhanVien_UpdateAsync(string manv, string HoTen, string MaChucVu, string MaChuyenMon, string MaKhoa, string MaMay, string NguoiSD, int? MaQL, string MaCD, string TenTat, string GhiChu, string idnhanvien, string manv1, string maRole, string Account, string password, bool? huy, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMPhauThuat_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMRole_CREATEAsync(string TENRole, string MAMAY, string NGUOISD, DataTable tmpMenuRole, DataTable tmpActionRole, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMRole_DELETEDAsync(string MaRole, string MAMAY, string NGUOISD, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMRole_GetResult>> spDMRole_GetAsync(string MaRole, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMRole_GetAllResult>> spDMRole_GetAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMRole_GetAllPagingResult>> spDMRole_GetAllPagingAsync(string maRole, string tenRole, string maMay, string ngaySD, string nguoiSD, int? PageIndex, int? PageSize, int? add, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMRole_UpdateResult>> spDMRole_UpdateAsync(string ApplicationRolesId, string TENRole, bool? Huy, string MAMAY, string NGUOISD, DataTable tmpMenuRole, DataTable tmpActionRole, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMTHUOC_CHUNGLOAI_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMTHUOC_DangBaoChe_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMTHUOC_Donvitinh_ImportResult>> spDMTHUOC_Donvitinh_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMTHUOC_DuongDung_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMThuoc_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMTHUOC_NhaSX_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMTHUOC_Nhom_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMThuoc_PhanLoai_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spDMVTYT_Donvitinh_ImportResult>> spDMVTYT_Donvitinh_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMVTYT_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDMVTYT_Nhom_ImportAsync(DataTable tmp, bool? insert, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spMenu_GetByRoleResult>> spMenu_GetByRoleAsync(string marole, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTraceLog_GetAllPagingResult>> spTraceLog_GetAllPagingAsync(string tenbang, string mabn, string kieutacdong, string MaMay, DateTime? tungay, DateTime? denngay, string NgaySD, string NguoiSD, int? PageIndex, int? PageSize, bool? add, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTraceLogKieuTacDong_GetAllResult>> spTraceLogKieuTacDong_GetAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTraceLogTableName_GetAllResult>> spTraceLogTableName_GetAllAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<Token_API_GetTokenResult>> Token_API_GetTokenAsync(string Account, DateTime? Ngay, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<Token_API_GetTokenValidByNgayResult>> Token_API_GetTokenValidByNgayAsync(string Token, DateTime? Ngay, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}