using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJI.Models
{
    public class EmployeeProfile
    {
        public string id { get; set; }
        public string? com_id { get; set; }
        public string? location_id { get; set; }
        public string? location_name_th { get; set; }
        public string? location_name_en { get; set; }
        public string? nickname { get; set; }
        public string? dept_id { get; set; }
        public string? dept_name_th { get; set; }
        public string? dept_name_en { get; set; }
        public string? dept_type_id { get; set; }
        public string? dept_type_name_th { get; set; }
        public string? dept_type_name_en { get; set; }
        public string? dept_div_id { get; set; }
        public string? dept_div_name_th { get; set; }
        public string? dept_div_name_en { get; set; }
        public string? dept_sec_id { get; set; }
        public string? dept_sec_name_th { get; set; }
        public string? dept_sec_name_en { get; set; }
        public string? dept_dep_id { get; set; }
        public string? dept_dep_name_th { get; set; }
        public string? dept_dep_name_en { get; set; }
        public string? dept_uni_id { get; set; }
        public string? dept_uni_name_th { get; set; }
        public string? dept_uni_name_en { get; set; }
        public string? div { get; set; }
        public string? sec { get; set; }
        public string? dep { get; set; }
        public string? uni { get; set; }
        public string? package { get; set; }
        public string? type_employee { get; set; }
        public string? forEdit { get; set; } = "";
        public string? cost_center { get; set; }
        public string? pos_id { get; set; }
        public string? pos_name_th { get; set; }
        public string? pos_name_en { get; set; }
        public string? shift_id { get; set; }
        public string? title_name_th { get; set; }
        public string? first_name_th { get; set; }
        public string? last_name_th { get; set; }
        public string? full_name_th { get; set; }
        public string? title_name_en { get; set; }
        public string? first_name_en { get; set; }
        public string? last_name_en { get; set; }
        public string? full_name_en { get; set; }
        public string? office_number { get; set; }
        public string? office_number_ex { get; set; }
        public DateTime? start_date { get; set; }
        public string? start_date_str { get; set; } = "";
        public DateTime? regular_date { get; set; }
        public string? regular_date_str { get; set; } = "";
        public DateTime? end_date { get; set; }
        public string? end_date_str { get; set; } = "";
        public string? email_in { get; set; }
        public string? email_ex { get; set; }
        public string? tel { get; set; }
        public string? line_id { get; set; }
        public string? line_link { get; set; }
        public int? biz_card { get; set; }
        public string? biz_dept { get; set; }
        public int? login_window { get; set; }
        public string? login_name { get; set; }
        public string? created_by { get; set; }
        public string? created_com { get; set; }
        public DateTime? created_at { get; set; }
        public string? updated_by { get; set; }
        public string? updated_com { get; set; }
        public DateTime? updated_at { get; set; }
        public int? status { get; set; }
        public string? img { get; set; }
        public string? job_brand { get; set; }
        public string? special_skill { get; set; }
        public int? introduce_status { get; set; }
        public string? job_brand_id { get; set; }
        public string? job_brand_name { get; set; }
        public string? job_brand_type { get; set; }
        public int? job_brand_level { get; set; }
    }

}
