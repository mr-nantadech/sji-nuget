using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SJI.Extensions
{
    public static class SJIExtensions
    {
        private static readonly List<string> unit = new List<string> { "L0", "L1", "L2", "L3", "L4", "L5", "L6", "L7", "L8", "L9", "S0", "S1", "S2", "S3", "S4", "S5", "S6", "C1", "M1", "M2", "M3", "M4", "M5", "M6", "M7", "M8" };
        private static readonly List<string> dept = new List<string> { "M9", "M10" };
        private static readonly List<string> sec = new List<string> { "M11", "M12" };
        private static readonly List<string> div = new List<string> { "M13", "M14" };
        private static readonly List<string> md = new List<string> { "M15", "M16" };

        public static SJIResult SJI(this IEnumerable<dynamic> profiles)
        {
            return new SJIResult(profiles);
        }

        public class SJIResult
        {
            private readonly IEnumerable<dynamic> _profiles;

            public SJIResult(IEnumerable<dynamic> profiles)
            {
                _profiles = profiles;
            }

            public ApproverResult GetWhoApproverOf(string empId)
            {
                var foundProfile = _profiles.FirstOrDefault(emp => emp.id == empId);

                if (foundProfile != null)
                {
                    var foundProfileNextLevel = new List<dynamic>();

                    if (unit.Contains((foundProfile.job_brand)))
                    {
                        foundProfileNextLevel = _profiles.Where(emp =>
                            emp.id != empId &&
                            emp.div == foundProfile.div &&
                            emp.sec == foundProfile.sec &&
                            emp.dep == foundProfile.dep &&
                            !HasProperty(emp, "uni") &&
                            dept.Contains(emp.job_brand)).ToList();

                        if (!foundProfileNextLevel.Any())
                        {
                            foundProfileNextLevel = _profiles.Where(emp =>
                                emp.id != empId &&
                                emp.div == foundProfile.div &&
                                emp.sec == foundProfile.sec &&
                                !HasProperty(emp, "dep") &&
                                !HasProperty(emp, "uni") &&
                                sec.Contains(emp.job_brand)).ToList();
                        }

                        if (!foundProfileNextLevel.Any())
                        {
                            foundProfileNextLevel = _profiles.Where(emp =>
                                emp.id != empId &&
                                emp.div == foundProfile.div &&
                                !HasProperty(emp, "sec") &&
                                !HasProperty(emp, "dep") &&
                                !HasProperty(emp, "uni") &&
                                div.Contains(emp.job_brand)).ToList();
                        }

                        if (!foundProfileNextLevel.Any())
                        {
                            foundProfileNextLevel = _profiles.Where(emp =>
                                emp.id != empId &&
                                md.Contains(emp.job_brand)).ToList();
                        }
                    }
                    else if (dept.Contains(foundProfile.job_brand))
                    {
                        foundProfileNextLevel = _profiles.Where(emp =>
                            emp.id != empId &&
                            emp.div == foundProfile.div &&
                            emp.sec == foundProfile.sec &&
                            !HasProperty(emp, "dep") &&
                            !HasProperty(emp, "uni") &&
                            sec.Contains(emp.job_brand)).ToList();

                        if (!foundProfileNextLevel.Any())
                        {
                            foundProfileNextLevel = _profiles.Where(emp =>
                                emp.id != empId &&
                                emp.div == foundProfile.div &&
                                !HasProperty(emp, "sec") &&
                                !HasProperty(emp, "dep") &&
                                !HasProperty(emp, "uni") &&
                                div.Contains(emp.job_brand)).ToList();
                        }

                        if (!foundProfileNextLevel.Any())
                        {
                            foundProfileNextLevel = _profiles.Where(emp =>
                                emp.id != empId &&
                                md.Contains(emp.job_brand)).ToList();
                        }
                    }
                    else if (sec.Contains(foundProfile.job_brand))
                    {
                        foundProfileNextLevel = _profiles.Where(emp =>
                            emp.id != empId &&
                            emp.div == foundProfile.div &&
                            !HasProperty(emp, "sec") &&
                            !HasProperty(emp, "dep") &&
                            !HasProperty(emp, "uni") &&
                            div.Contains(emp.job_brand)).ToList();

                        if (!foundProfileNextLevel.Any())
                        {
                            foundProfileNextLevel = _profiles.Where(emp =>
                                emp.id != empId &&
                                md.Contains(emp.job_brand)).ToList();
                        }
                    }
                    else if (div.Contains(foundProfile.job_brand))
                    {
                        foundProfileNextLevel = _profiles.Where(emp =>
                            emp.id != empId &&
                            md.Contains(emp.job_brand)).ToList();
                    }

                    return new ApproverResult(foundProfileNextLevel);
                }

                return new ApproverResult(new List<dynamic>());
            }

            private bool HasProperty(dynamic obj, string propertyName)
            {
                if (obj is ExpandoObject)
                    return ((IDictionary<string, object>)obj).ContainsKey(propertyName);
                var type = obj?.GetType();
                return type != null && string.IsNullOrEmpty(type.GetProperty(propertyName)?.Name);
            }
        }

        public class ApproverResult
        {
            private readonly IEnumerable<dynamic> _profiles;

            public ApproverResult(IEnumerable<dynamic> profiles)
            {
                _profiles = profiles;
            }

            public string Profiles()
            {
                return JsonConvert.SerializeObject(_profiles);
            }

            public string BasicProfiles()
            {
                var jsonreturn = _profiles.Select(profile => new
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
                });

                // Serialize to JSON string and return
                return JsonConvert.SerializeObject(jsonreturn);
            }

            public string EmailIn()
            {
                return JsonConvert.SerializeObject(_profiles.Select(emp => emp.email_in).Cast<string>());
            }
        }
    }
}