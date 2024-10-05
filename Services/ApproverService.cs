using SJI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJI.Services
{
    public class ApproverService
    {
        private List<string> unit = new List<string>
        {
            "L0", "L1", "L2", "L3", "L4", "L5", "L6", "L7", "L8", "L9",
            "S0", "S1", "S2", "S3", "S4", "S5", "S6", "C1", "M1", "M2",
            "M3", "M4", "M5", "M6", "M7", "M8"
        };

        private List<string> dept = new List<string> { "M9", "M10" };
        private List<string> sec = new List<string> { "M11", "M12" };
        private List<string> div = new List<string> { "M13", "M14" };
        private List<string> md = new List<string> { "M15", "M16" };

        public Approver GetWhoApproverOf(string empId, List<EmployeeProfile> profiles)
        {
            var foundProfile = profiles.FirstOrDefault(emp => emp.id == empId);

            if (foundProfile != null)
            {
                var foundProfileNextLevel = new List<EmployeeProfile>();

                if (unit.Contains(foundProfile.job_brand))
                {
                    foundProfileNextLevel = profiles
                        .Where(emp => emp.id != empId &&
                                      emp.div == foundProfile.div &&
                                      emp.sec == foundProfile.sec &&
                                      emp.dep == foundProfile.dep &&
                                      string.IsNullOrEmpty(emp.uni) && dept.Contains(emp.job_brand))
                        .ToList();

                    if (!foundProfileNextLevel.Any())
                    {
                        foundProfileNextLevel = profiles
                            .Where(emp => emp.id != empId &&
                                          emp.div == foundProfile.div &&
                                          emp.sec == foundProfile.sec &&
                                          string.IsNullOrEmpty(emp.dep) && string.IsNullOrEmpty(emp.uni) &&
                                          sec.Contains(emp.job_brand))
                            .ToList();
                    }

                    if (!foundProfileNextLevel.Any())
                    {
                        foundProfileNextLevel = profiles
                            .Where(emp => emp.id != empId &&
                                          emp.div == foundProfile.div &&
                                          string.IsNullOrEmpty(emp.sec) && string.IsNullOrEmpty(emp.dep) && string.IsNullOrEmpty(emp.uni) &&
                                          div.Contains(emp.job_brand))
                            .ToList();
                    }

                    if (!foundProfileNextLevel.Any())
                    {
                        foundProfileNextLevel = profiles
                            .Where(emp => emp.id != empId && md.Contains(emp.job_brand))
                            .ToList();
                    }
                }

                if (dept.Contains(foundProfile.job_brand))
                {
                    foundProfileNextLevel = profiles
                        .Where(emp => emp.id != empId &&
                                      emp.div == foundProfile.div &&
                                      emp.sec == foundProfile.sec &&
                                      string.IsNullOrEmpty(emp.dep) && string.IsNullOrEmpty(emp.uni) &&
                                      sec.Contains(emp.job_brand))
                        .ToList();

                    if (!foundProfileNextLevel.Any())
                    {
                        foundProfileNextLevel = profiles
                            .Where(emp => emp.id != empId &&
                                          emp.div == foundProfile.div &&
                                          string.IsNullOrEmpty(emp.sec) && string.IsNullOrEmpty(emp.dep) && string.IsNullOrEmpty(emp.uni) &&
                                          div.Contains(emp.job_brand))
                            .ToList();
                    }

                    if (!foundProfileNextLevel.Any())
                    {
                        foundProfileNextLevel = profiles
                            .Where(emp => emp.id != empId && md.Contains(emp.job_brand))
                            .ToList();
                    }
                }

                if (sec.Contains(foundProfile.job_brand))
                {
                    foundProfileNextLevel = profiles
                        .Where(emp => emp.id != empId &&
                                      emp.div == foundProfile.div &&
                                      string.IsNullOrEmpty(emp.sec) && string.IsNullOrEmpty(emp.dep) && string.IsNullOrEmpty(emp.uni) &&
                                      div.Contains(emp.job_brand))
                        .ToList();

                    if (!foundProfileNextLevel.Any())
                    {
                        foundProfileNextLevel = profiles
                            .Where(emp => emp.id != empId && md.Contains(emp.job_brand))
                            .ToList();
                    }
                }

                if (div.Contains(foundProfile.job_brand))
                {
                    foundProfileNextLevel = profiles
                        .Where(emp => emp.id != empId && md.Contains(emp.job_brand))
                        .ToList();
                }

                return new Approver
                {
                    profiles = foundProfileNextLevel
                };
            }

            return new Approver();
        }
    }
}
