using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJI.Models
{
    public class Approver
    {
        public List<EmployeeProfile> profiles { get; set; } = new List<EmployeeProfile>();

        public List<string> email_in()
        {
            return profiles.Select(emp => emp.email_in).ToList();
        }

        public List<BasicProfile> basic_profiles()
        {
            return profiles.Select(profile => new BasicProfile
            {
                id = profile.id,
                full_name_en = profile.full_name_en,
                email_in = profile.email_in,
                position_name = profile.pos_name_th ?? profile.pos_name_en,
                div = profile.div,
                sec = profile.sec,
                dep = profile.dep,
                uni = profile.uni,
                nickname = profile.nickname,
                job_brand = profile.job_brand
            }).ToList();
        }
    }
}
