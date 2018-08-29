# AXADemo Project

This project is a test exercice for AXA Enterprise.

It consists in a few web apis reporting clients and policies data consumed remotely from other web apis.

AXDemo contains an help page where all its structure, calls and return values ​​are reported, with examples.

In addition, in the case of the examples you can find the option of testing the web api.

The project, by means of the Log4net library, is reporting log messages, which are found in the "/log" folder.

All source code have been written in Visual Studio 2017 and tested in IIS Express.

## Getting Started

Initial Page of this project is its help page (/help'). Once you browse by web api help pages you can test that web api in the same page.

Users and roles of application are extracted from a remote service 'http://www.mocky.io/v2/5808862710000087232b75ac'. This is, at the beginning of execution application requires Basic User Autentification. This user must be the user name of client of mentioned remote service.

By default, all users have the same password 'pass'. This can be changed in web.config file.


### Prerequisites



Below we will list all the Third Party libraries that have been used in this project:



  package id="jQuery" version="1.6.2" targetFramework="net461"
  
  package id="jQuery.UI.Combined" version="1.9.2" targetFramework="net461"
  
  package id="knockoutjs" version="2.2.0" targetFramework="net461"
  
  package id="log4net" version="2.0.8" targetFramework="net461"
  
  package id="Microsoft.AspNet.Mvc" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.Razor" version="3.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi" version="5.2.4" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.Client" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.Client.es" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.Core" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.Core.es" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.HelpPage" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.WebHost" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebApi.WebHost.es" version="5.2.6" targetFramework="net461"
  
  package id="Microsoft.AspNet.WebPages" version="3.2.6" targetFramework="net461"
  
  package id="Microsoft.CodeDom.Providers.DotNetCompilerPlatform" version="2.0.0" targetFramework="net461"
  
  package id="Microsoft.Web.Infrastructure" version="1.0.0.0" targetFramework="net461"
  
  package id="Newtonsoft.Json" version="11.0.1" targetFramework="net461"
  
  package id="WebApiTestClient" version="1.1.1" targetFramework="net461" 
  


### Installing


You must download root folder AXADemo to a local folder in your machine.


## Running the tests


For run this source code, once it is downloaded, open AXADemo.sln file with VS2017 and run project pressing 'F5' key.


## Authors

* **Pep Vivó** - Analyst-Programmer 
EMail : pepvivo@hotmail.com


