# ARTC.MicroserviceTemplate.CS
A C# Template for Microservice Development (Mantained by Noah Tan Han Jin @ tanhj@artc.a-star.edu.sg 

## Basic Usage

Pre-requisites

Software  | Download Link
------------- | -------------
ASP.NET Core Runtime 7.0.10 | https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-7.0.10-windows-hosting-bundle-installer


The Repository contains 2 templates, each for their specific purposes:

Software  | Download Link
------------- | -------------
ARTC.Microservice | Contains Authorization, Users, Roles, Scopes, Tenant Managements, Select this if your application is a cloud application.
ARTC.MicroserviceNonAuth | Does not contain Authorization, Users, Roles, Scopes, Tenant Managements, Select this if your application is an On-Premise Application

After cloning:

I. Delete the non-used alternate template type.

II. Run the rename script (RenameScript.vbs) located in the root folder of the template. 
Please pick a clear, concise and coherent name in camel case that describes the microservice application such as:
DemandPlanner, SupplyPlanner, InventoryPlanner, etc.

##
## Configurables

### ARTC.MicroserviceNonAuth

#### HttpApi.Host Project
 

The appsettings.json file located in HttpApi.Host module contains:
- The CORS allowance policy for frontend usage

- The database connection string for the microservice.



I. You may add in additional URLs followed after a delimiting comma in the App Configuration
to configure Cors policy endpoints
  "App": 
  {

    "CorsOrigins": "https://*.MainApp.com,http://localhost:4200,http://exampleURL.com" 
    
}, 


II. Change the connection string of your database to a prefered name other than "MicroserviceNonAuth", such as Database=DemandPlannerService 

  "ConnectionStrings": {

    "MicroserviceNonAuth": 
    "Server=localhost;Database=MicroserviceNonAuth;       
    Trusted_Connection=True;TrustServerCertificate=True"
  }

III. The RabbitMQ Key allows users to configure distributed events for communications between microservices. For additional details and advanced configurations, refer to documentation here: https://docs.abp.io/en/abp/latest/Distributed-Event-Bus-RabbitMQ-Integration

"RabbitMQ": {

    "Connections": {
      "Default": {
        "HostName": "localhost"
      }
    },
    "EventBus": {
      "ClientName": "OrcaHub_ServiceAuth", //Queue Name.
      "ExchangeName": "OrcaHub_Exchange" //Your microservice should always point to the main hub exchange instead of making another exchange.
    }
  }

### ARTC.Microservice 

#### HttpApi.Host Project
 

I. The appsettings.json file located in HttpApi.Host module contains:
- Configurations pointed at an Authentication Server
- Client OIDC Settings
- The CORS allowance policy for frontend usage
- The database connection string for the microservice.

I. You may add in additional URLs followed after a delimiting comma in the App Configuration
to configure Cors policy endpoints.

  "App": {

    "CorsOrigins": "https://*.OrcaHub.com, http://localhost:4201" //Change this to allow communication with frontend 
  },
  
II. The AuthServer Key configures the Authentication and Authorization Server, For additional information, read more on IdentityServer4.
This configuration should always point to the OrcaHub Server which also acts as the user authentication service.

  "AuthServer": {

    "Authority": "https://localhost:44399", //Change this to the host module URL
    "RequireHttpsMetadata": "true",
    "SwaggerClientId": "Microservice_Swagger", //Change this to a registered OIDC Application
    "SwaggerClientSecret": "1q2w3e*", //If oidc application is confidential, set this.
  },


III. The connection string provides information for:

- The authentication server datatables
- The microservice's datatables

The "Default" key should always be maintained which serves as the configuration key for the auth server. 

"ConnectionStrings": {

    "Default": "Server=localhost;Database=OrcaHub_Main;Trusted_Connection=True;TrustServerCertificate=True", //Point this to database of Authentication Service
    "Microservice": "Server=localhost;Database=ARTCMicroservice;Trusted_Connection=True;TrustServerCertificate=True" //Point this to database of This service, fix key name in startup
  },


III. The RabbitMQ Key allows users to configure distributed events for communications between microservices. For additional details and advanced configurations, refer to documentation here: https://docs.abp.io/en/abp/latest/Distributed-Event-Bus-RabbitMQ-Integration

"RabbitMQ": {

    "Connections": {
      "Default": {
        "HostName": "localhost"
      }
    },
    "EventBus": {
      "ClientName": "OrcaHub_ServiceAuth", //Queue Name.
      "ExchangeName": "OrcaHub_Exchange" //Your microservice should always point to the main hub exchange instead of making another exchange.
    }
  }


## Useful Links

Description  | Link
------------- | -------------
Quick tutorial to develop ASPNET applications | https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=NG&DB=EF
Etity Framework Core Relational Configurations | https://learn.microsoft.com/en-us/ef/core/modeling/relationships