using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Program
    {
        struct passport
        {
            public string byr;
            public string iyr;
            public string eyr, hgt, hcl, ecl, pid, cid;

            public bool checkBYR
            {
                get
                {
                    int val = Convert.ToInt32(byr);
                    if (val < 1920 || val > 2002)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            public bool checkIYR
            {
                get
                {
                    int val = Convert.ToInt32(iyr);
                    if (val < 2010 || val > 2020)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            public bool checkEYR
            {
                get
                {
                    int val = Convert.ToInt32(eyr);
                    if (val < 2020 || val > 2030)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            public bool checkHGT
            {
                get
                {
                    int val = Convert.ToInt32(hgt.Substring(0,hgt.Length - 2));
                    string type = hgt.Substring(hgt.Length - 2, 2);
                    if(type == "cm")
                    {
                        if (val < 150 || val > 193)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (val < 59 || val > 76)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                   
                }
            }
            public bool checkHCL
            {
                get
                {
                    if(hcl[0] != '#')
                    {
                        return false;
                    }
                    if (hcl.Length != 7)
                    {
                        return false;
                    }
                    try
                    {
                        int num = Int32.Parse(hcl.Substring(1, 6), System.Globalization.NumberStyles.HexNumber);

                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            public bool checkECL
            {
                get
                {
                    if (ecl == "hzl" || ecl == "amb" || ecl == "blu" || ecl == "brn" || ecl == "gry" || ecl == "grn" || ecl == "oth")
                    {
                        return true;
                    }
                    return false;
                }
            }

            public bool checkPID
            {
                get
                {
                    if (pid.Length != 9)
                    {
                        return false;
                    }
                    try
                    {
                        Convert.ToInt32(pid);
                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }

            public bool checkCID
            {
                get
                {
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {
            List<passport> Passports = new List<passport>();
            string[] PassportData = File.ReadAllLines("Passport.txt");

            int PassPortCount = 0;
            passport newPassPort = new passport();
            do
            {
                if(PassportData[PassPortCount] == "")
                {
                    Passports.Add(newPassPort);
                    newPassPort = new passport();
                }
                else
                {
                    string[] PassportLine = PassportData[PassPortCount].Split(' ');
                    foreach (string PassportDataItem in PassportLine)
                    {
                        string key = PassportDataItem.Split(':')[0];
                        string value = PassportDataItem.Split(':')[1];
                        switch (key)
                        {
                            case "byr":
                                newPassPort.byr = value;
                                break;
                            case "iyr":
                                newPassPort.iyr = value;
                                break;
                            case "eyr":
                                newPassPort.eyr = value;
                                break;
                            case "hgt":
                                newPassPort.hgt = value;
                                break;
                            case "hcl":
                                newPassPort.hcl = value;
                                break;
                            case "ecl":
                                newPassPort.ecl = value;
                                break;
                            case "pid":
                                newPassPort.pid = value;
                                break;
                            case "cid":
                                newPassPort.cid = value;
                                break;
                        }
                    }
                   
                }
                PassPortCount++;
            } while (PassPortCount < PassportData.Length);

            int validCount = 0;
            int superExtraValid = 0;
            foreach (passport pass in Passports)
            {
                if(pass.eyr != null && pass.byr != null && pass.ecl != null && pass.hcl != null && pass.hgt != null && pass.iyr != null && pass.pid != null)
                {
                    validCount++;
                    if(pass.checkBYR && pass.checkCID && pass.checkECL && pass.checkEYR && pass.checkHCL && pass.checkHGT && pass.checkIYR && pass.checkPID)
                    {
                        superExtraValid++;
                    }
                }
            }

            Console.WriteLine(validCount);
            Console.WriteLine(superExtraValid);
            Console.ReadLine();
        }
    }
}
