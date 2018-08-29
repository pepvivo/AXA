using System.Reflection;
using System.Runtime.InteropServices;

// La información general sobre un ensamblado se controla mediante el siguiente 
// conjunto de atributos. Cambie los valores de estos atributos para modificar la información
// asociada a un ensamblado.
[assembly: AssemblyTitle("AXADemo")]
[assembly: AssemblyDescription("Demo exercie for AXA")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Pep Vivó")]
[assembly: AssemblyProduct("AXADemo")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Si ComVisible se establece en false, los componentes COM no verán los 
// tipos de este ensamblado. Si necesita obtener acceso a un tipo de este ensamblado desde 
// COM, establezca el atributo ComVisible en true en este tipo.
[assembly: ComVisible(false)]

// El siguiente GUID es para el Id. typelib cuando este proyecto esté expuesto a COM
[assembly: Guid("3664b923-f806-4008-b076-8dccc3b52248")]

// La información de versión de un ensamblado consta de los siguientes cuatro valores:
//
//      Versión principal
//      Versión secundaria 
//      Número de compilación
//      Revisión
//
// Puede especificar todos los valores o usar los valores predeterminados de número de compilación y de revisión 
// mediante el carácter '*', como se muestra a continuación:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

//Log4net configuration file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
