using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using SISCO.App.Operation;
using SISCO.Repositories.Context;

namespace MetaClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();
            var typelist = GetTypesInNamespace(Assembly.GetAssembly(typeof(InboundDataManager)), "SISCO.App.Operation");
            foreach (var type in typelist)
            {
                Console.WriteLine(type.Name);
                foreach (var method in type.GetMethods().Where(method => method.IsPublic && method.DeclaringType.FullName.Contains("SISCO.App")).OrderBy(f => f.Name))
                {
                    if (method.Name.ToLower().Equals("instance") || method.Name.ToLower().Equals("dispose")) continue;
                    var attributes = method.GetCustomAttributes(typeof(PrincipalPermissionAttribute), true);
                    try
                    {
                        using (var siscodbEntities = new SISCODBEntities())
                        {
                            foreach (var attribute in attributes)
                            {
                                var attribute1 = attribute as PrincipalPermissionAttribute;
                                if (attribute1 == null) continue;
                                if (attribute1.Role.ToLower().Equals("development") || attribute1.Role.ToLower().Equals("all"))
                                    continue;
                                var systemClass = new system_class
                                {
                                    rowstatus = true,
                                    MethodName = method.Name,
                                    Parameters = attribute1.Role,
                                    ModuleName = "",
                                    NameSpace = "",
                                    ClassName = type.Name,
                                    Description = "",
                                    createdby = "DEV",
                                    createddate = new DateTime(1900, 1, 1),
                                    modifiedby = "DEV",
                                    modifieddate = new DateTime(1900, 1, 1)
                                };
                                var sclass =
                                    siscodbEntities.system_class.FirstOrDefault(
                                        x => x.ClassName == systemClass.ClassName &&
                                             x.MethodName == systemClass.MethodName &&
                                             x.Parameters == systemClass.Parameters);
                                if (sclass == null)
                                    siscodbEntities.AddTosystem_class(systemClass);
                                else
                                {
                                    sclass.rowstatus = true;
                                    sclass.modifiedby = "DEV";
                                    sclass.modifieddate = DateTime.Now;
                                }
                                siscodbEntities.SaveChanges();
                            }    
                        }
                        

                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                //using (TextWriter tw = new StreamWriter("result.txt"))
                //{
                //    tw.WriteLine(result.ToString());
                //    tw.Close();
                //}
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}
